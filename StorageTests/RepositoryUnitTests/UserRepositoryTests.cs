using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository;
using Storage.Repository.Interface;
using StorageTests.Utility;

namespace StorageTests.RepositoryUnitTests
{
    /// <summary>
    ///     This test class is used to test the Entity Framework UserRepository, <see cref="UserRepository" />.
    ///     The repository is a concrete implementation of the repository interface and is used to write data to a database.
    ///     Consequently, Moq is used to allow the tests to verify that the repository writes correctly to the database.
    /// </summary>
    [TestClass]
    public class UserRepositoryTests
    {
        private Mock<IAutoSysContext> _context; // Use IUserContext instead of concrete AutoSysDbModel

        private IList<StoredUser> _data;
        private Mock<DbSet<StoredUser>> _mockSet;
        private UserRepository _repository;

        /// <summary>
        ///     This method sets up data used to mock a collection of users in a DbContext used by the UserRepository,
        ///     <see cref="UserRepository" />.
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
            _repository = new UserRepository(_context.Object);
        }

        #region Create Operation 

        [TestMethod, ExpectedException(typeof (ArgumentNullException))] // Assert 
        public async Task Create_NullInput_ExceptionThrown()
        {
            // Arrange and act 
            await _repository.Create(null);
        }

        [TestMethod]
        public async Task Create_Attatch_IsCalled()
        {
            // Arrange
            var validUser = new StoredUser {Id = 0, Name = "Steven", MetaData = "Researcher"};

            // Act 
            await _repository.Create(validUser);

            // Assert
            _context.Verify(c => c.Attach(validUser), Times.Once);
        }

        [TestMethod]
        public async Task Create_Add_IsCalled()
        {
            // Arrange
            var validUser = new StoredUser {Id = 0, Name = "Steven", MetaData = "Researcher"};

            // Act 
            await _repository.Create(validUser);

            // Assert
            _context.Verify(c => c.Add(validUser), Times.Once);
        }

        [TestMethod]
        public async Task Create_SaveChangesAsync_IsCalled()
        {
            // Arrange
            //var validUser = new StoredUser { Id = 0, Name = "Steven", MetaData = "Researcher" };
            var validUser = new StoredUser();
            // Act 
            await _repository.Create(validUser);

            // Assert
            _context.Verify(c => c.SaveChangesAsync(), Times.Once);
        }

        #endregion

        #region Read Operation 

        [TestMethod]
        public async Task Read_ValidId_ReturnsUser()
        {
            // Arrange 
            var expectedUser = _data[0];

            // Act 
            var user = await _repository.Read(1);

            // Assert 
            Assert.AreEqual(expectedUser, user);
        }

        [TestMethod]
        public async Task Read_InvalidId_ReturnsNull() // Handle null in application logic 
        {
            // Arrange and act 
            var user = await _repository.Read(0);

            // Assert 
            Assert.AreEqual(null, user);
        }

        [TestMethod]
        public async Task Read_FindAsync_IsCalled()
        {
            // Arrange and act 
            var user = await _repository.Read(0);

            // Assert 
            _context.Verify(c => c.Users.FindAsync(), Times.Once);
        }

        [TestMethod]
        public void ReadAll_IQueryable_IsCalled()
            // Not async, IQueryable is not executed by db until used by .ToList() 
        {
            // Arrange and act 
            var users = _repository.Read();

            // Assert 
            _context.Verify(c => c.Users.AsQueryable(), Times.Once);
        }

        #endregion

        #region Update Operation

        // TODO handle null in fasade/adapter in layer above 
        //[TestMethod, ExpectedException(typeof (ArgumentNullException))]
        //public async Task Update_NullInput_ExceptionThrown()
        //{
        //    await _repository.UpdateIfExists(null);
        //}

        [TestMethod]
        public async Task Update_FindAsync_IsCalled()
        {
            // Arrange 
            var firstUserUpdated = new StoredUser {Id = 1, Name = "William Parker", MetaData = "Validator"};

            // Act 
            await _repository.UpdateIfExists(firstUserUpdated);

            _mockSet.Setup(t => t.FindAsync(It.IsAny<StoredUser>().Id)).Returns(Task.FromResult(It.IsAny<StoredUser>()));

            // Assert
            _context.Verify(c => c.Users.FindAsync(firstUserUpdated.Id), Times.Once);
        }

        [TestMethod]
        public async Task Update_Attach_IsCalled()
        {
            // Arrange 
            var firstUserUpdated = new StoredUser {Id = 1, Name = "William Parker", MetaData = "Validator"};

            // Act 
            await _repository.UpdateIfExists(firstUserUpdated);

            // Assert
            _context.Verify(c => c.Attach(firstUserUpdated), Times.Once);
        }

        [TestMethod]
        public async Task Update_SetModified_IsCalled()
        {
            // Arrange 
            var firstUserUpdated = new StoredUser {Id = 1, Name = "William Parker", MetaData = "Validator"};

            // Act 
            await _repository.UpdateIfExists(firstUserUpdated);

            // Assert
            _context.Verify(c => c.SetModified(firstUserUpdated), Times.Once);
        }

        [TestMethod]
        public async Task Update_SaveChangesAsync_IsCalled()
        {
            // Arrange 
            var firstUserUpdated = new StoredUser {Id = 1, Name = "William Parker", MetaData = "Validator"};

            // Act 
            await _repository.UpdateIfExists(firstUserUpdated);

            // Assert
            _context.Verify(c => c.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Update_ValidUser_ReturnsTrue()
        {
            // Arrange 
            var firstUserUpdated = new StoredUser {Id = 1, Name = "William Parker", MetaData = "Validator"};

            // Act 
            var isUpdated = await _repository.UpdateIfExists(firstUserUpdated);

            // Assert
            Assert.IsTrue(isUpdated);
        }

        [TestMethod]
        public async Task Update_InvalidUser_ReturnsFalse()
        {
            //Arrange
            var newUser = new StoredUser();

            // Act
            var isUpdated = await _repository.UpdateIfExists(newUser);

            // Assert
            Assert.IsFalse(isUpdated);
        }

        #endregion

        #region Delete Operation

        [TestMethod]
        public async Task Delete_ValidId_ReturnsTrue()
        {
            // Arrange and act 
            var isDeleted = await _repository.DeleteIfExists(1);

            // Assert 
            Assert.IsTrue(isDeleted);
        }

        [TestMethod]
        public async Task Delete_InvalidId_ReturnsFalse()
        {
            // Arrange and act 
            var isDeleted = await _repository.DeleteIfExists(0);

            // Assert 
            Assert.IsFalse(isDeleted);
        }

        // TODO May be replaced by user validation in application logic 
        //[TestMethod, ExpectedException(typeof(ArgumentNullException))] // Assert 
        //public async Task Delete_InvalidUser_ExceptionThrown()
        //{
        //    var user = new StoredUser { } ;
        //    // Arrange and act 
        //    await _repository.DeleteIfExists(user.Id);
        //}

        [TestMethod]
        public async Task Delete_Remove_IsCalled()
        {
            // Arrange and act 
            await _repository.DeleteIfExists(1);

            // Assert
            _context.Verify(c => c.Remove(_data[0]), Times.Once);
        }

        [TestMethod]
        public async Task Delete_SaveChangesAsync_IsCalled()
        {
            // Arrange and act 
            await _repository.DeleteIfExists(1);

            // Assert
            _context.Verify(c => c.SaveChangesAsync(), Times.Once);
        }

        #endregion
    }
}