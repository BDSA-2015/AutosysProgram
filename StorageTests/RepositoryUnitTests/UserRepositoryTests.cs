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
    /// This test class is used to test the Entity Framework UserRepository, <see cref="UserRepository"/>.
    /// The repository is a concrete implementation of the repository interface and is used to write data to a database.
    /// Consequently, Moq is used to allow the tests to verify that the repository writes correctly to the database.
    /// </summary>
    [TestClass]
    public class UserRepositoryTests
    {

        private IList<StoredUser> _data;
        private Mock<IAutoSysContext> _context; // Use IUserContext instead of concrete AutoSysDbModel
        private Mock<DbSet<StoredUser>> _mockSet;
        private UserRepository _repository;

        /// <summary>
        /// This method sets up data used to mock a collection of users in a DbContext used by the UserRepository, <see cref="UserRepository"/>. 
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
            mockContext.Setup(s => s.SaveChangesAsync()).Callback(() =>
            {
                        // Increment user ids automatically based on existing ids in mock data 
                        var max = _data.Max(u => u.Id);
                foreach (var user in _data.Where(u => u.Id == 0))
                {
                    user.Id = ++max;
                }
            });

            _context = mockContext;
            _repository = new UserRepository(_context.Object);
        }

        // Null input 

        #region Create Operation 

        [TestMethod, ExpectedException(typeof(ArgumentNullException))] // Assert 
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
            var validUser = new StoredUser { Id = 0, Name = "Steven", MetaData = "Researcher" };

            // Act 
            await _repository.Create(validUser);

            // Assert
            _context.Verify(c => c.Add(validUser), Times.Once);

        }

        [TestMethod]
        public async Task Create_SaveChangesAsync_IsCalled()
        {
            // Arrange
            var validUser = new StoredUser { Id = 0, Name = "Steven", MetaData = "Researcher" };

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
        public void ReadAll_IQueryable_IsCalled() // Not async, IQueryable is not executed by db until used by .ToList() 
        {
            // Arrange and act 
            var users = _repository.Read();

            // Assert 
            _context.Verify(c => c.Set<StoredUser>().AsQueryable(), Times.Once);
        }

        #endregion

        #region Update Operation

        [TestMethod, ExpectedException(typeof (ArgumentNullException))]
        public async Task Update_NullInput_ExceptionThrown()
        {
            await _repository.UpdateIfExists(null);
        }

        [TestMethod]
        public async Task Update_FindAsync_IsCalled()
        {
            // Arrange 
            var firstUserUpdated = new StoredUser {Id = 1, Name = "William Parker", MetaData = "Validator"};
            
            // Act 
            await _repository.UpdateIfExists(firstUserUpdated);

            // Assert
            _context.Verify(c => c.Users.FindAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Update_Attach_IsCalled()
        {
            // Arrange 
            var firstUserUpdated = new StoredUser { Id = 1, Name = "William Parker", MetaData = "Validator" };

            // Act 
            await _repository.UpdateIfExists(firstUserUpdated);

            // Assert
            _context.Verify(c => c.Users.FindAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Update_SetModified_IsCalled()
        {
            // Arrange 
            var firstUserUpdated = new StoredUser { Id = 1, Name = "William Parker", MetaData = "Validator" };

            // Act 
            await _repository.UpdateIfExists(firstUserUpdated);

            // Assert
            _context.Verify(c => c.Users.FindAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Update_SaveChangesAsync_IsCalled()
        {

        }

        [TestMethod]
        public async Task Update_ValidUpdate_ReturnsTrue()
        {

        }

        [TestMethod]
        public async Task Update_ValidUpdate_ReturnsFalse()
        {

        }

        //public async Task<bool> UpdateIfExists(StoredUser user)
        //{
        //    if (user == null) throw new ArgumentNullException(nameof(user));

        //    var userToUpdate = await _dbContext.Set<StoredUser>().FindAsync(user.Id);

        //    if (userToUpdate != null)
        //    {
        //        _dbContext.Attach(user); // Used for mocking 
        //        //_dbContext.Set<T>().Attach(user);
        //        _dbContext.SetModified(user); // Used for mocking 
        //        //dbContext.Entry<T>(user).State = EntityState.Modified; 
        //        await _dbContext.SaveChangesAsync();
        //        return true;
        //    }
        //    else return false;

        #endregion

        #region Delete Operation

        [TestMethod]
        public async Task Delete_ValidId_ReturnsTrue()
        {

        }

        [TestMethod]
        public async Task Delete_InvalidId_ReturnsFalse()
        {

        }

        [TestMethod]
        public async Task Delete_InvalidNullUser_ExceptionThrown()
        {

        }

        [TestMethod]
        public async Task Delete_Remove_IsCalled()
        {

        }

        [TestMethod]
        public async Task Delete_SaveChangesAsync_IsCalled()
        {

        }

        //public async Task<bool> DeleteIfExists(int id)
        //{
        //    var userToDelete = await _dbContext.Set<StoredUser>().FindAsync(id);

        //    if (userToDelete != null)
        //    {
        //        _dbContext.Set<StoredUser>().Remove(userToDelete);
        //        await _dbContext.SaveChangesAsync();
        //        return true;
        //    }
        //    else return false;
        //}

        #endregion


    }

}
