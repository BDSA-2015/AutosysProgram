using System;
using ApplicationLogics.ExportManagement;
using ApplicationLogicTests.ExportManagement.Mock;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

namespace ApplicationLogicTests.ExportManagement
{
    /// <summary>
    /// Class for testing the ExportHandler which handles the export of protocols
    /// in different formats e.g. CSV
    /// </summary>
    [TestClass()]
    public class ExportHandlerTests
    {
        private ExportHandler _handler;

        [TestInitialize()]
        public void Initialize()
        {
            _handler = new ExportHandler();
        }

        /// <summary>
        /// Test the export of a csv formatted string send as JSON
        /// </summary>
        [TestMethod()]
        public void ExportCsvFile()
        {
            //Arrange
            var protocol = ProtocolMock.CreateProtocolMock();

            //Act
            var exportFile = _handler.ExportCsvFile(protocol);
            var testFile = JsonConvert.SerializeObject(ProtocolMock.OutPut());

            //Assert
            Assert.AreEqual(testFile, exportFile);
        }

        /// <summary>
        /// Test if a null input to the method is handled correct
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExportCsvFileProtocolNullTest()
        {
            //Act
            _handler.ExportCsvFile(null);
        }
    }
}