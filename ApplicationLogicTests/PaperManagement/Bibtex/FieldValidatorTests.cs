using System;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    /// <summary>
    /// Class for testing the field validator for bibtex fields
    /// </summary>
    [TestClass()]
    public class FieldValidatorTests
    {
        /// <summary>
        /// Tests bibtex fields which should be valid using a field validator
        /// with a default field checker.
        /// </summary>
        [TestMethod()]
        public void IsFieldValidDefaultTest()
        {
            //Arrange
            FieldValidator validator = new FieldValidator();
            var field1 = "Rued Langgaards Vej 102";
            var field2 = "My Name";

            //Assert
            Assert.IsTrue(validator.IsFieldValid(field1, "address"));
            Assert.IsTrue(validator.IsFieldValid(field2, "author"));

        }

        /// <summary>
        /// Tests bibtex fields which should be invalid using a field validator
        /// with a default field checker.
        /// </summary>
        [TestMethod()]
        public void IsFieldInvalidDefaultTest()
        {
            //Arrange
            FieldValidator validator = new FieldValidator();
            var field1 = "Rued Langgaards Vej 102 with \n new line";
            var field2 = "\n My Name on two lines";

            //Assert
            Assert.IsFalse(validator.IsFieldValid(field1, "address"));
            Assert.IsFalse(validator.IsFieldValid(field2, "author"));

        }

        /// <summary>
        /// Tests bibtex fields with empty information which should be invalid
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsFieldValidEmptyDefaultTest()
        {
            //Arrange
            FieldValidator validator = new FieldValidator();

            //Act
            validator.IsFieldValid("", "address");

        }

        /// <summary>
        /// Tests for null input which should be invalid
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsFieldValidNullDefaultTest()
        {
            //Arrange
            FieldValidator validator = new FieldValidator();

            //Act
            validator.IsFieldValid(null, "address");

        }
    }
}