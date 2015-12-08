using System;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    /// <summary>
    /// Class for testing the validation of Papers through the predefined 
    /// paper checker
    /// </summary>
    [TestClass()]
    public class PaperCheckerTests
    {
        private PaperChecker _defaultChecker;

        [TestInitialize()]
        public void Initialize()
        {
            _defaultChecker = new PaperChecker();
        }

        /// <summary>
        /// Tests papers which should hold a valid bibtex type and valid fields
        /// </summary>
        [TestMethod()]
        public void ValidateValidPaperTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("William McSomething");
            fieldValues.Add("Insatiate Your Dreams");
            fieldValues.Add("2015");
            
            var paper = new Paper("year", fieldTypes, fieldValues);

            //Assert
            Assert.IsTrue(_defaultChecker.Validate(paper));
        }

        /// <summary>
        /// Tests papers which should hold an invalid bibtex type and invalid fields
        /// </summary>
        [TestMethod()]
        public void ValidateInvalidPaperTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            var fieldValues = new List<string>();
            fieldValues.Add("\nInvalid");
            var paper = new Paper("phdthesis", fieldTypes, fieldValues);

            //Assert
            Assert.IsFalse(_defaultChecker.Validate(paper));
        }

        /// <summary>
        /// Tests the validation of a Paper which has type null.
        /// The paper should not be valid
        /// </summary>
        [TestMethod()]
        public void ValidateNullTypePaperTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            var fieldValues = new List<string>();
            
            //Act
            fieldTypes.Add("author");
            fieldValues.Add("Somebody");
            var paper = new Paper(null, fieldTypes, fieldValues);

            //Assert
            Assert.IsFalse(_defaultChecker.Validate(paper));
        }

        /// <summary>
        /// Tests the validation of a Paper which has type null.
        /// The paper should not be valid
        /// </summary>
        [TestMethod()]
        public void ValidateNullPaperTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            var fieldValues = new List<string>();

            //Act
            fieldTypes.Add("author");
            fieldValues.Add("Somebody");
            var paper = new Paper(null, fieldTypes, fieldValues);

            //Assert
            Assert.IsFalse(_defaultChecker.Validate(paper));
        }
    }
}