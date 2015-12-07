using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.StorageFasade.Interface;
using ApplicationLogics.UserManagement;
using ApplicationLogicTests.UserManagement.Stub;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;

namespace ApplicationLogicTests.UserManagement
{
    [TestClass]
    public class TeamHandlerTests
    {

        private Mock<IFacade<Team>> _facadeMock;
        private Team _team;

        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfigurator.Configure();
            _facadeMock = new Mock<IFacade<Team>>();
            _team = new Team() {Id = 0, MetaData = "Meta", Name = "name", UserIDs = new[] {1, 2}};
        }


        /// <summary>
        /// Test of valid team creation
        /// </summary>
        [TestMethod]
        public void CreateTeam_Valid_Test()
        {
            //Arrange
            _facadeMock.Setup(r => r.Create(_team)).Returns(_team.Id);
            var teamHandler = new TeamHandler(_facadeMock.Object);

            //Act
            var result = teamHandler.Create(_team);

            //Assert
            Assert.IsTrue(result == _team.Id);
        }


        /// <summary>
        /// Whitespaces in team are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void CreateTeam_Invalid_TeamInformationWhiteSpace_Test()
        {
            //Arrange
            _team.Name = " ";
            _team.MetaData = " ";

            _facadeMock.Setup(r => r.Create(_team));
            var teamHandler = new TeamHandler(_facadeMock.Object);

            //Act
            var result = teamHandler.Create(_team);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        /// Whitespaces in teams are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void CreateTeam_Invalid_TeamInformationEmptyString_Test()
        {
            //Arrange
            _team.Name = "";
            _team.MetaData = "";

            _facadeMock.Setup(r => r.Create(_team));
            var teamHandler = new TeamHandler(_facadeMock.Object);

            //Act
            var result = teamHandler.Create(_team);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        /// Teams with no members are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void CreateTeam_Invalid_NoTeamMember_Test()
        {
            //Arrange
            _team.UserIDs = new int[0];

            _facadeMock.Setup(r => r.Create(_team));
            var teamHandler = new TeamHandler(_facadeMock.Object);

            //Act
            var result = teamHandler.Create(_team);

            //Assert
            //Exception must be thrown
        }



        /// <summary>
        /// Test if an existing team is being deleted
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void DeleteTeam_Valid_Test()
        {
            //Arrange
            var facade = new TeamFacade(new RepositoryStub<StoredTeam>());
            var teamHandler = new TeamHandler(facade);
            var team = new Team() {Name = "Name", MetaData = "data", UserIDs = new[] {1, 3}};
            const int idToDelete = 0;

            //Act
            teamHandler.Create(team);
            Assert.IsNotNull(teamHandler.Read(idToDelete));
            teamHandler.Delete(idToDelete);

            //Assert
            teamHandler.Read(idToDelete);
                //Exception must be thrown to indicate that the team does not exist (ONLY FOR TESTING REPOSITORY STUB)

        }

        /// <summary>
        /// Test if non existing team is being deleted
        /// Exception must be thrown here.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public void DeleteUser_Invalid_NoExistingUser_Test()
        {
            //Arrange
            _facadeMock.Setup(r => r.Read(_team.Id));
            var teamHandler = new TeamHandler(_facadeMock.Object);

            //Act
            teamHandler.Delete(_team.Id);

            //Assert
            //Exception must be thrown
        }


        /// <summary>
        /// Test if existing team containts correct information
        /// </summary>
        [TestMethod]
        public void ReadTeam_Valid_CorrectInformation_Test()
        {
            //Arrange
            _facadeMock.Setup(r => r.Read(_team.Id)).Returns(_team);
            var teamHandler = new TeamHandler(_facadeMock.Object);

            //Act
            var actualTeam = teamHandler.Read(_team.Id);

            //Assert
            Assert.IsTrue(actualTeam.Id == _team.Id);
            Assert.IsTrue(actualTeam.Name == _team.Name);
            Assert.IsTrue(actualTeam.MetaData == _team.MetaData);
            Assert.IsTrue(actualTeam.UserIDs.Length == _team.UserIDs.Length);
        }

        /// <summary>
        /// Test if get all teams returns the correct number of teams.
        /// </summary>
        [TestMethod]
        public void ReadAllTeams_Valid_CorrectNumberOfTeams_Test()
        {
            //Arrange
            var team1 = new Team() {Id = 0, Name = "Team1", MetaData = "Meta1", UserIDs = new []{1}};
            var team2 = new Team() { Id = 1, Name = "Team2", MetaData = "Meta2", UserIDs = new[] {2} };
            var teamList = new List<Team>() {team1,team2};
            _facadeMock.Setup(r => r.Read()).Returns(teamList);
            var teamHandler = new TeamHandler(_facadeMock.Object);

            //Act
            var actualTeams= teamHandler.GetAll();
            var counter = actualTeams.Count();


            //Assert
            Assert.IsTrue(counter == teamList.Count);
        }

    }
}
