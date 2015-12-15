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
            aStage.CompletedTasks = new Dictionary<int, int>() { { 0, 100 }, { 1, 100} };
            aStage.IncompleteTasks = new Dictionary<int, int>() { { 0, 3 }, { 1, 200 } };
            aStage.Name = "first Phase";

            var dStage = new DStage();
            dStage.
            dStage.CompletedTasks = new Dictionary<int, int>() { { 0, 100 }, { 1, 100 } };
            dStage.IncompleteTasks = new Dictionary<int, int>() { { 0, 3 }, { 1, 200 } };
            dStage.Name = "first Phase";

            //Act

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
    }
}

namespace WebApi.Mapping.Tests
{
    [TestClass()]
    public class StudyEntitiesMappingTest
    {
        StudyEntitiesMapping _entityMapper;

        [TestInitialize]
        public void CreateDataMapping()
        {
            _entityMapper = new StudyEntitiesMapping();
        }

        [TestMethod()]
        public void CreateConflictingDataMappingTest()
        {
            //Arrange
            var DConflictData = new DatabaseConflictingData();
            DConflictData.Data =  new string[]{ "True","False,True"};
            DConflictData.UserId = 3;
            
            var AConflictingData = new APIConflictingData();
            AConflictingData.Data = new string[] { "True", "False,True" };
            AConflictingData.UserId = 3;
            //Act
            var newAConflictData = AutoMapper.Mapper.Map<APIConflictingData>(DConflictData);
            //Assert
            Assert.AreEqual(AConflictingData, newAConflictData);
        }

        

        [TestMethod()]
        public void CreateDataFieldMappingTest()
        {
            var AField = new ADataField();

            AField.Data = new string[] { "Some data describing the task" };
            AField.Description = "Does the text contains the word 'Software'";
            AField.FieldType = ADataField.DataType.Boolean;
            AField.Name = "Contains -Software";
            AField.TypeInfo = new string[] { "True", "False" };
            


            Assert.Fail();



        }

        [TestMethod()]
        public void CreatePhaseMappingTest()
        {
            var stage = new StageOverview();
            stage.Name = "TestStage";
            stage.CompletedTasks = new Dictionary<int, int>() { {0,100}, {1,100}, {2,200}};
            stage.IncompleteTasks = new Dictionary<int, int>() { {0,100}, {1,0}, {2,5} };

            
        }

        [TestMethod()]
        public void CreateRoleMappingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateStudyMappingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateStudyManagerMappingTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void CreateTaskRequestMappingTest()
        {
            Assert.Fail();
        }
    }
}