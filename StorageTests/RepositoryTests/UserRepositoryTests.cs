using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage;
using Storage.Models;
using Storage.Repository;
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
        private Mock<IUserContext> _context; // Use IUserContext instead of concrete AutoSysDbModel
        private Mock<DbSet<StoredUser>> _mockSet;
        private DbRepositoryStub<StoredUser> _repository;

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
            _repository = new DbRepositoryStub<StoredUser>(_context.Object);
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
            //var mockContext = new Mock<AutoSysDbModel>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            // Act 
            ///var service = new UserRepository();
            var service = new DbRepositoryStub<StoredUser>(mockContext.Object);
            int id = service.CreateOrUpdate(new StoredUser());

            // Assert 
            mockSet.Verify(m => m.Add(It.IsAny<StoredUser>()), Times.Once());
            mockContext.Verify(m => m.SaveChanges(), Times.Once());

            Assert.AreEqual(0, _data[0].Id);
        }

        [TestMethod]
        public void Create_SaveChanges_IsCalled()
        {
                var user = new StoredUser();
                var id = _repository.CreateOrUpdate(user);
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
            var service = new DbRepositoryStub<StoredUser>(mockContext.Object);
            //var service = new UserRepository(mockContext.Object);
            var id = service.CreateOrUpdate(user);

            Assert.AreEqual(0, _data[0].Id);
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

        /*
        [TestMethod]
        public void GetById()
        {
            var secondUser = _repository.Get(1);
            Assert.AreEqual("William Parker", secondUser.Name);
        }
        */

        /*
        [TestMethod]
        public void GetByName()
        {
            using (var repository = new UserRepository(_context.Object))
            {;
            }
        }
        */

    }

}
