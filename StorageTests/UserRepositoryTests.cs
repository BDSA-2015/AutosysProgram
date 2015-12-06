using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using Storage;
using Storage.Models;
using Storage.Repository;
using Storage.Repository.Interface;

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
        private Mock<AutoSysDbModel> _context; // Interface instead of concrete AutoSysDbModel
        private Mock<DbSet<StoredUser>> _set;
        private UserRepository _repository;

        [TestInitialize]
        public void Initialize()
        {

            _data = new List<StoredUser>
            {
                new StoredUser { Id = 1, Name = "William Parker", MetaData = "Researcher" },
                new StoredUser { Id = 2, Name = "Trudy Jones", MetaData = "Researcher" }
            };

            _set = MockUtility.CreateMockDbSet(_data, u => u.Id);
            var context = new Mock<AutoSysDbModel>();
            context.Setup(s => s.Users).Returns(_set.Object);
            context.Setup(s => s.SaveChanges()).Callback(() =>
            {
                var max = _data.Max(u => u.Id);
                foreach (var user in _data.Where(u => u.Id == 0))
                {
                    user.Id = ++max;
                }
            });

            _context = context;
            _repository = new UserRepository(_context.Object);
        }

        [TestMethod]
        public void Create_SaveChanges_IsCalled()
        {
            var user = new StoredUser();
            _repository.Create(user);
            _context.Verify(r => r.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Create_ReturnsId_NewId()
        {
            var user = new StoredUser { Name = "Steve", MetaData = "Validator" };
            var id = _repository.Create(user);
            Assert.AreEqual(3, id);
        }

        [TestMethod]
        public void Update_SaveChanges_IsCalled()
        {
            var user = new StoredUser { Id = 1 };
            _repository.Update(user);
            _context.Verify(r => r.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Update_NewName()
        {
            var user = new StoredUser {Id = 1, Name = "User"};
            _repository.Update(user);
            var researcher = _data[0];
            Assert.AreEqual("User", researcher.Name);
        }

        [TestMethod]
        public void Update_NewMetaData()
        {
            var user = new StoredUser { Id = 1, MetaData = "Validator" };
            _repository.Update(user);
            var researcher = _data[0];
            Assert.AreEqual("Validator", researcher.MetaData);
        }

        [TestMethod]
        public void Delete_RemovesUser()
        {
            var user = _data[0];
            _repository.Delete(user);
            Assert.IsFalse(_data.Any(u => u.Id == 1));
        }

        [TestMethod]
        public void Delete_SaveChanges_IsCalled()
        {
            var user = _data[0];
            _repository.Delete(user);
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
            {
                var roles = repository.Get('W').ToList();
                Assert.AreEqual("William Parker", roles[0].Name);
            }
        }
        */

    }

}
