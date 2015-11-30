using System;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    [TestClass()]
    public class DefaultPaperCheckerTests
    {
        [TestMethod()]
        public void ValidateValidInputTest()
        {
            //Arrange
            DefaultPaperChecker checker = new DefaultPaperChecker();
            var fields = new Dictionary<EnumField, string>
            {
                {EnumField.Year, "2015"},
                {EnumField.Author, "William McSomething"}
            };
            var paper = new Paper(EnumEntry.Phdthesis, fields);

            //Assert
            Assert.IsTrue(checker.Validate(paper));
        }

        [TestMethod()]
        public void ValidateInvalidFieldTest()
        {
            //Arrange
            DefaultPaperChecker checker = new DefaultPaperChecker();
            var fields = new Dictionary<EnumField, string> {{EnumField.Author, "\nInvalid"}};
            var paper = new Paper(EnumEntry.Phdthesis, fields);

            //Assert
            Assert.IsFalse(checker.Validate(paper));
        }

        //[TestMethod()]
        //public void ValidateInvalidEntryTest()
        //{
        //    //Arrange
        //    DefaultPaperChecker checker = new DefaultPaperChecker();
        //    var fields = new Dictionary<EnumField, string>();
        //    fields.Add(EnumField.Year, "2015");
        //    fields.Add(EnumField.Author, "William McSomething");
        //    var paper = new Paper("%maliciousPaper", fields);

        //    //Assert
        //    Assert.IsFalse(checker.Validate(paper));
        //}

        //[TestMethod()]
        //public void ValidateEmptyEntryTest()
        //{
        //    //Arrange
        //    DefaultPaperChecker checker = new DefaultPaperChecker();
        //    var fields = new Dictionary<EnumField, string>();
        //    fields.Add("year", "2015");
        //    fields.Add("Author", "William McSomething");
        //    var paper = new Paper("", fields);

        //    //Assert
        //    Assert.IsFalse(checker.Validate(paper));
        //}

        //[TestMethod()]
        //public void ValidateEmptyFieldTest()
        //{
        //    //Arrange
        //    DefaultPaperChecker checker = new DefaultPaperChecker();
        //    var fields = new Dictionary<EnumField, string>();
        //    fields.Add("", "2015");
        //    var paper = new Paper("book", fields);

        //    //Assert
        //    Assert.IsFalse(checker.Validate(paper));
        //}

        //[TestMethod()]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void ValidateNullEntryTest()
        //{
        //    //Arrange
        //    DefaultPaperChecker checker = new DefaultPaperChecker();
        //    var fields = new Dictionary<EnumField, string>();
        //    fields.Add("year", "2015");
        //    var paper = new Paper(null, fields);

        //    //Assert
        //    Assert.IsFalse(checker.Validate(paper));
        //}

        //[TestMethod()]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void ValidateNullPaperTest()
        //{
        //    //Arrange
        //    DefaultPaperChecker checker = new DefaultPaperChecker();

        //    //Assert
        //    Assert.IsFalse(checker.Validate(null));
        //}

        //[TestMethod()]
        //[ExpectedException(typeof(ArgumentNullException))]
        //public void ValidateEmptyFieldsTest()
        //{
        //    //Arrange
        //    DefaultPaperChecker checker = new DefaultPaperChecker();
        //    var fields = new Dictionary<EnumField, string>();
        //    var paper = new Paper("article", fields);

        //    //Assert
        //    Assert.IsFalse(checker.Validate(paper));
        //}
    }
}