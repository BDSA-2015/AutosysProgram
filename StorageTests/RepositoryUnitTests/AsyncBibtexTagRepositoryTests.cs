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
    ///     This test class is used to test the Entity Framework Async DbRepository used by all repositories.
    ///     The repository is a concrete implementation of the async IRepository interface and is used to write data to a
    ///     database.
    ///     Consequently, Moq is used to allow the tests to verify that the BibtexTag repository writes correctly to the database.
    /// </summary>
    [TestClass()]
    public class AsyncBibtexTagRepositoryTests
    {
        private Mock<IAutoSysContext> _context; // Use IUserContext instead of concrete AutoSysDbModel

        private IList<StoredBibtexTag> _data;
        private Mock<DbSet<StoredBibtexTag>> _mockSet;
        private DbRepository<StoredBibtexTag> _repository;

        /// <summary>
        ///     This method sets up data used to mock a collection of BibtexTags in a DbContext used by the BibtexTagRepository.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _data = new List<StoredBibtexTag>
            {
                new StoredBibtexTag {Id = 1, Type = "article"},
                new StoredBibtexTag() {Id = 2, Type = "author"}
            };

            _mockSet = MockUtility.CreateAsyncMockDbSet(_data, u => u.Id);

            var mockContext = new Mock<IAutoSysContext>();
            mockContext.Setup(s => s.BibtexTags).Returns(_mockSet.Object);
            mockContext.Setup(s => s.Set<StoredBibtexTag>()).Returns(_mockSet.Object);
            mockContext.Setup(s => s.SaveChangesAsync()).Returns(Task.Run(() =>
            {
                // Increment user ids automatically based on existing ids in mock data 
                var max = _data.Max(u => u.Id);
                foreach (var tag in _data.Where(u => u.Id == 0))
                {
                    tag.Id = ++max;
                }
                return 1; // SaveChangesAsync returns number based on how many times it was called per default 
            }));

            _context = mockContext;
            _repository = new DbRepository<StoredBibtexTag>(_context.Object);
        }

    #region Create Operation

        [TestMethod(), ExpectedException(typeof(ArgumentNullException))]
        public async void Create_NullInput_ExceptionThrown()
        {
            await _repository.Create(null);
        }

        [TestMethod]
        public async Task Create_Add_IsCalled()
        {
            // Arrange
            var validTag = new StoredBibtexTag { Id = 0 };

            // Act 
            await _repository.Create(validTag);

            // Assert
            _context.Verify(c => c.Add(validTag), Times.Once);
        }

        [TestMethod]
        public async Task Create_SaveChangesAsync_IsCalled()
        {
            // Arrange
            var validTag = new StoredBibtexTag();
            // Act 
            await _repository.Create(validTag);

            // Assert
            _context.Verify(c => c.SaveChangesAsync(), Times.Once);
        }

        #endregion

    #region Read Operation

        [TestMethod]
        [Ignore]
        public async Task Read_ValidId_ReturnsBibtexTag()
        {
            // Arrange 
            var expectedTag = _data[0];

            // Act 
            var tag = await _repository.Read(1);

            // Assert 
            Assert.AreEqual(expectedTag, tag);
        }

        [TestMethod]
        public async Task Read_InvalidId_ReturnsNull() // Handle null in application logic 
        {
            // Arrange and act 
            var tag = await _repository.Read(0);

            // Assert 
            Assert.AreEqual(null, tag);
        }

        [TestMethod]
        public async Task Read_FindAsync_IsCalled()
        {
            // Arrange
            _context.Setup(c => c.Read<StoredBibtexTag>(0))
                .Returns(Task.FromResult(It.IsAny<StoredBibtexTag>()));

            // Act 
            await _repository.Read(0);

            // Assert 
            _context.Verify(c => c.Read<StoredBibtexTag>(0), Times.Once);
        }

        [TestMethod]
        public void ReadAll_IQueryable_IsCalled()
        // Not async, IQueryable is not executed by db until used by .ToList() 
        {
            // Arrange and act 
            var tags = _repository.Read();

            // Assert 
            _context.Verify(c => c.Read<StoredBibtexTag>(), Times.Once);
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