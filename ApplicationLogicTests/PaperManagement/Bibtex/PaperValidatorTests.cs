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
            var fields = new Dictionary<EnumField, string>()
            {
                {EnumField.Author, "Professor Clever"},
                {EnumField.Year, "2015"},
                {EnumField.Title, "How to see sharp" }
            };
            var paper = new Paper(EnumEntry.Article, fields);

            //Assert
            Assert.IsTrue(validator.IsPaperValid(paper));
        }

        [TestMethod()]
        public void IsPaperValidMissingAuthorTest()
        {
            //Arrange
            var validator = new PaperValidator();
            var fields = new Dictionary<EnumField, string>()
            {
                {EnumField.Year, "2015"},
                {EnumField.Booktitle, "How to see sharp" }
            };
            var paper = new Paper(EnumEntry.Article, fields);

            //Assert
            Assert.IsFalse(validator.IsPaperValid(paper));
        }

        [TestMethod()]
        public void IsPaperValidMissingTitleTest()
        {
            //Arrange
            var validator = new PaperValidator();
            var fields = new Dictionary<EnumField, string>()
            {
                {EnumField.Author, "Professor Clever"},
                {EnumField.Year, "2015"},
            };
            var paper = new Paper(EnumEntry.Article, fields);

            //Assert
            Assert.IsFalse(validator.IsPaperValid(paper));
        }

        [TestMethod()]
        public void IsPaperValidMissingYearTest()
        {
            //Arrange
            var validator = new PaperValidator();
            var fields = new Dictionary<EnumField, string>()
            {
                {EnumField.Author, "Professor Clever"},
                {EnumField.Booktitle, "How to see sharp" }
            };
            var paper = new Paper(EnumEntry.Article, fields);

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