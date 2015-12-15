using WebApi.Mapping.Profiles;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using ApplicationLogics.StudyManagement;
using DConflictingData = ApplicationLogics.StudyManagement.ConflictingData;
using AConflictingData = WebApi.Models.ConflictingData;
using DCriteria = ApplicationLogics.StudyManagement.Criteria;
using DDataField = ApplicationLogics.StudyManagement.DataField;
using ADataField = WebApi.Models.DataField;
using AStage = WebApi.Models.StageOverview;
using DStage = ApplicationLogics.StudyManagement.Phase;
using DTask = ApplicationLogics.StudyManagement.TaskRequest;
using ATask = WebApi.Models.TaskRequest;
using DUser = ApplicationLogics.UserManagement.Entities.User;
using DTeam = ApplicationLogics.UserManagement.Entities.Team;
using AUser = WebApi.Models.User;
using ATeam = WebApi.Models.Team;



namespace WebApi.Mapping.Profiles.Tests
{
    //Variables with a prefix of A refor to API
    //Variables with a prefix of D refer to Enities found in ApplicationLogics
    [TestClass()]
    public class StudyEntitiesMappingTest
    {

        [TestMethod()]
        public void CreateConflictingDataMappingTest()
        {
            //Arrange
            var dConflictingData = new DConflictingData();
            dConflictingData.UserId = 0;
            dConflictingData.Data = new string[] { "True", "False", "True" };

            var aConflictingData = new AConflictingData();
            aConflictingData.Data = new string[] { "True", "False", "True" };
            dConflictingData.UserId = 0;
            //Act
            var newAConflictingData = AutoMapper.Mapper.Map<AConflictingData>(dConflictingData);
            //Assert
            Assert.AreEqual(aConflictingData, newAConflictingData);
        }

        [TestMethod()]
        public void CreateRessourceMappingTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateStageOverviewMappingTest()
        {
            //Arrange
            var aStage = new AStage();
            aStage.CompletedTasks = new Dictionary<int, int>() { { 1, 2 }, { 2, 0} }; //User 1 has two completed and zero incomplete tasks  && 
            aStage.IncompleteTasks = new Dictionary<int, int>() { { 1, 0 }, { 2, 2 } };
            aStage.Name = "first Phase";

            var dStage = CreateDStageTasks();

            //Act

            var newAStage = AutoMapper.Mapper.Map<AStage>(dStage);

            //Assert 
            

        }

        [TestMethod()]
        public void CreateStudyOverviewMappingTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateTaskRequestMappingTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void TaskSubmissionMappingTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateTeamMappingTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateUserMappingTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ModelEntitiesMappingTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateConflictingDataMappingTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateRessourceMappingTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateStageOverviewMappingTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateStudyOverviewMappingTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateTaskRequestMappingTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void TaskSubmissionMappingTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateTeamMappingTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void CreateUserMappingTest1()
        {
            throw new NotImplementedException();
        }

        //Help methods
        private Dictionary<DUser,List<DTask>> CreateDStageTasks()
        {
            var dTasklist = new Dictionary<DUser, List<DTask>>();

            //Create Users
            var dUser_1 = new DUser(); dUser_1.Id = 1;
            var dUser_2 = new DUser(); dUser_2.Id = 2;

            //Crate a List of Tasks for each user
            var Task_user1_1 = new DTask(); Task_user1_1.IsFinished = false;
            var Task_user1_2 = new DTask(); Task_user1_1.IsFinished = false;
            var user1Tasks = new List<DTask>() { Task_user1_1, Task_user1_2 };

            //
            var Task_user2_1 = new DTask(); Task_user1_1.IsFinished = true;
            var Task_user2_2 = new DTask(); Task_user1_1.IsFinished = true;
            var user2Tasks = new List<DTask>() { Task_user2_1, Task_user2_2 };

            //Assign tasks
            dTasklist.Add(dUser_1, user1Tasks);
            dTasklist.Add(dUser_2, user2Tasks);


            return dTasklist;
        }
    }


    
}

