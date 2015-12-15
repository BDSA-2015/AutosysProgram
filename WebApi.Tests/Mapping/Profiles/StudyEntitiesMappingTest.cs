using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using ApplicationLogics.StudyManagement;
using DatabaseConflictingData = ApplicationLogics.StudyManagement.ConflictingData;
using APIConflictingData = WebApi.Models.ConflictingData;
using DCriteria = ApplicationLogics.StudyManagement.Criteria;
using DDataField = ApplicationLogics.StudyManagement.DataField;
using ADataField = WebApi.Models.DataField;



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