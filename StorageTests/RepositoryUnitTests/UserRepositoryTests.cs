using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using StorageTests.Utility;

namespace StorageTests.RepositoryTests
{

    /// <summary>
    /// This test class is used to test the Entity Framework UserRepository.
    /// The repository is a concrete implementation of the repository interface and is used to write data to a database.
    /// Consequently, Moq is used to allow the tests to verify that the repository writes correctly to the database.
    /// 
    /// </summary>
    [TestClass]
    public class UserRepositoryTests
    {

        private IList<StoredUser> _data;
        private Mock<Utility.IUserContext> _context; // Use IUserContext instead of concrete AutoSysDbModel
        private Mock<DbSet<StoredUser>> _mockSet;
        private UserRepositoryStub _repository;

        /// <summary>
        /// This method sets up data used to mock a collection of users in a DbContext used by the UserRepository. 
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {

            _data = new List<StoredUser>
            {
                new StoredUser {Id = 1, Name = "William Parker", MetaData = "Researcher"},
                new StoredUser {Id = 2, Name = "Trudy Jones", MetaData = "Researcher"}
            }; 

            _mockSet = MockUtility.CreateMockDbSet(_data, u => u.Id);

            var mockContext = new Mock<IUserContext>();
            mockContext.Setup(s => s.Users).Returns(_mockSet.Object);
            mockContext.Setup(s => s.SaveChanges()).Callback(() =>
            {
                // Increment user ids automatically based on existing ids in mock data 
                var max = _data.Max(u => u.Id);
                foreach (var user in _data.Where(u => u.Id == 0))
                {
                    user.Id = ++max;
                }
            });

            _context = mockContext;
            _repository = new UserRepositoryStub(_context.Object);
        }

        /// <summary>
        /// This test uses Moq to create a context and then creates a DbSet<StoredUser> </StoredUser>.
        /// This is returned from the context's StoredUsers property. The context is used to create a new UserRepository, 
        /// which is then used to create a new Stored User, using the Create method. 
        /// Finally, the test verifies that the repository added a new user and called SaveChanges on the context.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public void Create_SavesUserInContext()
        {
            // Arrange 
            var mockSet = new Mock<DbSet<StoredUser>>();
            var mockContext = new Mock<IUserContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            // Act 
            var service = new UserRepositoryStub(mockContext.Object);
            //var service = new DbRepositoryStub<StoredUser>(mockContext.Object);
            int id = service.Create(new StoredUser());

            // Assert 
            mockSet.Verify(m => m.Add(It.IsAny<StoredUser>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }

        [TestMethod]
        public void Create_SaveChanges_IsCalled()
        {
                var user = new StoredUser();
                var id = _repository.Create(user);
                _context.Verify(r => r.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Create_ReturnsId_NewId()
        {
            // Arrange 
            var mockSet = new Mock<DbSet<StoredUser>>();
            var mockContext = new Mock<IUserContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            var user = new StoredUser { Name = "Steven", MetaData = "Validator" };

            // Act 
            //var service = new DbRepositoryStub<StoredUser>(mockContext.Object);
            var service = new UserRepositoryStub(mockContext.Object);
            var id = service.Create(user);

            Assert.AreEqual(0, user.Id);
        }

        [TestMethod]
        public void CreateMultipleUsers_ReturnsId_Incremented()
        {
            // Arrange 
            var mockSet = new Mock<DbSet<StoredUser>>();
            var mockContext = new Mock<IUserContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            var user = new StoredUser { Name = "Steven", MetaData = "Validator" };
            var secondUser = new StoredUser {Name = "William", MetaData = "Researcher"};

            // Act 
            //var service = new DbRepositoryStub<StoredUser>(mockContext.Object);
            var service = new UserRepositoryStub(mockContext.Object);
            var id = service.Create(user);
            var secondId = service.Create(secondUser);

            // Assert
            Assert.AreEqual(1, secondUser.Id);
        }

        [TestMethod]
        public void Update_SaveChanges_IsCalled()
        {
                var user = new StoredUser { Id = 1 };
                _repository.UpdateIfExists(user);
                _context.Verify(r => r.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Update_NewName()
        {
            // Arrange 
            var user = new StoredUser { Id = 1, Name = "User", MetaData = "Validator" };
            var researcher = _data[0];

            // Act 
            _repository.UpdateIfExists(user);

            // Act 
            Assert.AreEqual("User", researcher.Name);
        }

        [TestMethod]
        public void Update_NewMetaData()
        {
            // Arrange 
            var researcher = _data[0];
            var user = new StoredUser { Id = 1, MetaData = "Validator" };

            // Act 
            _repository.UpdateIfExists(user);

            // Assert
            Assert.AreEqual("Validator", researcher.MetaData);
        }

        [TestMethod]
        public void Delete_RemovesUser()
        {
            // Arrange 
            var user = _data[0];

            // Act 
            _repository.DeleteIfExists(user);

            // Assert
            Assert.IsFalse(_data.Any(u => u.Id == 1));
        }

        [TestMethod]
        public void Delete_SaveChanges_IsCalled()
        {
            // Arrange
            var user = _data[0];

            // Act
            _repository.DeleteIfExists(user);

            // Assert
            _context.Verify(repo => repo.SaveChanges(), Times.Once);
        }


        [TestMethod]
        public void GetById()
        {
            var secondUser = _repository.Read(1);
            Assert.AreEqual("William Parker", secondUser.Name);
        }

    }

}
