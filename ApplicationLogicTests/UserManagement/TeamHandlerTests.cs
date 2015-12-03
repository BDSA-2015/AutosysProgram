// TeamHandlerTests.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.UserManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository;

namespace ApplicationLogicTests.UserManagement
{
    /// <summary>
    /// Test for the TeamHandler Class
    /// </summary>
    [TestClass]
    public class TeamHandlerTests
    {

        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfigurator.Configure();
        }

        [TestMethod]
        public void CreateTeam_Success_Test()
        {
            //Arrange 
            var repositoryMock = new Mock<IRepository<StoredTeam>>();
            var storedTeam = new StoredTeam {Name = "name", Metadata = "metaData", UserIDs = new[] {1, 2, 3}};
            const int expectedReturnId = 0;
            repositoryMock.Setup(r => r.Create(storedTeam)).Returns(expectedReturnId);
            var teamFacade = new TeamFacade(repositoryMock.Object);

            var team = new Team {Name = "name", Metadata = "metaData", UserIDs = new[] {1, 2, 3}};


            //Act
            var actualId = teamFacade.Create(team);


            //Assert
            Assert.IsTrue(expectedReturnId == actualId);
        }
    }
}