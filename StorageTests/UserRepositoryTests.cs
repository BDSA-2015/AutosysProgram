using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using Storage;
using Storage.Models;
using Storage.Repository;

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
        private Mock<IUserContext> _context; // Interface instead of concrete AutoSysDbModel
        private Mock<DbSet<StoredUser>> _set;
        private UserRepository _repository;

        [TestInitialize]
        public void Initialize()
        {

            _data = new List<StoredUser>
            {
                new StoredUser { Id = 1, Name = "William Parker", MetaData = "Researcher" }
            };

            _set = MockUtility.CreateMockDbSet(_data, u => u.Id);
            var context = new Mock<IUserContext>();
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
        public void TestMethod1()
        {

        }

    }

}
