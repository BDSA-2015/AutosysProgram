// TeamValidatorTests.cs is a part of Autosys project in BDSA-2015. Created: 03, 12, 2015.
// Creators: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
// Jacob Mullit Møiniche.

using ApplicationLogics.StorageFasade;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository;
using Storage.Repository.Interface;

namespace ApplicationLogicTests.UserManagement
{
    /// <summary>
    /// This class tests if the team validator is working correctly
    /// </summary>
    [TestClass]
    public class TeamValidatorTests
    {
        /// <summary>
        /// Test team with valid data
        /// </summary>
        [TestMethod]
        public void ValidateEnteredDate_ValidData_Success_Test()
        {
            //Arrange
            var validTeam = new Team {Id = 0, Name = "Name", MetaData = "Data", UserIDs = new[] {0, 1}};

            //Act
            var result = TeamValidator.ValidateEnteredTeamData(validTeam);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test team with invalid id
        /// </summary>
        [TestMethod]
        public void InvalidDataInTeamTest_invalidID_ReturnFalse_Test()
        {
            //Arrange
            var validTeam = new Team {Id = -1, Name = "Name", MetaData = "Data", UserIDs = new[] {0, 1}};

            //Act
            var result = TeamValidator.ValidateEnteredTeamData(validTeam);

            //Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test team with empty string in data. Must return false
        /// to pass the test.
        /// </summary>
        [TestMethod]
        public void InvalidDataInTeamTest_EmptyString_ReturnFalse_Test()
        {
            //Arrange
            var validTeam = new Team {Id = 0, Name = "", MetaData = "", UserIDs = new[] {0, 1}};

            //Act
            var result = TeamValidator.ValidateEnteredTeamData(validTeam);

            //Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test team with white space in data. Must return false
        /// to pass the test.
        /// </summary>
        [TestMethod]
        public void InvalidDataInTeamTest_WhiteSpace_ReturnFalse_Test()
        {
            //Arrange
            var validTeam = new Team {Id = 0, Name = " ", MetaData = " ", UserIDs = new[] {0, 1}};

            //Act
            var result = TeamValidator.ValidateEnteredTeamData(validTeam);

            //Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test team with no user. Must return false to pass.
        /// </summary>
        [TestMethod]
        public void InvalidDataInTeamTest_NoUserIDs_ReturnFalse_Test()
        {
            //Arrange
            var validTeam = new Team {Id = 0, Name = " ", MetaData = " ", UserIDs = new int[10]};

            //Act
            var result = TeamValidator.ValidateEnteredTeamData(validTeam);

            //Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Test validation of existing team. Test must return true
        /// to indicate a team exist.
        /// </summary>
        public void CheckExistingTeam_Exists_True_Test()
        {
            //Arrange
            var id = 0;
            var repositoryMock = new Mock<IRepository<StoredTeam>>();
            var storedTeam = new StoredTeam {Id = 0, Name = "name", MetaData = "metaData", InternalUserIDs = new[] {1, 2, 3}};
            repositoryMock.Setup(r => r.Read(id)).Returns(storedTeam);

            var teamFacade = new TeamFacade(repositoryMock.Object);

            //Act
            var result = TeamValidator.ValidateExistence(0, teamFacade);

            //Assert
            Assert.IsTrue(result);
        }

        /// <summary>
        /// Test validation of non-existing team. Test must return false
        /// to indicate a team does not exist.
        /// </summary>
        public void CheckExistingTeam_NonExisting_False_Test()
        {
            //Arrange
            var id = 0;
            var repositoryMock = new Mock<IRepository<StoredTeam>>();
            var storedTeam = new StoredTeam {Id = 0, Name = "name", MetaData = "metaData", InternalUserIDs = new[] {1, 2, 3}};
            repositoryMock.Setup(r => r.Read(id));

            var teamFacade = new TeamFacade(repositoryMock.Object);

            //Act
            var result = TeamValidator.ValidateExistence(0, teamFacade);

            //Assert
            Assert.IsFalse(result);
        }
    }
}