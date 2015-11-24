using System;
using System.Collections.Generic;
using ApplicationLogics;
using ApplicationLogics.ExportManagement;
using ApplicationLogics.StudyManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ApplicationLogicTests.ExportManagement
{
    [TestClass()]
    public class ExportHandlerTests
    {
        private ExportHandler _exportHandler;

        [TestInitialize()]
        public void Initialize()
        {
            //Arrange
            _exportHandler = new ExportHandler();
        }

        [TestMethod()]
        public void ExportCsvFileLegalInputTest()
        {
            //Arrange
            var protocol = new Protocol();
            protocol.ExclusionCriteria = new List<Criteria>()
            {
                new Criteria() {Id = 0, Name = "Medicine",
                                    Description = "Don't take to much"},
                new Criteria() {Id = 1, Name = "Health",
                                    Description = "Be healthful.."}
            };
            protocol.InclusionCriteria = new List<Criteria>()
            {
                 new Criteria() {Id = 0, Name = "Software",
                                    Description = "Uhh so soft"},
                new Criteria() {Id = 1, Name = "PC",
                                    Description = "For your personal use.."}
            };
            protocol.Id = 0;
            protocol.Description = "This is a protocol";
            var serializedExportFile = _exportHandler.ExportCsvFile(protocol);

            //Assert
            var deserializedExportFile = JsonConvert.DeserializeObject<CsvFile>(serializedExportFile);
            Assert.AreEqual(0, deserializedExportFile.Id);
            Assert.AreEqual(protocol.Description, deserializedExportFile.Description);
            Assert.AreEqual(protocol.Id, deserializedExportFile.Origin);
            Assert.AreEqual("Medicine,Health", deserializedExportFile.ExclusionCriteria);
            Assert.AreEqual("Software,PC", deserializedExportFile.InclusionCriteria);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExportCsvFileNullInputTest()
        {
            //Act
            var exportFile = _exportHandler.ExportCsvFile(null);
        }

        //[TestMethod()]
        //public void ExportPdfFileTest()
        //{
        //    throw new NotImplementedException();
        //}
    }
}