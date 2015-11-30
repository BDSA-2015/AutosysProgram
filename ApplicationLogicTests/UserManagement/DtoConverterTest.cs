using System;
using ApplicationLogics.UserManagement;
using ApplicationLogics.UserManagement.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.UserManagement
{
    [TestClass]
    public class DtoConverterTest
    {
        [TestMethod]
        public void ConvertUserDtoToUser()
        {
            //Arrage
            const string expectedName = "SomeName";
            const string expectedMetaData = "SomeData";
            var userDto = new SystematicStudyService.Models.User() {Name = expectedName, Metadata = expectedMetaData};

            //Act
            var convertedUser = DtoConverter.ConvertDtoUser(userDto);

            //Assert
            
            Assert.IsNotNull(convertedUser);
            Assert.IsInstanceOfType(convertedUser,typeof(User));
            Assert.AreEqual(expectedName,convertedUser.Name);
            Assert.AreEqual(expectedMetaData, convertedUser.Metadata);

        }

        public void ConvertTeamDtoToTeam()
        {
            //Arrage
            const string expectedName = "SomeName";
            const string expectedMetaData = "SomeData";
            var expectedUserIds = new[]{1,2,3,4};
            var teamDto = new SystematicStudyService.Models.Team() { Name = expectedName, Metadata = expectedMetaData, UserIDs = expectedUserIds};

            //Act
            var convertedTeam = DtoConverter.ConvertDtoTeam(teamDto);

            //Assert

            Assert.IsNotNull(convertedTeam);
            Assert.IsInstanceOfType(convertedTeam, typeof(Team));
            Assert.AreEqual(expectedName, convertedTeam.Name);
            Assert.AreEqual(expectedMetaData, convertedTeam.Metadata);
            Assert.IsTrue(expectedUserIds.Length == convertedTeam.UserIDs.Length);

            for (int i = 0; i < convertedTeam.UserIDs.Length; i++)
            {
                Assert.IsTrue(expectedUserIds[i] == convertedTeam.UserIDs[i]);
            }
        }
    }
}
