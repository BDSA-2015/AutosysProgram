using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Constraints;
using Storage;
using Storage.Models;
using Storage.Repository;
using Storage.Repository.Interface;

namespace StorageTests.DatabaseIntegrationTests
{
    /// <summary>
    ///     This class is used to integration test the Study repository, StoredStudy entity and database with Entity Framework.
    ///     For this purpose, a test database is setup from in memory using the Effort framework. 
    ///     It will be done with a DbContext similar to <see cref="AutoSysDbModel" /> but with a fake connection string.
    /// </summary>
    [TestClass]
    public class StudyRepositoryIntegrationTest
    {
        private IRepository<StoredStudy> _repository;
        private IAutoSysContext _context;
        private DbConnection _connection;

        [TestInitialize]
        public void Initialize()
        {
            _connection = Effort.DbConnectionFactory.CreateTransient(); // Fake connection 
            _context = new AutoSysContext(_connection);
            _repository = new StudyRepository(_context);
            //_repository = new DbRepository<StoredUser>(_context);
        }

        /// <summary>
        /// Tests if a non-existant study does not return any user. 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetStudy_WithNonExistingId_ReturnsNull()
        {
            // Arrange
            const int nonExistingId = 155;

            // Act
            var study = await _repository.Read(nonExistingId);

            // Assert
            Assert.IsNull(study);
        }

        /// <summary>
        /// Tests if the repository correctly avoids creating studies from invalid study information (null). 
        /// </summary>
        /// <returns></returns>
        [TestMethod, ExpectedException(typeof(ArgumentNullException))]
        public async Task CreateStudy_Null_ErrorThrown()
        {
            // Arrange 
            var study = new StoredStudy {}; // Todo Fill in data 

            // Act 
            await _repository.Create(null);

            _context.Studies.Should().HaveCount(0);
            _context.Studies.First().Should().Be(null);
        }

        /// <summary>
        /// Tests if a given study is added correctly to the database. 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task InsertStudy_ValidStudy_StudyWasAddedCorrectly()
        {
            // Arrange
            const string studyName = "study"; // Todo add all properties 

            var study = new StoredStudy {Name = studyName}; // Add properties 

            // Act
            await _repository.Create(study);

            // Assert
            _context.Studies.Should().HaveCount(1);
            _context.Studies.First().Should().NotBeNull();
            _context.Studies.First().Name.Should().Be(studyName);
        }

        /// <summary>
        /// Tests that [Required] fields like e.g. Name in a Study triggers an exception if omitted. 
        /// </summary>
        /// <returns></returns>
        [TestMethod, ExpectedException(typeof(DbEntityValidationException))] // Assert 
        public async Task InsertStudy_InvalidStudy_RequiredNameMissing()
        {
            // Arrange
            var study = new StoredStudy {}; // Todo add data 

            // Act
            await _repository.Create(study);

            // Assert
            _context.Studies.Should().HaveCount(0);
            _context.Studies.First().Should().BeNull();
            _context.Studies.First().Name.Should().Be(null);
        }

        /// <summary>
        /// Checks that names below the [StringLength] limit at correcly passed for a given study. 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task InsertStudy_ValidNameLengthBelowLimit_StudyIsCreated()
        {
            // Arrange 
            var validNameLength = new string(new char[49]); // Todo add more property data 
            var study = new StoredStudy { Name = validNameLength };

            // Act 
            await _repository.Create(study);

            // Assert 
            _context.Studies.Should().HaveCount(1);
            _context.Studies.First().Should().NotBeNull();
            _context.Studies.First().Name.Should().Be(validNameLength);
        }

        /// <summary>
        /// Checks that the [StringLength] attribute is correctly passing a name with length equal to its own limit. 
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task InsertStudy_ValidNameLengthIsLimit_StudyIsCreated()
        {
            // Arrange 
            var validNameLength = new string(new char[50]);
            var study = new StoredStudy { Name = validNameLength };

            // Act 
            await _repository.Create(study);

            // Assert 
            _context.Studies.Should().HaveCount(1);
            _context.Studies.First().Should().NotBeNull();
            _context.Studies.First().Name.Should().Be(validNameLength);
        }

        /// <summary>
        /// Checks that the [StringLength] attribute is not exceeded in the Name property. 
        /// </summary>
        /// <returns></returns>
        [TestMethod, ExpectedException(typeof(DbEntityValidationException))]
        public async Task InsertStudy_InValidNameLength_ErrorThrown()
        {
            // Arrange 
            var validNameLength = new string(new char[51]);
            var study = new StoredStudy { Name = validNameLength };

            // Act 
            await _repository.Create(study);

            // Assert 
            _context.Studies.Should().HaveCount(0);
            _context.Studies.First().Should().BeNull();
        }

