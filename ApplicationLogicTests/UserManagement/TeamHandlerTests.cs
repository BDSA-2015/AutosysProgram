using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;

namespace ApplicationLogicTests.UserManagement
{
    [TestClass]
    public class TeamHandlerTests
    {
        private Mock<IAdapter<Team, StoredTeam>> _adapterMock;
        private Team _team;

        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfigurator.Configure();
            _adapterMock = new Mock<IAdapter<Team, StoredTeam>>();
            _team = new Team {Id = 0, MetaData = "Meta", Name = "name", UserIDs = new[] {1, 2}};
        }


        /// <summary>
        ///     Test of valid team creation
        /// </summary>
        [TestMethod]
        public async void CreateTeam_Valid_Test()
        {
            //Arrange
            _adapterMock.Setup(r => r.Create(_team)).Returns(Task.FromResult(_team.Id));
            var teamHandler = new TeamHandler(_adapterMock.Object);

            //Act
            var returnedId = await teamHandler.Create(_team);

            //Assert
            Assert.IsTrue(returnedId == _team.Id);
        }


        /// <summary>
        ///     Whitespaces in team are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public async void CreateTeam_Invalid_TeamInformationWhiteSpace_Test()
        {
            //Arrange
            _team.Name = " ";
            _team.MetaData = " ";

            _adapterMock.Setup(r => r.Create(_team));
            var teamHandler = new TeamHandler(_adapterMock.Object);

            //Act
            var result = await teamHandler.Create(_team);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        ///     Whitespaces in teams are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public async void CreateTeam_Invalid_TeamInformationEmptyString_Test()
        {
            //Arrange
            _team.Name = "";
            _team.MetaData = "";

            _adapterMock.Setup(r => r.Create(_team));
            var teamHandler = new TeamHandler(_adapterMock.Object);

            //Act
            var result = await teamHandler.Create(_team);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        ///     Teams with no members are not allowed. Testing if exception is being thrown
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentException))]
        public async void CreateTeam_Invalid_NoTeamMember_Test()
        {
            //Arrange
            _team.UserIDs = new int[0];

            _adapterMock.Setup(r => r.Create(_team));
            var teamHandler = new TeamHandler(_adapterMock.Object);

            //Act
            var result = await teamHandler.Create(_team);

            //Assert
            //Exception must be thrown
        }


        /// <summary>
        ///     Test if an existing team is being deleted
        /// </summary>
        [TestMethod]
        public async void DeleteTeam_Valid_Test()
        {
            //Arrange
            var adapter = new Mock<IAdapter<Team, StoredTeam>>();
            const int idToDelete = 0;
            adapter.Setup(r => r.DeleteIfExists(idToDelete)).Returns(Task.FromResult(true));
            var teamHandler = new TeamHandler(adapter.Object);

            //Act
            var result = await teamHandler.Delete(idToDelete);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        ///     Test if non existing team is being deleted
        ///     Exception must be thrown here.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (NullReferenceException))]
        public async void DeleteTeam_Invalid_NoExistingTeam_Test()
        {
            //Arrange
            _adapterMock.Setup(r => r.DeleteIfExists(_team.Id)).Throws(new NullReferenceException());
            var teamHandler = new TeamHandler(_adapterMock.Object);

            //Act
            await teamHandler.Delete(_team.Id);

            //Assert
            //Exception must be thrown
        }

        /// <summary>
        ///     Test deletion with invalid id
        ///     Exception must be thrown here.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async void DeleteUser_Invalid_InvalidId_Test()
        {
            //Arrange
            var teamHandler = new TeamHandler(_adapterMock.Object);
            var invalidId = -1;

            //Act
            var result = await teamHandler.Delete(invalidId);

            //Assert
            //Exception must be thrown
        }


        /// <summary>
        ///     Test if existing team containts correct information
        /// </summary>
        [TestMethod]
        public async void ReadTeam_Valid_CorrectInformation_Test()
        {
            //Arrange
            _adapterMock.Setup(r => r.Read(_team.Id)).Returns(Task.FromResult(_team));
            var teamHandler = new TeamHandler(_adapterMock.Object);

            //Act
            var actualTeam = await teamHandler.Read(_team.Id);

            //Assert
            Assert.IsTrue(actualTeam.Id == _team.Id);
            Assert.IsTrue(actualTeam.Name == _team.Name);
            Assert.IsTrue(actualTeam.MetaData == _team.MetaData);
            Assert.IsTrue(actualTeam.UserIDs.Length == _team.UserIDs.Length);
        }

        /// <summary>
        ///     Test if get all teams returns the correct number of teams.
        /// </summary>
        [TestMethod]
        public void ReadAllTeams_Valid_CorrectNumberOfTeams_Test()
        {
            //Arrange
            var team1 = new Team {Id = 0, Name = "Team1", MetaData = "Meta1", UserIDs = new[] {1}};
            var team2 = new Team {Id = 1, Name = "Team2", MetaData = "Meta2", UserIDs = new[] {2}};
            var teamList = new List<Team> {team1, team2};
            _adapterMock.Setup(r => r.Read()).Returns(teamList.AsQueryable());
            var teamHandler = new TeamHandler(_adapterMock.Object);

            //Act
            var actualTeams = teamHandler.GetAll();
            var counter = actualTeams.Count();

            //Assert
            Assert.IsTrue(counter == teamList.Count);
        }
    }
}