using System;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    [TestClass()]
    public class PaperValidatorTests
    {

        [TestMethod()]
        public void IsPaperValidRequiredFieldsTest()
        {
            //Arrange
            var validator = new PaperValidator();
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Professor Clever");
            fieldValues.Add("How to see sharp");
            fieldValues.Add("2015");
            var paper = new Paper("article", fieldTypes, fieldValues);

            //Assert
            Assert.IsTrue(validator.IsPaperValid(paper));
        }

        [TestMethod()]
        public void IsPaperValidMissingAuthorTest()
        {
            //Arrange
            var validator = new PaperValidator();
            var fieldTypes = new List<string>();
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("How to see sharp");
            fieldValues.Add("2015");
          
            var paper = new Paper("article", fieldTypes, fieldValues);

            //Assert
            Assert.IsFalse(validator.IsPaperValid(paper));
        }

        [TestMethod()]
        public void IsPaperValidMissingTitleTest()
        {
            //Arrange
            var validator = new PaperValidator();
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Professor Clever");
            fieldValues.Add("2015");
           
            var paper = new Paper("article", fieldTypes, fieldValues);

            //Assert
            Assert.IsFalse(validator.IsPaperValid(paper));
        }

        [TestMethod()]
        public void IsPaperValidMissingYearTest()
        {
            //Arrange
            var validator = new PaperValidator();
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            var fieldValues = new List<string>();
            fieldValues.Add("Professor Clever");
            fieldValues.Add("How to see sharp");
            
            var paper = new Paper("article", fieldTypes, fieldValues);

            //Assert
            Assert.IsFalse(validator.IsPaperValid(paper));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void IsPaperValidNullTest()
        {
            //Arrange
            var validator = new PaperValidator();

            //Assert
            Assert.IsFalse(validator.IsPaperValid(null));
        }
    }
}