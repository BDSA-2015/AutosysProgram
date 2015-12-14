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
    ///     This test class is used to test the Entity Framework ProtocolRepositorys.
    ///     The repository is a concrete implementation of the repository interface and is used to write data to a database.
    ///     Consequently, Moq is used to allow the tests to verify that the repository writes correctly to the database.
    /// </summary>
    [TestClass]
    public class ProtocolRepositoryTests
    {
        private Mock<IAutoSysContext> _context; // Use IAutoSys instead of concrete AutoSysDbModel

        private IList<StoredProtocol> _data;
        private Mock<DbSet<StoredProtocol>> _mockSet;
        private ProtocolRepository _repository;

        /// <summary>
        ///     This method sets up data used to mock a collection of protocols in a DbContext used by the ProtocolRepository.
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            _data = new List<StoredProtocol>
            {
                new StoredProtocol {Id = 1, Description = "Year Protocol"}, // TODO add phases
                new StoredProtocol {Id = 2, Description = "Year Protocol"}
            };

            _mockSet = MockUtility.CreateAsyncMockDbSet(_data, u => u.Id);

            var mockContext = new Mock<IAutoSysContext>();
            mockContext.Setup(s => s.Protocols).Returns(_mockSet.Object);
            mockContext.Setup(s => s.Set<StoredProtocol>()).Returns(_mockSet.Object);
            mockContext.Setup(s => s.SaveChangesAsync()).Returns(Task.Run(() =>
            {
                // Increment protocol ids automatically based on existing ids in mock data 
                var max = _data.Max(u => u.Id);
                foreach (var protocol in _data.Where(u => u.Id == 0))
                {
                    protocol.Id = ++max;
                }
                return 1; // SaveChangesAsync returns number based on how many times it was called per default 
            }));

            _context = mockContext;
            _repository = new ProtocolRepository(_context.Object);
        }

        #region Old Tests 

        [TestMethod, ExpectedException(typeof (ArgumentNullException))]
        public async Task Create_NullException()
        {
            await _repository.Create(null);
        }

        [TestMethod]
        public async Task Create_SaveChanged_IsCalled()
        {
            // Arrange 
            var protocol = new StoredProtocol();

            // Act 
            var id = await _repository.Create(protocol);

            // Assert
            _context.Verify(c => c.SaveChangesAsync(), Times.Once);
        }

        /// <summary>
        ///     This test uses Moq to create a context and then creates a DbSet of <see cref="StoredProtocol" />.
        ///     This is returned from the context's <see cref="StoredProtocol" /> property. The context is used to create a new
        ///     <see cref="ProtocolRepository" />,
        ///     which is then used to create a new <see cref="StoredProtocol" />, using the Create method.
        ///     Finally, the test verifies that the repository added a new protocol and called SaveChangesAsync on the context.
        /// </summary>
        [TestMethod]
        public async Task Create_SavesProtocolInContext()
        {
            // Arrange 
            var mockSet = new Mock<DbSet<StoredProtocol>>();
            var mockContext = new Mock<IAutoSysContext>();
            mockContext.Setup(m => m.Protocols).Returns(mockSet.Object);

            // Act 
            var service = new ProtocolRepository(mockContext.Object);
            var id = await service.Create(new StoredProtocol());

            // Assert 
            // mockSet.Verify(m => m.Add(It.IsAny<StoredProtocol>()), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());
        }

        [TestMethod]
        public void Create_SaveChanges_IsCalled()
        {
            // Arrange 
            var protocol = new StoredProtocol();

            // Act 
            var id = _repository.Create(protocol);

            // Assert
            _context.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        /// <summary>
        ///     Test is true for EF but not for mocked interface that requires setup.
        ///     This test is useless because it does not check logic but tests if EF correctly increments id and Mock works.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        [Ignore]
        public async Task Create_ReturnsId_NewId()
        {
            // Arrange 
            var mockSet = new Mock<DbSet<StoredProtocol>>();
            var mockContext = new Mock<IAutoSysContext>();

            mockContext.Setup(m => m.Protocols).Returns(mockSet.Object);
            var protocol = new StoredProtocol();

            // Act 
            var service = new ProtocolRepository(mockContext.Object);
            var id = await service.Create(protocol);

            // Assert 
            Assert.AreEqual(protocol.Id, id); // True for EF but not for interface 
        }

        [TestMethod]
        public async Task Update_SetAttachProtocol_IsCalled()
        {
            // Arrange 
            var protocol = new StoredProtocol {Id = 1, Description = "New Description"};

            // Act 
            await _repository.UpdateIfExists(protocol);

            // Assert
            _context.Verify(c => c.Attach(protocol), Times.Once);
        }

        [TestMethod]
        public async Task Delete_RemoveProtocol_IsRemoved()
        {
            // Arrange 
            var protocol = _data[0];

            // Act 
            var id = await _repository.DeleteIfExists(protocol.Id);

            // Assert
            Assert.IsFalse(_data.Any(p => p.Id == 1));
        }

        [TestMethod]
        public async Task Delete_SaveChanges_IsCalled()
        {
            // Arrange
            var protocol = _data[0];

            // Act
            await _repository.DeleteIfExists(protocol.Id);

            // Assert
            _context.Verify(repo => repo.SaveChangesAsync(), Times.Once);
        }


        [TestMethod]
        [Ignore]
        public async Task GetById()
        {
            var secondProtocol = await _repository.Read(1);
            Assert.AreEqual("Year Protocol", secondProtocol.Description);
        }

        #endregion

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
            var validProtocol = new StoredProtocol {Id = 0};

            // Act 
            await _repository.Create(validProtocol);

            // Assert
            _context.Verify(c => c.Attach(validProtocol), Times.Once);
        }

        [TestMethod]
        public async Task Create_Add_IsCalled()
        {
            // Arrange
            var validProtocol = new StoredProtocol {Id = 0};

            // Act 
            await _repository.Create(validProtocol);

            // Assert
            _context.Verify(c => c.Add(validProtocol), Times.Once);
        }

        [TestMethod]
        public async Task Create_SaveChangesAsync_IsCalled()
        {
            // Arrange
            var validProtocol = new StoredProtocol();
            // Act 
            await _repository.Create(validProtocol);

            // Assert
            _context.Verify(c => c.SaveChangesAsync(), Times.Once);
        }

        #endregion

        #region Read Operation 

        [TestMethod]
        [Ignore]
        public async Task Read_ValidId_ReturnsProtocol()
        {
            // Arrange 
            var expectedProtocol = _data[0];

            // Act 
            var protocol = await _repository.Read(1);

            // Assert 
            Assert.AreEqual(expectedProtocol, protocol);
        }

        [TestMethod]
        public async Task Read_InvalidId_ReturnsNull() // Handle null in application logic 
        {
            // Arrange and act 
            var protocol = await _repository.Read(0);

            // Assert 
            Assert.AreEqual(null, protocol);
        }

        [TestMethod]
        public async Task Read_FindAsync_IsCalled()
        {
            // Arrange
            _context.Setup(c => c.Read<StoredProtocol>(0))
                .Returns(Task.FromResult(It.IsAny<StoredProtocol>()));

            // Act 
            await _repository.Read(0);

            // Assert 
            _context.Verify(c => c.Read<StoredProtocol>(0), Times.Once);
        }

        [TestMethod]
        public void ReadAll_IQueryable_IsCalled() // Not async, IQueryable is not executed by db until used by .ToList() 
        {
            // Arrange and act 
            var protocols = _repository.Read();

            // Assert 
            _context.Verify(c => c.Read<StoredProtocol>(), Times.Once);
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
            var firstProtocolUpdated = new StoredProtocol {Id = 1, Description = "New Protocol"};
            _mockSet.Setup(t => t.FindAsync(1))
                .Returns(Task.FromResult(It.IsAny<StoredProtocol>()));


            // Act 
            await _repository.UpdateIfExists(firstProtocolUpdated);

            // Assert
            _mockSet.Verify(m => m.FindAsync(1), Times.Once);
        }

        [TestMethod]
        public async Task Update_Attach_IsCalled()
        {
            // Arrange 
            var firstStudyUpdated = new StoredProtocol {Id = 1, Description = "New Protocol"};

            // Act 
            await _repository.UpdateIfExists(firstStudyUpdated);

            // Assert
            _context.Verify(c => c.Attach(firstStudyUpdated), Times.Once);
        }

        [TestMethod]
        public async Task Update_SetModified_IsCalled()
        {
            // Arrange 
            var firstProtocolUpdated = new StoredProtocol {Id = 1, Description = "New Protocol"};

            // Act 
            await _repository.UpdateIfExists(firstProtocolUpdated);

            // Assert
            _context.Verify(c => c.SetModified(firstProtocolUpdated), Times.Once);
        }

        [TestMethod]
        public async Task Update_SaveChangesAsync_IsCalled()
        {
            // Arrange 
            var firstProtocolUpdated = new StoredProtocol {Id = 1, Description = "New Protocol"};

            // Act 
            await _repository.UpdateIfExists(firstProtocolUpdated);

            // Assert
            _context.Verify(c => c.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Update_ValidProtocol_ReturnsTrue()
        {
            // Arrange 
            var firstProtocolUpdated = new StoredProtocol {Id = 1, Description = "New Protocol"};

            // Act 
            var isUpdated = await _repository.UpdateIfExists(firstProtocolUpdated);

            // Assert
            Assert.IsTrue(isUpdated);
        }

        [TestMethod]
        public async Task Update_InvalidUser_ReturnsFalse()
        {
            //Arrange
            var newProtocol = new StoredProtocol();

            // Act
            var isUpdated = await _repository.UpdateIfExists(newProtocol);

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