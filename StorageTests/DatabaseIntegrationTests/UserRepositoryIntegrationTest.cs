using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Validation;
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
    ///     This class is used to integration test the User repository, StoredUser entity and database with Entity Framework.
    ///     For this purpose, a test database is setup from in memory using the Effort framework. 
    ///     It will be done with a DbContext similar to <see cref="AutoSysDbModel" /> but with a fake connection string.
    /// </summary>
    [TestClass]
    public class UserRepositoryIntegrationTest
    {
        private IRepository<StoredUser> _repository; 
        private IAutoSysContext _context;
        private DbConnection _connection;

        [TestInitialize]
        public void Initialize()
        {
            _connection = Effort.DbConnectionFactory.CreateTransient(); // Fake connection 
            _context = new AutoSysContext(_connection);
            _repository = new UserRepository(_context);
            //_repository = new DbRepository<StoredUser>(_context);
        }

        /// <summary>
        /// Tests if a non-existant user does not return any user. 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetUser_WithNonExistingId_ReturnsNull()
        {
                // Arrange
                const int nonExistingId = 155;

                // Act
                var user = await _repository.Read(nonExistingId);

                // Assert
                Assert.IsNull(user);
        }

        /// <summary>
        /// Tests if the repository correctly avoids creating users from invalid user information (null). 
        /// </summary>
        /// <returns></returns>
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public async Task CreateUser_Null_ErrorThrown()
        {
            // Arrange 
            var user = new StoredUser {Name = "William", MetaData = "Researcher"};

            // Act 
            await _repository.Create(null);

            _context.Users.Should().HaveCount(0);
            _context.Users.First().Should().Be(null);
        }

        /// <summary>
        /// Tests if a given user is added correctly to the database. 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task InsertUser_ValidUser_UserWasAddedCorrectly()
        {
            // Arrange
            const string name = "William";
            const string metadata = "Researcher";
            var user = new StoredUser { Name = name, MetaData = "Researcher" };

            // Act
            await _repository.Create(user);

            // Assert
            _context.Users.Should().HaveCount(1);
            _context.Users.First().Should().NotBeNull();
            _context.Users.First().Name.Should().Be(name);
            _context.Users.First().MetaData.Should().Be(metadata);
        }

        [TestMethod, ExpectedException(typeof(DbEntityValidationException))] // Assert 
        public async Task InsertUser_InvalidUser_RequiredNameMissing()
        {
            // Arrange
            var user = new StoredUser { MetaData = "Researcher" };

            // Act
            await _repository.Create(user);

            // Assert
            _context.Users.Should().HaveCount(0);
            _context.Users.First().Should().BeNull();
            _context.Users.First().Name.Should().Be(null);
            _context.Users.First().MetaData.Should().Be(null);
        }

        [TestMethod]
        public async Task InsertUser_ValidNameLengthBelowLimit_UserIsCreated()
        {
            // Arrange 
            var validNameLength = new string(new char[49]);
            const string metadata = "Researcher";
            var user = new StoredUser { Name = validNameLength, MetaData = "Researcher" };

            // Act 
            await _repository.Create(user);

            // Assert 
            _context.Users.Should().HaveCount(1);
            _context.Users.First().Should().NotBeNull();
            _context.Users.First().Name.Should().Be(validNameLength);
            _context.Users.First().MetaData.Should().Be(metadata);
        }

        [TestMethod]
        public async Task InsertUser_ValidNameLengthIsLimit_UserIsCreated()
        {
            // Arrange 
            var validNameLength = new string(new char[50]);
            const string metadata = "Researcher";
            var user = new StoredUser {Name = validNameLength, MetaData = "Researcher"};

            // Act 
            await _repository.Create(user);

            // Assert 
            _context.Users.Should().HaveCount(1);
            _context.Users.First().Should().NotBeNull();
            _context.Users.First().Name.Should().Be(validNameLength);
            _context.Users.First().MetaData.Should().Be(metadata);
        }

        [TestMethod, ExpectedException(typeof(DbEntityValidationException))]
        public async Task InsertUser_InValidNameLength_ErrorThrown()
        {
            // Arrange 
            var validNameLength = new string(new char[51]);
            const string metadata = "Researcher";
            var user = new StoredUser { Name = validNameLength, MetaData = "Researcher" };

            // Act 
            await _repository.Create(user);

            // Assert 
            _context.Users.Should().HaveCount(0);
            _context.Users.First().Should().BeNull();
        }

        /// <summary>
        /// Tests retrieval of an existing user in database. 
        /// </summary>
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

        /// <summary>
        /// Tests that a child entity is automatically created upon entity creation.
        /// By way of example, a team is created with a given user as member where the user child entity should then be reflected in the User DbSet.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task InsertTeam_WithUser_SavesUserInDatabase()
        {
            // Arrange
            var user = new StoredUser { Name = "William", MetaData = "Researcher" };

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

        [TestMethod]
        public async Task UpdateUser_ExistingUser_UserIsUpdated()
        {
            // Arrange
            var user = new StoredUser { Id = 1, Name = "William", MetaData = "Researcher"};
            //var updatedUser = //--= new StoredUser { Id = 1, Name = "Peter", MetaData = "Validator"};

            // Act
            await _repository.Create(user);

            user.Name = "Peter";

            await _repository.UpdateIfExists(user);

            // Assert
            _context.Users.First().Should().NotBeNull();
            _context.Users.First().Name.Should().Be("Peter");
        }

        [TestMethod]
        public async Task DeleteUser_ExistingUser_UserIdDeleted()
        {
            // Arrange
            var user = new StoredUser { Name = "William", MetaData = "Researcher" };

            // Act
            await _repository.Create(user);
            await _repository.DeleteIfExists(1);

            // Assert
            _context.Users.Should().BeEmpty();
        }

    }

}

