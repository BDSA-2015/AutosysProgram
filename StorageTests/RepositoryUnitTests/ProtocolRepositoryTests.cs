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
    /// This test class is used to test the Entity Framework ProtocolRepositorys.
    /// The repository is a concrete implementation of the repository interface and is used to write data to a database.
    /// Consequently, Moq is used to allow the tests to verify that the repository writes correctly to the database.
    /// </summary>
    [TestClass]
    public class ProtocolRepositoryTests
    {

        private IList<StoredProtocol> _data;
        private Mock<IAutoSysContext> _context; // Use IUserContext instead of concrete AutoSysDbModel
        private Mock<DbSet<StoredProtocol>> _mockSet;
        private ProtocolRepository _repository;

        /// <summary>
        /// This method sets up data used to mock a collection of protocols in a DbContext used by the ProtocolRepository. 
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {

            _data = new List<StoredProtocol>
            {
                new StoredProtocol { Id = 1, Description = "Year Protocol", InclusionCriteria = new List<StoredCriteria> { }, ExclusionCriteria = new List<StoredCriteria> { } },
                new StoredProtocol { Id = 2, Description = "Year Protocol", InclusionCriteria = new List<StoredCriteria> { }, ExclusionCriteria = new List<StoredCriteria> { } }
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

        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
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
        /// This test uses Moq to create a context and then creates a DbSet of <see cref="StoredProtocol"/>.
        /// This is returned from the context's <see cref="StoredProtocol"/> property. The context is used to create a new <see cref="ProtocolRepository"/>, 
        /// which is then used to create a new <see cref="StoredProtocol"/>, using the Create method. 
        /// Finally, the test verifies that the repository added a new protocol and called SaveChangesAsync on the context.
        /// </summary>
        [TestMethod]
        public async Task Create_SavesUserInContext()
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
        /// Test is true for EF but not for mocked interface that requires setup.
        /// This test is useless because it does not check logic but tests if EF correctly increments id and Mock works.
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
            var protocol = new StoredProtocol { };

            // Act 
            var service = new ProtocolRepository(mockContext.Object);
            var id = await service.Create(protocol);

            // Assert 
            Assert.AreEqual(protocol.Id, id); // True for EF but not for interface 
        }

        [TestMethod]
        public async Task Update_SaveChangesAsync_IsCalled()
        {
            // Arrange
            var protocol = new StoredProtocol { Id = 1 };

            // Act
            await _repository.UpdateIfExists(protocol);

            // Assert
            _context.Verify(r => r.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task Update_SetModified_IsCalled()
        {
            // Arrange 
            var protocol = new StoredProtocol{ Id = 1, Description = "New Description" };

            // Act 
            await _repository.UpdateIfExists(protocol);

            // Assert
            _context.Verify(c => c.SetModified(protocol), Times.Once);
        }

        [TestMethod]
        public async Task Update_SetAttachProtocol_IsCalled()
        {
            // Arrange 
            var protocol = new StoredProtocol { Id = 1, Description = "New Description" };

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
        public async Task GetById()
        {
            var secondProtocol = await _repository.Read(1);
            Assert.AreEqual("Year Protocol", secondProtocol.Description);
        }

    }

}
