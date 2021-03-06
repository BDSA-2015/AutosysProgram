﻿// TeamHandlerTests.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.StorageAdapter;
using ApplicationLogics.UserManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogicTests.StorageAdapter
{
    /// <summary>
    ///     Test for the TeamHandler Class
    /// </summary>
    [TestClass]
    public class TeamAdapterTests
    {
        private Mock<IRepository<StoredTeam>> _repositoryMock;
        private StoredTeam _storedTeam;
        private Team _team;

        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfigurator.Configure();
            _repositoryMock = new Mock<IRepository<StoredTeam>>();
            _storedTeam = new StoredTeam
            {
                Name = "name",
                MetaData = "metaData",
                Users = new List<StoredUser>
                {
                    new StoredUser { Id = 1 },
                    new StoredUser { Id = 2 },
                    new StoredUser { Id = 3 }       
                } 
            
            };
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
            _repositoryMock.Setup(r => r.Create(_storedTeam)).Returns(Task.FromResult(expectedReturnId));
            var teamFacade = new TeamAdapter(_repositoryMock.Object);

            //Act
            var actualId = teamFacade.Create(_team);

            //Assert
            Assert.IsTrue(expectedReturnId == actualId.Result);
        }


        /// <summary>
        ///     Test if read does not return null when given a valid team id
        /// </summary>
        [TestMethod]
        public void GetTeam_Valid_NotNull_Test()
        {
            //Arrange
            var idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedTeam));
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
        public async void GetTeam_Valid_IsTeam_Test()
        {
            //Arrange
            var idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedTeam));
            var teamFacade = new TeamAdapter(_repositoryMock.Object);

            //Act
            var returnedTeam = await teamFacade.Read(idToRead);

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
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedTeam));
            var teamFacade = new TeamAdapter(_repositoryMock.Object);

            //Act
            var returnedTeam = teamFacade.Read(idToRead).Result;

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
        public async void GetTeam_Invalid_NoExistingTeamMustReturnNull_Test()
        {
            //Arrange
            var idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead));
            var teamFacade = new TeamAdapter(_repositoryMock.Object);

            //Act
            var returnedTeam = await teamFacade.Read(idToRead);

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
            _repositoryMock.Setup(r => r.Read()).Returns(list.AsQueryable());
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
            var team1 = new StoredTeam {Name = "name1", MetaData = "metaData1", Users = new List<StoredUser> { new StoredUser { Id = 1} } };
            var team2 = new StoredTeam {Name = "name2", MetaData = "metaData2", Users = new List<StoredUser> { new StoredUser { Id = 2 } } };
            var team3 = new StoredTeam {Name = "name3", MetaData = "metaData3", Users = new List<StoredUser> { new StoredUser { Id = 3 } } };
            IEnumerable<StoredTeam> list = new List<StoredTeam> {team1, team2, team3};
            _repositoryMock.Setup(r => r.Read()).Returns(list.AsQueryable());
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
                Assert.IsTrue(expectedTeam.Users.ToArray().Length == returnedTeam.UserIDs.Length);
                counter++;
            }
        }


        /// <summary>
        ///     Successfull deletion of Team
        /// </summary>
        [ExpectedException(typeof (KeyNotFoundException))]
        [TestMethod]
        public async void DeleteTeam_Success_Test()
        {
            //Arrange 
            var repositoryMock = new Mock<IRepository<StoredTeam>>();
            const int toDeleteId = 0;
            repositoryMock.Setup(r => r.DeleteIfExists(toDeleteId)).Returns(Task.FromResult(true));
            var adapter = new TeamAdapter(repositoryMock.Object);


            //Act

            var result = await adapter.DeleteIfExists(toDeleteId);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        ///     Test when trying to delete a non-existing team.
        ///     Exception must be thrown to pass test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public async void DeleteTeam_Fail_TeamDoesNotExist_Test()
        {
            //Arrange
            var toDeleteId = 0;
            _repositoryMock.Setup(r => r.DeleteIfExists(toDeleteId)).Returns(Task.FromResult(false));
            var adapter = new TeamAdapter(_repositoryMock.Object);

            //Act
            var result = await adapter.DeleteIfExists(toDeleteId);

            //Assert
            //Exception must be thrown
        }
    }
}