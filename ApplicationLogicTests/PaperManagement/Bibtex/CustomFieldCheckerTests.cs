using System;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    /// <summary>
    /// Test class for testing the validation of bibtex fields by a custom made fields checker, which is used by a field validator
    /// </summary>
    [TestClass()]
    public class CustomFieldCheckerTests
    {
        /// <summary>
        /// Tests the validation a single string which should be valid using a custom made regular expression
        /// </summary>
        [TestMethod()]
        public void ValidateCostumCheckerValidInputTest()
        {
            //Arrange
            var checker = new CustomFieldChecker("Will");

            //Act
            var input = "William Swuer";

            //Assert
            Assert.IsTrue(checker.Validate(input));
        }

        /// <summary>
        /// Tests the validation a single string which should be valid using a custom made regular expression
        /// </summary>
        [TestMethod()]
        public void ValidateInvalidInputTest()
        {
            //Arrange
            var checker = new CustomFieldChecker("Simone");

            //Act
            var input = "Simon Swuer";

            //Assert
            Assert.IsFalse(checker.Validate(input));
        }

        /// <summary>
        /// Tests null input for the validation in a custom made field checker method which should be invalid
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ValidateNullTest()
        {
            //Arrange
            var checker = new CustomFieldChecker("[a-zA-Z]*");

            //Act
            checker.Validate(null);
        }
    }
}