        /// <summary>
        /// Tests retrieval of an existing study in database. 
        /// </summary>
        [TestMethod]
        public void GetStudy_WithExistingId_ReturnsStudy()
        {
            // Arrange
            var study = new StoredStudy { Name = "StudyName" };
            _repository.Create(study);

            // Act
            var retrievedStudy = _repository.Read(study.Id).Result;

            // Assert
            study.Name.Should().Be(retrievedStudy.Name);
            study.Id.Should().Be(retrievedStudy.Id);
        }

        /// <summary>
        /// Checks if all papers in a given study are actually saved in the database based on mock data in <see cref="StudyTestData"/>
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task InsertStudy_WithPapers_SavesPapersInDatabase()
        {
            // Arrange 
            var papers = StudyTestData.CreatePapers();
            // var study = new StoredStudy { Name = "StudyName", Papers = papers };
            var study = new StoredStudy
            {
                Name = "StudyName",
                Papers = new List<StoredPaper>
                {
                    new StoredPaper {}
                }
            };

            // Act 
            await _repository.Create(study);

            // Assert
            _context.Studies.Should().HaveCount(1);
            _context.Studies.Should().NotBeNull();
            _context.Papers.Should().HaveCount(1);
            _context.Papers.First().Should().NotBeNull();
        }

        /// <summary>
        /// Checks if all datafields in a given study are actually saved in the database based on mock data in <see cref="StudyTestData"/>
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task InsertStudy_WithDatafields_SavesDatafieldsInDatabase()
        {
            // Arrange 
            var datafields = StudyTestData.CreateDatafields();
            var study = new StoredStudy { Name = "StudyName", DataFields = datafields };

            // Act 
            await _repository.Create(study);

            // Assert
            _context.Studies.Should().HaveCount(1);
            _context.Studies.Should().NotBeNull();
            _context.Datafields.Should().HaveCount(1);
            _context.Datafields.First().Should().NotBeNull();
        }

        /// <summary>
        /// Checks if all criteria in a given study are actually saved in the database based on mock data in <see cref="StudyTestData"/>
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task InsertStudy_WithCriteria_SavesCriteriaInDatabase()
        {
            // Arrange 
            var inclusionCriteria = StudyTestData.CreateInclusionCriteria(); // 3 items 
            var exclusionCriteria = StudyTestData.CreateExclusionCriteria(); // 3 items 
            var study = new StoredStudy { Name = "StudyName", InclusionCriteria = inclusionCriteria, ExclusionCriteria = exclusionCriteria };

            // Act 
            await _repository.Create(study);

            // Assert
            _context.Studies.Should().HaveCount(1);
            _context.Studies.Should().NotBeNull();
            _context.Criteria.Should().HaveCount(6);
            _context.Criteria.First().Should().NotBeNull(); // Todo range 
        }

        /// <summary>
        /// Checks if all Users in a given study are actually saved in the database based on mock data in <see cref="StudyTestData"/>
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task InsertStudy_WithUsers_SavesUsersInDatabase()
        {
            // Arrange 
            var users = StudyTestData.CreateUsers(); // 3 users 
            var study = new StoredStudy { Name = "StudyName", Users = users };

            // Act 
            await _repository.Create(study);

            // Assert
            _context.Studies.Should().HaveCount(1);
            _context.Studies.Should().NotBeNull();
            _context.Users.Should().HaveCount(3);
            _context.Users.First().Should().NotBeNull(); ; // Todo range 
        }

        /// <summary>
        /// Checks if Phases for a given study are actually saved in the database based on mock data in <see cref="StudyTestData"/>
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task InsertStudy_WithPhases_SavesPhasesInDatabase()
        {
            // Arrange 
            var phases = StudyTestData.CreatePhases();

            var study = new StoredStudy
            {
                Name = "StudyName",
                Phases = phases
            };

            // Act 
            await _repository.Create(study);

            // Assert
            _context.Studies.Should().HaveCount(1);
            _context.Studies.Should().NotBeNull();
            _context.Phases.Should().HaveCount(3);
            _context.Phases.First().Should().NotBeNull(); // Todo range 
        }
        
        /// <summary>
        /// Checks if all child entities for a given study are actually saved in the database based on mock data in <see cref="StudyTestData"/>
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task InsertStudy_WithAllProperties_SavesAllEntitiesInDatabase()
        {
            // Arrange
            var study = new StoredStudy
            {
                Name = "StudyName",
                DataFields = StudyTestData.CreateDatafields(),
                Description = "StudyDescription",
                ExclusionCriteria = StudyTestData.CreateExclusionCriteria(),
                InclusionCriteria = StudyTestData.CreateInclusionCriteria(),
                Papers = StudyTestData.CreatePapers(),
                Phases = StudyTestData.CreatePhases(),
                Users = StudyTestData.CreateUsers()
            };

            // Act
            await _repository.Create(study);
            
            // Assert
            _context.Studies.Should().NotBeNull();
            _context.Datafields.Should().NotBeNull();
            _context.Criteria.Should().NotBeNull();
            _context.Papers.Should().NotBeNull();
            _context.Phases.Should().NotBeNull();
            _context.Users.Should().NotBeNull();
        }


    }

}

