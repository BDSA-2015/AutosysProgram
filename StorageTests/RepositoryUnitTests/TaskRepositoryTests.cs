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
    ///     This test class is used to test the Entity Framework TaskRepository, <see cref="TaskRepository" />.
    ///     The repository is a concrete implementation of the repository interface and is used to write data to a database.
    ///     Consequently, Moq is used to allow the tests to verify that the repository writes correctly to the database.
    /// </summary>
    [TestClass]
    public class TaskRepositoryTests
    {
        private Mock<IAutoSysContext> _context; // Use IAutoSysContext instead of concrete AutoSysDbModel

        private IList<StoredTaskRequest> _data;
        private Mock<DbSet<StoredTaskRequest>> _mockSet;
        private TaskRepository _repository;

        /// <summary>
        ///     This method sets up data used to mock a collection of studies in a DbContext used by the TaskRepository,
        ///     <see cref="TaskRepository" />.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _data = new List<StoredTaskRequest>
            {
                new StoredTaskRequest {Id = 1}, // Todo insert pseudo data 
                new StoredTaskRequest {Id = 2}
            };

            _mockSet = MockUtility.CreateAsyncMockDbSet(_data, u => u.Id);

            var mockContext = new Mock<IAutoSysContext>();
            mockContext.Setup(s => s.Tasks).Returns(_mockSet.Object);
            mockContext.Setup(s => s.Set<StoredTaskRequest>()).Returns(_mockSet.Object);
            mockContext.Setup(s => s.SaveChangesAsync()).Returns(Task.Run(() =>
            {
                // Increment user ids automatically based on existing ids in mock data 
                var max = _data.Max(u => u.Id);
                foreach (var task in _data.Where(u => u.Id == 0))
                {
                    task.Id = ++max;
                }
                return 1; // SaveChangesAsync returns number based on how many times it was called per default 
            }));

            _context = mockContext;
            _repository = new TaskRepository(_context.Object);
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
            var validTask = new StoredTaskRequest {Id = 0};

            // Act 
            await _repository.Create(validTask);

            // Assert
            _context.Verify(c => c.Attach(validTask), Times.Once);
        }

        [TestMethod]
        public async Task Create_Add_IsCalled()
        {
            // Arrange
            var validTask = new StoredTaskRequest {Id = 0};

            // Act 
            await _repository.Create(validTask);

            // Assert
            _context.Verify(c => c.Add(validTask), Times.Once);
        }

        [TestMethod]
        public async Task Create_SaveChangesAsync_IsCalled()
        {
            // Arrange
            var validTask = new StoredTaskRequest();
            // Act 
            await _repository.Create(validTask);

            // Assert
            _context.Verify(c => c.SaveChangesAsync(), Times.Once);
        }

        #endregion

        #region Read Operation 

        [TestMethod]
        [Ignore]
        public async Task Read_ValidId_ReturnsTask()
        {
            // Arrange 
            var expectedTask = _data[0];

            // Act 
            var task = await _repository.Read(1);

            // Assert 
            Assert.AreEqual(expectedTask, task);
        }

        [TestMethod]
        public async Task Read_InvalidId_ReturnsNull() // Handle null in application logic 
        {
            // Arrange and act 
            var task = await _repository.Read(0);

            // Assert 
            Assert.AreEqual(null, task);
        }

        [TestMethod]
        public async Task Read_FindAsync_IsCalled()
        {
            // Arrange
            _context.Setup(c => c.Read<StoredTaskRequest>(0))
                .Returns(Task.FromResult(It.IsAny<StoredTaskRequest>()));

            // Act 
            await _repository.Read(0);

            // Assert 
            _context.Verify(c => c.Read<StoredTaskRequest>(0), Times.Once);
        }

        [TestMethod]
        public void ReadAll_IQueryable_IsCalled()
            // Not async, IQueryable is not executed by db until used by .ToList() 
        {
            // Arrange and act 
            var tasks = _repository.Read();

            // Assert 
            _context.Verify(c => c.Read<StoredTaskRequest>(), Times.Once);
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
            var firstTaskUpdated = new StoredTaskRequest {Id = 1, Description = "New Task"};
            _mockSet.Setup(t => t.FindAsync(1))
                .Returns(Task.FromResult(It.IsAny<StoredTaskRequest>()));

            // Act 
            await _repository.UpdateIfExists(firstTaskUpdated);

            // Assert
            _mockSet.Verify(m => m.FindAsync(1), Times.Once);
        }

        [TestMethod]
        public async Task Update_Attach_IsCalled()
        {
            // Arrange 
            var firstTaskUpdated = new StoredTaskRequest {Id = 1, Description = "New Task"};

            // Act 
            await _repository.UpdateIfExists(firstTaskUpdated);

            // Assert
            _context.Verify(c => c.Attach(firstTaskUpdated), Times.Once);
        }

        [TestMethod]
        public async Task Update_SetModified_IsCalled()
        {
            // Arrange 
            var firstTaskUpdated = new StoredTaskRequest {Id = 1, Description = "New Task"};
                // Todo move to test initialize 

            // Act 
            await _repository.UpdateIfExists(firstTaskUpdated); // 

            // Assert
            _context.Verify(c => c.SetModified(firstTaskUpdated), Times.Once);
        }

        [TestMethod]
        public async Task Update_SaveChangesAsync_IsCalled()
        {
            // Arrange 
            var firstTaskUpdated = new StoredTaskRequest {Id = 1, Description = "New Task"};

            // Act 
            await _repository.UpdateIfExists(firstTaskUpdated);

            // Assert
            _context.Verify(c => c.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Update_ValidUser_ReturnsTrue()
        {
            // Arrange 
            var firstTaskUpdated = new StoredTaskRequest {Id = 1, Description = "New Task"};

            // Act 
            var isUpdated = await _repository.UpdateIfExists(firstTaskUpdated);

            // Assert
            Assert.IsTrue(isUpdated);
        }

        [TestMethod]
        public async Task Update_InvalidTask_ReturnsFalse()
        {
            //Arrange
            var newTask = new StoredTaskRequest();

            // Act
            var isUpdated = await _repository.UpdateIfExists(newTask);

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
        //public async Task Delete_InvalidTask_ExceptionThrown()
        //{
        //    var task = new StoredTaskRequest { } ;
        //    // Arrange and act 
        //    await _repository.DeleteIfExists(task.Id);
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