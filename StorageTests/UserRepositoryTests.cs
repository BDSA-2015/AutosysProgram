using System;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Storage;
using Storage.Models;
using Storage.Repository;
using Storage.Repository.Interface;
using StorageTests.Utility;

namespace StorageTests
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
        private Mock<AutoSysDbModel> _context; // Could use IUserContext instead of concrete AutoSysDbModel
        private Mock<DbSet<StoredUser>> _mockSet;
        private UserRepository _repository;

        /// <summary>
        /// This method sets up data used to mock a collection of users in a DbContext used by the UserRepository. 
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {

            _data = new List<StoredUser>
            {
                new StoredUser { Id = 1, Name = "William Parker", MetaData = "Researcher" },
                new StoredUser { Id = 2, Name = "Trudy Jones", MetaData = "Researcher" }
            };

            _mockSet = MockUtility.CreateAsyncMockDbSet(_data, u => u.Id);

            var mockContext = new Mock<AutoSysDbModel>();
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

        /// <summary>
        /// This test uses Moq to create a context and then creates a DbSet<StoredUser> </StoredUser>.
        /// This is returned from the context's StoredUsers property. The context is used to create a new UserRepository, 
        /// which is then used to create a new Stored User, using the Create method. 
        /// Finally, the test verifies that the repository added a new user and called SaveChangesAsync on the context.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task Create_SavesUserInContext()
        {
            // Arrange 
            var mockSet = new Mock<DbSet<StoredUser>>();

            //var mockContext = new Mock<IUserContext>();
            var mockContext = new Mock<AutoSysDbModel>();
            mockContext.Setup(m => m.Users).Returns(mockSet.Object);

            // Act 
            var service = new UserRepository(mockContext.Object);
            await service.Create(new StoredUser());

            // Assert 
            mockSet.Verify(m => m.Add(It.IsAny<StoredUser>()), Times.Once());
            mockContext.Verify(m => m.SaveChangesAsync(), Times.Once());
        }

        [TestMethod]
        public void Create_SaveChanges_IsCalled()
        {
            Task.Run(async () =>
            {
                var user = new StoredUser();
                await _repository.Create(user);
                _context.Verify(r => r.SaveChangesAsync(), Times.Once);
            });
        }

        // CHECK THIS 
        [TestMethod]
        public async Task Create_ReturnsId_NewId()
        {
            //int result = 0;

            //await Task.Run(async () =>
            //{
                var user = new StoredUser {Name = "Steve", MetaData = "Validator"};
                var id =  await _repository.Create(user);
            //});

            Assert.AreEqual(3, id);
        }

        [TestMethod]
        public void Update_SaveChanges_IsCalled()
        {
            Task.Run(async () =>
            {
                var user = new StoredUser {Id = 1};
                await _repository.Update(user);
                _context.Verify(r => r.SaveChangesAsync(), Times.Once);
            });
        }

        [TestMethod]
        public async Task Update_NewName()
        {
            var user = new StoredUser { Id = 1, Name = "User", MetaData = "Validator" };

            await Task.Run(async () =>
            {
                await _repository.Update(user);
            });

            var researcher = _data[0];

            Assert.AreEqual("User", researcher.Name);
        }

        [TestMethod]
        public void Update_NewMetaData()
        {
            var researcher = _data[0];

            Task.Run(async () =>
            {
                var user = new StoredUser {Id = 1, MetaData = "Validator"};
                await _repository.Update(user);
            });

            Assert.AreEqual("Validator", researcher.MetaData);
        }

        [TestMethod]
        public void Delete_RemovesUser()
        {
            var user = _data[0];

            Task.Run(async () =>
            {
                await _repository.Delete(user);
            });

            Assert.IsFalse(_data.Any(u => u.Id == 1));
        }

        [TestMethod]
        public void Delete_SaveChanges_IsCalled()
        {
            Task.Run(async () =>
            {
                var user = _data[0];
                await _repository.Delete(user);
                _context.Verify(repo => repo.SaveChangesAsync(), Times.Once);
            });  
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
