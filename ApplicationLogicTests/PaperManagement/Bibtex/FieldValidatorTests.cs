using System;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    [TestClass()]
    public class FieldValidatorTests
    {
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

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsFieldValidEmptyDefaultTest()
        {
            //Arrange
            FieldValidator validator = new FieldValidator();

            //Act
            validator.IsFieldValid("", "address");

        }

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