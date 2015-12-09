using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage;
using Storage.Models;
using Storage.Repository;
using Storage.Repository.Interface;
using StorageTests.Utility;

namespace StorageTests.RepositoryUnitTests
{

    /// <summary>
    /// This test class is used to test the Entity Framework UserRepository.
    /// The repository is a concrete implementation of the repository interface and is used to write data to a database.
    /// Consequently, Moq is used to allow the tests to verify that the repository writes correctly to the database.
    /// 
    /// </summary>
    [TestClass]
    public class AsyncUserRepositoryTests
    {

        private IList<StoredUser> _data;
        private Mock<IAutoSysContext> _context; // Use IUserContext instead of concrete AutoSysDbModel
        private Mock<DbSet<StoredUser>> _mockSet;
        private AsyncDbRepository<StoredUser> _repository;

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

            _mockSet = MockUtility.CreateAsyncMockDbSet(_data, u => u.Id);

            var mockContext = new Mock<IAutoSysContext>();
            mockContext.Setup(s => s.Users).Returns(_mockSet.Object);
            mockContext.Setup(s => s.Set<StoredUser>()).Returns(_mockSet.Object);
            mockContext.Setup(s => s.SaveChangesAsync()).Returns(Task.Run(() =>
            {
                // Increment user ids automatically based on existing ids in mock data 
                var max = _data.Max(u => u.Id);
                foreach (var user in _data.Where(u => u.Id == 0))
                {
                    user.Id = ++max;
                }
                return 1; // SaveChangesAsync returns number based on how many times it was called per default 
            }));

            _context = mockContext;
            _repository = new AsyncDbRepository<StoredUser>(_context.Object);
        }

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public async Task Create_NullException()
        {
            await _repository.Create(null);
        }

        [TestMethod]
        public async Task Create_SaveChanged_IsCalled()
        {
            var user = new StoredUser();
            var id = await _repository.Create(user);

            _context.Verify(c => c.SaveChangesAsync(), Times.Once);

        }

        /// <summary>
        /// This test uses Moq to create a context and then creates a DbSet<StoredUser> </StoredUser>.
        /// This is returned from the context's StoredUsers property. The context is used to create a new UserRepository, 
        /// which is then used to create a new Stored User, using the Create method. 
        /// Finally, the test verifies that the repository added a new user and called SaveChanges on the context.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Create_SavesUserInContext()
        {
            // Arrange 
            var mockSet = new Mock<DbSet<StoredUser>>();
            var mockContext = new Mock<IAutoSysContext>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            // Act 
            var service = new AsyncDbRepository<StoredUser>(mockContext.Object);
            var id = await service.Create(new StoredUser());

            // Assert 
            // mockSet.Verify(m => m.Add(It.IsAny<StoredUser>()), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());

        }

        [TestMethod]
        public void Create_SaveChanges_IsCalled()
        {
            var user = new StoredUser();
            var id = _repository.Create(user);
            _context.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        /// <summary>
        /// Test is true for EF but not for mocked interface that requires setup.
        /// This test is useless because it does not check logic but tests if EF correctly increments id and Mock works.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [Ignore]
        public async Task Create_ReturnsId_NewId()
        {
            // Arrange 
            var mockSet = new Mock<DbSet<StoredUser>>();
            var mockContext = new Mock<IAutoSysContext>();

            mockContext.Setup(m => m.Users).Returns(mockSet.Object);
            var user = new StoredUser { Name = "Steven", MetaData = "Validator" };

            // Act 
            var service = new AsyncDbRepository<StoredUser>(mockContext.Object);
            var id = await service.Create(user);

            // Assert 
            Assert.AreEqual(user.Id, id); // True for EF but not for interface 
        }

        [TestMethod]
        public async Task Update_SaveChangesAsync_IsCalled()
        {
            // Arrange
            var user = new StoredUser { Id = 1 };

            // Act
            await _repository.Update(user);

            // Assert
            _context.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Update_SetModified_IsCalled()
        {
            // Arrange 
            var user = new StoredUser { Id = 1, Name = "User", MetaData = "Validator" };

            // Act 
            await _repository.Update(user);

            // Assert
            _context.Verify(c => c.SetModified(user), Times.Once);
        }

        [TestMethod]
        public async Task Update_SetAttachUser_IsCalled()
        {
            // Arrange 
            var user = new StoredUser { Id = 1, Name = "User", MetaData = "Validator" };

            // Act 
            await _repository.Update(user);

            // Assert
            _context.Verify(c => c.Attach(user), Times.Once);
        }

        [TestMethod]
        public async Task Delete_RemovesUser()
        {
            // Arrange 
            var user = _data[0];

            // Act 
            var id = await _repository.Delete(user.Id);

            // Assert
            Assert.IsFalse(_data.Any(u => u.Id == 1));
        }

        [TestMethod]
        public async Task Delete_SaveChanges_IsCalled()
        {
            // Arrange
            var user = _data[0];

            // Act
            await _repository.Delete(user.Id);

            // Assert
            _context.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }


        [TestMethod]
        public async Task GetById()
        {
            var secondUser = await _repository.Read(1);
            Assert.AreEqual("William Parker", secondUser.Name);
        }

    }

}
