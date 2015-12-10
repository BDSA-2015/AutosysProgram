//// CSVConverterTests.cs is a part of Autosys project in BDSA-2015. Created: 24, 11, 2015.
//// Creaters: Dennis Thinh Tan Nguyen, William Diedricsehn Marstrand, Thor Valentin Aakjær Olesen Nielsen, 
//// Jacob Mullit Møiniche.

using System;
using System.Collections.Generic;
using ApplicationLogics.ExportManagement;
using ApplicationLogics.ExportManagement.CsvConverter;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.ExportManagement
{
    /// <summary>
    /// Class for testing the conversion of Protocol Objects to strings following the European CSV format
    /// using a ; as separator as described at https://en.wikipedia.org/wiki/Comma-separated_values
    /// </summary>
    [TestClass]
    public class CsvConverterTests
    {
        private CsvConverter _converter;

        [TestInitialize]
        public void Initialize()
        {
            _converter = new CsvConverter();
        }

        /// <summary>
        /// Tests the conversion to a CSV formatted string of a Protocol with only one exclusion and inclusion criteria
        /// </summary>
        [TestMethod]
        public void ConvertSingleExAndInCriteriaProtocolTest()
        {
            //Arrange
            var protocol = new Protocol()
            {
                StudyName = "Software Study", Description = "For fun",
                Phases = new List<Phase>()
                {
                    new Phase()
                    {
                        ExclusionCriteria = new List<Criteria>()
                        {
                            new Criteria() {Name = "Fruit Products", Description = "Not eatable"}
                        },
                        InclusionCriteria = new List<Criteria>()
                        {
                            new Criteria() {Name = "Windows", Description = "See the light"}
                        },
                        AssignedRole = new Dictionary<Role, List<User>>()
                        {
                            
                        },
                        AssignedTask = new Dictionary<TaskRequest, List<User>>()
                        {
                            
                        },
                        Reports = new List<Paper>()
                        {
                            
                        },
                        UnassignedTasks = new List<TaskRequest>()
                    }
                }
            };   

            //Act
            var csvFile = _converter.Convert(protocol);

            //Assert
            Assert.IsTrue(csvFile.Contains("Study;Study Description;Phase;Exclusion Criteria;Inclusion Criteria;" +
                               "Assigned Tasks;Assigned Roles;Unassigned Tasks;Resources;" +
                                           "Software Study;For fun;Phase1;Fruit Products,;Windows,"));
        }

        /// <summary>
        /// Tests the conversion to a CSV formatted string of a Protocol with multiple exclusion and inclusion criteria
        /// </summary>
        [TestMethod]
        public void ConvertMultipleExAndInCriteriaProtocolTest()
        {
            //Arrange
            var protocol = new Protocol()
            {
                StudyName = "Software Study",
                Description = "For fun",
                Phases = new List<Phase>()
                {
                    new Phase()
                    {
                        ExclusionCriteria = new List<Criteria>()
                        {
                            new Criteria() {Name = "Fruit Products", Description = "Not eatable"},
                            new Criteria() {Name = "Pricy Hardware", Description = "Unaffordable"},
                            new Criteria() {Name = "Bad stuff", Description = "Bad"}
                        },
                        InclusionCriteria = new List<Criteria>()
                        {
                            new Criteria() {Name = "Windows", Description = "See the light"},
                            new Criteria() {Name = "Quality Hardware", Description = "Powerful"}
                        },
                        AssignedRole = new Dictionary<Role, List<User>>()
                        {

                        },
                        AssignedTask = new Dictionary<TaskRequest, List<User>>()
                        {

                        },
                        Reports = new List<Paper>()
                        {

                        },
                        UnassignedTasks = new List<TaskRequest>()
                    }
                }
            };

            //Act
            var csvFile = _converter.Convert(protocol);

            //Assert
            Assert.IsTrue(csvFile.Contains("Study;Study Description;Phase;Exclusion Criteria;Inclusion Criteria;" +
                               "Assigned Tasks;Assigned Roles;Unassigned Tasks;Resources;" +
                                           "Software Study;For fun;Phase1;Fruit Products,Pricy Hardware,Bad stuff,;" +
                                           "Windows,Quality Hardware,"));
        }
    }
}