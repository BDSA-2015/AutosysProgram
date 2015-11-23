using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLogics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.ExportManagement;

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
            exportHandler = new ExportHandler(new CSVConverter());
        }

        [TestMethod()]
        public void ExportCsvFileTest()
        {
            //Arrange
            var protocol = new Protocol();

            //Act
            exportHandler.ExportCsvFile(protocol);

            //Assert
        }

        [TestMethod()]
        public void ExportPdfFileTest()
        {
            throw new NotImplementedException();
        }
    }
}