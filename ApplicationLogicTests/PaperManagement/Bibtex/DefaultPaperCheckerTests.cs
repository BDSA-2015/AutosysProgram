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
    public class DefaultPaperCheckerTests
    {
        /// <summary>
        /// Tests papers which should hold a valid bibtex type and valid fields
        /// </summary>
        [TestMethod()]
        public void ValidateValidInputTest()
        {
            //Arrange
            PaperChecker checker = new PaperChecker();
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
            Assert.IsTrue(checker.Validate(paper));
        }

        /// <summary>
        /// Tests papers which should hold an invalid bibtex type and invalid fields
        /// </summary>
        [TestMethod()]
        public void ValidateInvalidFieldTest()
        {
            //Arrange
            PaperChecker checker = new PaperChecker();
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            var fieldValues = new List<string>();
            fieldValues.Add("\nInvalid");
            var paper = new Paper("phdthesis", fieldTypes, fieldValues);

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