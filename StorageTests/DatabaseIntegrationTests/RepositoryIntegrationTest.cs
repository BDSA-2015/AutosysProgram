using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storage;
using Storage.Models;
using Storage.Repository;
using Storage.Repository.Interface;

namespace StorageTests.DatabaseIntegrationTests
{
    /// <summary>
    ///     This class will integration test the repositories with Entity Framework using a test database from in memory supported by the Effort framework. 
    ///     It will be done with a DbContext similar to <see cref="AutoSysDbModel" /> but with a fake connection string.
    /// </summary>
    [TestClass]
    public class RepositoryIntegrationTest
    {
        private IRepository<StoredUser> _repository; 
        private IAutoSysContext _context;
        private DbConnection _connection;

        [TestInitialize]
        public void Initialize()
        {
            _connection = Effort.DbConnectionFactory.CreateTransient(); // Fake connection 
            _context = new AutoSysContext(_connection);
            _repository = new DbRepository<StoredUser>(_context);
        }

        [TestMethod]
        public void GetUser_WithNonExistingId_ReturnsNull()
        {
                // Arrange
                const int nonExistingId = 155;

                // Act
                var user = _repository.Read(nonExistingId);

                // Assert
                Assert.IsNull(user);
        }

        [TestMethod]
        public void InsertUser_ValidUser_UserWasAddedCorrectly()
        {
            // Arrange
            const string name = "William";
            const string metadata = "Researcher";
            var user = new StoredUser {Name = name, MetaData = "Researcher" };

            // Act
            _repository.Create(user);

            // Assert
            _context.Users.Should().HaveCount(1);
            _context.Users.First().Should().NotBeNull();
            _context.Users.First().Name.Should().Be(name);
            _context.Users.First().MetaData.Should().Be(metadata);
        }

        [TestMethod]
        public void GetUser_WithExistingId_ReturnsUser()
        {
            // Arrange
            var user = new StoredUser {Id = 1, Name = "William", MetaData = "Researcher"};
            _repository.Create(user);

            // Act
            var retrievedUser = _repository.Read(user.Id).Result;

            // Assert
            user.Name.Should().Be(retrievedUser.Name);
            user.Id.Should().Be(retrievedUser.Id);
        }

        [TestMethod]
        public async Task InsertTeam_WithUser_SavesUserInDatabase()
        {
            // Arrange
            var user = new StoredUser { Id = 1, Name = "William", MetaData = "Researcher" };

            var team = new StoredTeam
            {
                Id = 1,
                MetaData = "Team data",
                Name = "Team x",
                Users = new List<StoredUser> { user }
            };

            var teamRepository = new TeamRepository(_context);

            // Act 
            await teamRepository.Create(team);


            // Assert
            _context.Teams.Should().HaveCount(1);
            _context.Users.First().Should().NotBeNull(); // Should have created User also 
            _context.Teams.First().Users.Should().NotBeNull();
        }

    }

}

