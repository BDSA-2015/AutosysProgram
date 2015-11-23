using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.ExportManagement;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.Tests
{
    [TestClass()]
    public class ExportHandlerTests
    {
        private ExportHandler exportHandler;

        [TestInitialize()]
        public void Initialize()
        {
            //Arrange
            exportHandler = new ExportHandler();
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

            //Act
            var exportFile = exportHandler.ExportCsvFile(protocol);

            //Assert
            Assert.AreEqual(0, exportFile.Id);
            Assert.AreEqual(ExportType.CSV, exportFile.Type);
            Assert.AreEqual(protocol.Description, exportFile.Description);
            Assert.AreEqual(protocol.Id, exportFile.Origin);
            Assert.AreEqual("Medicine,Health", exportFile.ExclusionData);
            Assert.AreEqual("Software,PC", exportFile.InclusionData);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExportCsvFileNullInputTest()
        {
            //Act
            var exportFile = exportHandler.ExportCsvFile(null);
        }

        //[TestMethod()]
        //public void ExportPdfFileTest()
        //{
        //    throw new NotImplementedException();
        //}
    }
}