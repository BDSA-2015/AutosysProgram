// TeamHandlerTests.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.StorageAdapter;
using ApplicationLogics.UserManagement;
using ApplicationLogicTests.UserManagement.Stub;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogicTests.UserManagement
{
    /// <summary>
    ///     Test for the TeamHandler Class
    /// </summary>
    [TestClass]
    public class TeamFacadeTests
    {
        private Mock<IRepository<StoredTeam>> _repositoryMock;
        private StoredTeam _storedTeam;
        private Team _team;

        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfigurator.Configure();
            _repositoryMock = new Mock<IRepository<StoredTeam>>();
            _storedTeam = new StoredTeam {Name = "name", MetaData = "metaData", UserIds = new[] {1, 2, 3}};
            _team = new Team {Name = "name", MetaData = "metaData", UserIDs = new[] {1, 2, 3}};
        }

        /// <summary>
        ///     Successfull creation of Team test
        /// </summary>
        [TestMethod]
        public void CreateTeam_Success_Test()
        {
            //Arrange 

            const int expectedReturnId = 0;
            _repositoryMock.Setup(r => r.Create(_storedTeam)).Returns(expectedReturnId);
            var teamFacade = new TeamAdapter(_repositoryMock.Object);

            //Act
            var actualId = teamFacade.Create(_team); //BUG AUTOMAPPER EXCEPTION IS THROWN HERE...

            //Assert
            Assert.IsTrue(expectedReturnId == actualId);
        }


        /// <summary>
        ///     Test if read does not return null when given a valid team id
        /// </summary>
        [TestMethod]
        public void GetTeam_Valid_NotNull_Test()
        {
            //Arrange
            var idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(_storedTeam);
            var teamFacade = new TeamAdapter(_repositoryMock.Object);

            //Act
            var returnedTeam = teamFacade.Read(idToRead);

            //Assert
            Assert.IsNotNull(returnedTeam);
        }

        /// <summary>
        ///     Test if read returns a team object when given a valid team id
        /// </summary>
        [TestMethod]
        public void GetTeam_Valid_IsTeam_Test()
        {
            //Arrange
            var idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(_storedTeam);
            var teamFacade = new TeamAdapter(_repositoryMock.Object);

            //Act
            var returnedTeam = teamFacade.Read(idToRead);

            //Assert
            Assert.IsInstanceOfType(returnedTeam, typeof (Team));
        }


        /// <summary>
        ///     Test if read returns a team object with correct information
        /// </summary>
        [TestMethod]
        public void GetTeam_Valid_CorrectTeamInfo_Test()
        {
            //Arrange
            var idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(_storedTeam);
            var teamFacade = new TeamAdapter(_repositoryMock.Object);

            //Act
            var returnedTeam = teamFacade.Read(idToRead);

            //Assert
            Assert.IsTrue(_team.Name == returnedTeam.Name);
            Assert.IsTrue(_team.MetaData == returnedTeam.MetaData);
            Assert.IsTrue(_team.Id == returnedTeam.Id);
            Assert.IsTrue(_team.UserIDs.Length == returnedTeam.UserIDs.Length);
        }

        /// <summary>
        ///     Test that a returned team is null if Team does not exist.
        /// </summary>
        [TestMethod]
        public void GetTeam_Invalid_NoExistingTeamMustReturnNull_Test()
        {
            //Arrange
            var idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead));
            var teamFacade = new TeamAdapter(_repositoryMock.Object);

            //Act
            var returnedTeam = teamFacade.Read(idToRead);

            //Assert
            Assert.IsNull(returnedTeam);
        }

        /// <summary>
        ///     Test if read with parameters returns correct numbers of teams
        /// </summary>
        [TestMethod]
        public void GetAllTeams_Valid_ReturnsCorrectNumberOfTeams_Test()
        {
            //Arrange
            var team1 = new StoredTeam {Name = "name1", MetaData = "metaData1"};
            var team2 = new StoredTeam {Name = "name2", MetaData = "metaData2"};
            var team3 = new StoredTeam {Name = "name3", MetaData = "metaData3"};
            IEnumerable<StoredTeam> list = new List<StoredTeam> {team1, team2, team3};
            _repositoryMock.Setup(r => r.Read()).Returns(list);
            var teamFacade = new TeamAdapter(_repositoryMock.Object);
            var expectedCount = 3;

            //Act
            var actualCount = teamFacade.Read().Count();

            //Assert
            Assert.IsTrue(expectedCount == actualCount);
        }

        /// <summary>
        ///     Test if read with parameters returns teams with correct information
        /// </summary>
        [TestMethod]
        public void GetAllTeams_Valid_ReturnsCorrectTeams_Test()
        {
            //Arrange
            var team1 = new StoredTeam {Name = "name1", MetaData = "metaData1", UserIds = new[] {1}};
            var team2 = new StoredTeam {Name = "name2", MetaData = "metaData2", UserIds = new[] {2}};
            var team3 = new StoredTeam {Name = "name3", MetaData = "metaData3", UserIds = new[] {3}};
            IEnumerable<StoredTeam> list = new List<StoredTeam> {team1, team2, team3};
            _repositoryMock.Setup(r => r.Read()).Returns(list);
            var teamFacade = new TeamAdapter(_repositoryMock.Object);

            //Act
            var actualTeams = teamFacade.Read().ToArray();

            //Assert
            var counter = 0;
            foreach (var expectedTeam in list)
            {
                var returnedTeam = actualTeams[counter];
                Assert.IsTrue(expectedTeam.Name == returnedTeam.Name);
                Assert.IsTrue(expectedTeam.MetaData == returnedTeam.MetaData);
                Assert.IsTrue(expectedTeam.Id == returnedTeam.Id);
                Assert.IsTrue(expectedTeam.UserIds.Length == returnedTeam.UserIDs.Length);
                counter++;
            }
        }


        /// <summary>
        ///     Successfull deletion of Team
        /// </summary>
        [ExpectedException(typeof (KeyNotFoundException))]
        [TestMethod]
        public void DeleteTeam_Success_Test()
        {
            //Arrange 
            var teamFacade = new TeamAdapter(new RepositoryStub<StoredTeam>());
            var team = new Team {Name = "name", MetaData = "data", UserIDs = new[] {1, 2}};
            var toDeleteId = 0;
            //Act
            teamFacade.Create(team);
            Assert.IsNotNull(teamFacade.Read(toDeleteId));
            teamFacade.Delete(team);

            //Assert
            teamFacade.Read(toDeleteId);
            //Exception must be thrown to indicate that the team does not exist (ONLY FOR TESTING REPOSITORY STUB)
        }

        /// <summary>
        ///     Test when trying to delete a non-existing team.
        ///     Exception must be thrown to pass test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public void DeleteTeam_Fail_TeamDoesNotExist_Test()
        {
            //Arrange
            var toDeleteId = 0;
            _repositoryMock.Setup(r => r.Read(toDeleteId));
            var teamFacade = new TeamAdapter(_repositoryMock.Object);

            //Act
            teamFacade.Delete(_team);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        ///     Test deleting a team that has been updated
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void DeleteTeam_Fail_TeamToDeleteHasBeenUpdated_Test()
        {
            //Arrange
            var editedTeam = new StoredTeam
            {
                Id = _team.Id,
                Name = "changed",
                MetaData = "changed",
                UserIds = new[] {1, 8}
            };

            _repositoryMock.Setup(r => r.Read(_team.Id)).Returns(editedTeam);

            var teamFacade = new TeamAdapter(_repositoryMock.Object);

            //Act
            teamFacade.Delete(_team);

            //Assert
            //Exception must be thrown
        }
    }
}