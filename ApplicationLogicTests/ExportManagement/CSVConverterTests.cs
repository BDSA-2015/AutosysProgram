using System;
using System.Collections.Generic;
using ApplicationLogics.ExportManagement;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StudyManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.ExportManagement
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
            Assert.AreEqual("", csvFile.ExclusionCriteria);
            Assert.AreEqual("", csvFile.InclusionCriteria);
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
            Assert.AreEqual("criteria0", csvFile.ExclusionCriteria);
            Assert.AreEqual("criteria0", csvFile.InclusionCriteria);
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
            Assert.AreEqual("criteria0,criteria1,criteria2", csvFile.ExclusionCriteria);
            Assert.AreEqual("criteria0,criteria1,criteria2", csvFile.InclusionCriteria);
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

            var csvFile = _converter.Convert(protocol) as CsvFile;
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