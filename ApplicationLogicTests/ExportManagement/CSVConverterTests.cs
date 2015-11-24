using Microsoft.VisualStudio.TestTools.UnitTesting;
using ApplicationLogics.ExportManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.ExportManagement.Tests
{
    [TestClass()]
    public class CsvConverterTests
    {
        private CsvConverter _converter;
        [TestInitialize]
        public void Initialize()
        {
            _converter = new CsvConverter();
        }

        [TestMethod()]
        public void ConvertEmptyAcceptedInputTest()
        {
            //Arrange
            var protocol = new Protocol();
            protocol.ExclusionCriteria = new List<Criteria>();
            protocol.InclusionCriteria = new List<Criteria>();

            //Act
            CsvFile csvFile = _converter.Convert(protocol) as CsvFile;

            //Assert
            Assert.AreEqual(ExportType.CSV, csvFile.Type);
            Assert.AreEqual("", csvFile.ExclusionData);
            Assert.AreEqual("", csvFile.InclusionData);
        }

        [TestMethod()]
        public void ConvertSingleAcceptedInputTest()
        {
            //Arrange
            var protocol = new Protocol();
            protocol.ExclusionCriteria = new List<Criteria>();
            protocol.InclusionCriteria = new List<Criteria>();

            //Act
                protocol.ExclusionCriteria.Add(new Criteria() { Name = $"criteria{0}" });
                protocol.InclusionCriteria.Add(new Criteria() { Name = $"criteria{0}" });

            CsvFile csvFile = _converter.Convert(protocol) as CsvFile;

            //Assert
            Assert.AreEqual(ExportType.CSV, csvFile.Type);
            Assert.AreEqual("criteria0", csvFile.ExclusionData);
            Assert.AreEqual("criteria0", csvFile.InclusionData);
        }

        [TestMethod()]
        public void ConvertManyAcceptedInputTest()
        {
            //Arrange
            var protocol = new Protocol();
            protocol.ExclusionCriteria = new List<Criteria>();
            protocol.InclusionCriteria = new List<Criteria>();

            //Act
            for (int i = 0; i < 3; i++)
            {
                protocol.ExclusionCriteria.Add(new Criteria() {Name = $"criteria{i}"});
                protocol.InclusionCriteria.Add(new Criteria() { Name = $"criteria{i}" });
            }

            CsvFile csvFile = _converter.Convert(protocol) as CsvFile;

            //Assert
            Assert.AreEqual(ExportType.CSV, csvFile.Type);
            Assert.AreEqual("criteria0,criteria1,criteria2", csvFile.ExclusionData);
            Assert.AreEqual("criteria0,criteria1,criteria2", csvFile.InclusionData);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertNullCriteriaInputTest()
        {
            //Arrange
            var protocol = new Protocol();
            protocol.ExclusionCriteria = new List<Criteria>();
            protocol.InclusionCriteria = new List<Criteria>();

            //Act
                protocol.ExclusionCriteria.Add(null);

            CsvFile csvFile = _converter.Convert(protocol) as CsvFile;
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertCriteriaNameNullInputTest()
        {
            //Arrange
            var protocol = new Protocol();
            protocol.ExclusionCriteria = new List<Criteria>();
            protocol.InclusionCriteria = new List<Criteria>();

            //Act
            protocol.ExclusionCriteria.Add(new Criteria() {Name = null});

            CsvFile csvFile = _converter.Convert(protocol) as CsvFile;
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertCriteriaNameEmptyInputTest()
        {
            //Arrange
            var protocol = new Protocol();
            protocol.ExclusionCriteria = new List<Criteria>();
            protocol.InclusionCriteria = new List<Criteria>();

            //Act
            protocol.ExclusionCriteria.Add(new Criteria() { Name = "" });

            CsvFile csvFile = _converter.Convert(protocol) as CsvFile;
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertNullCriteriaListInputTest()
        {
            //Act
            CsvFile csvFile = _converter.Convert(null) as CsvFile;
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConvertNullProtocolInputTest()
        {
            //Act
            CsvFile csvFile = _converter.Convert(null) as CsvFile;
        }


    }
}