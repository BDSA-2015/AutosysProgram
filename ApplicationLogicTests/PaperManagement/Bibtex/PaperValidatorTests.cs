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
            var fields = new Dictionary<DefaultEnumField, string>()
            {
                {DefaultEnumField.Author, "Professor Clever"},
                {DefaultEnumField.Year, "2015"},
                {DefaultEnumField.Title, "How to see sharp" }
            };
            var paper = new Paper(DefaultEnumEntry.Article, fields);

            //Assert
            Assert.IsTrue(validator.IsPaperValid(paper));
        }

        [TestMethod()]
        public void IsPaperValidMissingAuthorTest()
        {
            //Arrange
            var validator = new PaperValidator();
            var fields = new Dictionary<DefaultEnumField, string>()
            {
                {DefaultEnumField.Year, "2015"},
                {DefaultEnumField.Booktitle, "How to see sharp" }
            };
            var paper = new Paper(DefaultEnumEntry.Article, fields);

            //Assert
            Assert.IsFalse(validator.IsPaperValid(paper));
        }

        [TestMethod()]
        public void IsPaperValidMissingTitleTest()
        {
            //Arrange
            var validator = new PaperValidator();
            var fields = new Dictionary<DefaultEnumField, string>()
            {
                {DefaultEnumField.Author, "Professor Clever"},
                {DefaultEnumField.Year, "2015"},
            };
            var paper = new Paper(DefaultEnumEntry.Article, fields);

            //Assert
            Assert.IsFalse(validator.IsPaperValid(paper));
        }

        [TestMethod()]
        public void IsPaperValidMissingYearTest()
        {
            //Arrange
            var validator = new PaperValidator();
            var fields = new Dictionary<DefaultEnumField, string>()
            {
                {DefaultEnumField.Author, "Professor Clever"},
                {DefaultEnumField.Booktitle, "How to see sharp" }
            };
            var paper = new Paper(DefaultEnumEntry.Article, fields);

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