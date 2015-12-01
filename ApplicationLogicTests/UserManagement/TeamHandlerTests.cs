using ApplicationLogics.Repository;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.UserManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Entities;

namespace ApplicationLogicTests.UserManagement
{
    [TestClass]
    public class TeamHandlerTests
    {
        [TestMethod]
        public void CreateTeamTest()
        {
            //Arrange 
            var repositoryMock = new Mock<IRepository<StoredTeam>>();
            var storedTeam = new StoredTeam(){Name = "name", Metadata = "metaData", UserIDs = new [] {1,2,3}};
            var expectedReturnId = 0;
            repositoryMock.Setup(r => r.Create(storedTeam)).Returns(expectedReturnId);
            var teamFacade = new TeamFasade(repositoryMock.Object);

            var team = new Team() {Name = "name", Metadata = "metaData", UserIDs = new[] {1, 2, 3}};
        
            //Act
            var actualId = teamFacade.Create(team);
            

            //Assert
            Assert.IsTrue(expectedReturnId == actualId);
        }
    }
}
