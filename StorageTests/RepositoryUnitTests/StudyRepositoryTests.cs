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
    ///     This test class is used to test the Entity Framework StudyRepository, <see cref="StudyRepository" />.
    ///     The repository is a concrete implementation of the repository interface and is used to write data to a database.
    ///     Consequently, Moq is used to allow the tests to verify that the repository writes correctly to the database.
    /// </summary>
    [TestClass]
    public class StudyRepositoryTests
    {
        private Mock<IAutoSysContext> _context; // Use IAutoSysContext instead of concrete AutoSysDbModel

        private IList<StoredStudy> _data;
        private Mock<DbSet<StoredStudy>> _mockSet;
        private StudyRepository _repository;

        /// <summary>
        ///     This method sets up data used to mock a collection of studies in a DbContext used by the StudyRepository,
        ///     <see cref="StudyRepository" />.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _data = new List<StoredStudy>
            {
                new StoredStudy {Id = 1}, // Todo insert pseudo data 
                new StoredStudy {Id = 2}
            };

            _mockSet = MockUtility.CreateAsyncMockDbSet(_data, u => u.Id);

            var mockContext = new Mock<IAutoSysContext>();
            mockContext.Setup(s => s.Studies).Returns(_mockSet.Object);
            mockContext.Setup(s => s.Set<StoredStudy>()).Returns(_mockSet.Object);
            mockContext.Setup(s => s.SaveChangesAsync()).Returns(Task.Run(() =>
            {
                // Increment user ids automatically based on existing ids in mock data 
                var max = _data.Max(u => u.Id);
                foreach (var study in _data.Where(u => u.Id == 0))
                {
                    study.Id = ++max;
                }
                return 1; // SaveChangesAsync returns number based on how many times it was called per default 
            }));

            _context = mockContext;
            _repository = new StudyRepository(_context.Object);
        }

        #region Create Operation 

        [TestMethod, ExpectedException(typeof (ArgumentNullException))] // Assert 
        public async Task Create_NullInput_ExceptionThrown()
        {
            // Arrange and act 
            await _repository.Create(null);
        }

        [TestMethod]
        public async Task Create_Add_IsCalled()
        {
            // Arrange
            var validStudy = new StoredStudy {Id = 0};

            // Act 
            await _repository.Create(validStudy);

            // Assert
            _context.Verify(c => c.Add(validStudy), Times.Once);
        }

        [TestMethod]
        public async Task Create_SaveChangesAsync_IsCalled()
        {
            // Arrange
            var validStudy = new StoredStudy();
            // Act 
            await _repository.Create(validStudy);

            // Assert
            _context.Verify(c => c.SaveChangesAsync(), Times.Once);
        }

        #endregion

        #region Read Operation 

        [TestMethod]
        [Ignore]
        public async Task Read_ValidId_ReturnsStudy()
        {
            // Arrange 
            var expectedStudy = _data[0];

            // Act 
            var user = await _repository.Read(1);

            // Assert 
            Assert.AreEqual(expectedStudy, user);
        }

        [TestMethod]
        public async Task Read_InvalidId_ReturnsNull() // Handle null in application logic 
        {
            // Arrange and act 
            var study = await _repository.Read(0);

            // Assert 
            Assert.AreEqual(null, study);
        }

        [TestMethod]
        public async Task Read_FindAsync_IsCalled()
        {
            // Arrange
            _context.Setup(c => c.Read<StoredStudy>(0))
                .Returns(Task.FromResult(It.IsAny<StoredStudy>()));

            // Act 
            await _repository.Read(0);

            // Assert 
            _context.Verify(c => c.Read<StoredStudy>(0), Times.Once);
        }

        [TestMethod]
        public void ReadAll_IQueryable_IsCalled()
            // Not async, IQueryable is not executed by db until used by .ToList() 
        {
            // Arrange and act 
            var studies = _repository.Read();

            // Assert 
            _context.Verify(c => c.Read<StoredStudy>(), Times.Once);
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
            var firstStudyUpdated = new StoredStudy {Id = 1, Description = "New Study"};
            _mockSet.Setup(t => t.FindAsync(1))
                .Returns(Task.FromResult(It.IsAny<StoredStudy>()));

            // Act 
            await _repository.UpdateIfExists(firstStudyUpdated);

            // Assert
            _mockSet.Verify(m => m.FindAsync(1), Times.Once);
        }

        [TestMethod]
        public async Task Update_Attach_IsCalled()
        {
            // Arrange 
            var firstStudyUpdated = new StoredStudy {Id = 1, Description = "New Study"};

            // Act 
            await _repository.UpdateIfExists(firstStudyUpdated);

            // Assert
            _context.Verify(c => c.Attach(firstStudyUpdated), Times.Once);
        }

        [TestMethod]
        [Ignore]
        public async Task Update_SetModified_IsCalled()
        {
            // Arrange 
            var firstStudyUpdated = new StoredStudy {Id = 1, Description = "New Study"};

            // Act 
            await _repository.UpdateIfExists(firstStudyUpdated);

            // Assert
            _context.Verify(c => c.SetModified(firstStudyUpdated), Times.Once);
        }

        [TestMethod]
        public async Task Update_SaveChangesAsync_IsCalled()
        {
            // Arrange 
            var firstStudyUpdated = new StoredStudy {Id = 1, Description = "New Study"};

            // Act 
            await _repository.UpdateIfExists(firstStudyUpdated);

            // Assert
            _context.Verify(c => c.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Update_ValidUser_ReturnsTrue()
        {
            // Arrange 
            var firstStudyUpdated = new StoredStudy {Id = 1, Description = "New Study"};

            // Act 
            var isUpdated = await _repository.UpdateIfExists(firstStudyUpdated);

            // Assert
            Assert.IsTrue(isUpdated);
        }

        [TestMethod]
        public async Task Update_InvalidStudy_ReturnsFalse()
        {
            //Arrange
            var newStudy = new StoredStudy();

            // Act
            var isUpdated = await _repository.UpdateIfExists(newStudy);

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
        //public async Task Delete_InvalidStudy_ExceptionThrown()
        //{
        //    var study = new StoredStudy { } ;
        //    // Arrange and act 
        //    await _repository.DeleteIfExists(study.Id);
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