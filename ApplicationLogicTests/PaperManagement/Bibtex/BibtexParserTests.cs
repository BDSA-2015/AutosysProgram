using System;
using System.Collections.Generic;
using System.IO;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    [TestClass()]
    public class BibtexParserTests
    {
        private BibtexParser _parser;

        [TestInitialize]
        public void Initialize()
        {
            _parser = new BibtexParser(new PaperValidator());
        }

        [TestCase(DefaultEnumField.Author, "William, Funstuff")]
        [TestCase(DefaultEnumField.Booktitle, "ITU student anno 2015")]
        [TestCase(DefaultEnumField.Title, "A student's thoughts on programming")]
        [TestCase(DefaultEnumField.Year, "2015")]
        [TestCase(DefaultEnumField.Month, "Aug")]
        [TestCase(DefaultEnumField.Volume, "1")]
        public void ParseDefaultInputPaperTest(DefaultEnumField field, string data)
        {
            //Arrange
            var file = Properties.Resources.valid;
            var fileString = System.Text.Encoding.Default.GetString(file);

            //Act
            var papers = _parser.Parse(fileString);

            //Assert
            var validPaper = papers[0];

            Assert.AreEqual(validPaper.DefaultFields[field], data);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseDefaultValidatorMissingAuthorTypeInputTest()
        {
            //Arrange
            var bibtexInput = Properties.Resources.missingAuthor;
            var invalidFile = System.Text.Encoding.Default.GetString(bibtexInput);
            //Act
            var papers = _parser.Parse(invalidFile);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseDefaultValidatorMissingStartInputTest()
        {
            //Arrange
            var bibtexInput = Properties.Resources.missingStartTag;
            var invalidFile = System.Text.Encoding.Default.GetString(bibtexInput);
            var papers = _parser.Parse(invalidFile);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseDefaultValidatorMissingBracketTypeInputTest()
        {
            //Arrange
            var bibtexInput = Properties.Resources.missingBrackets;
            var invalidFile = System.Text.Encoding.Default.GetString(bibtexInput);
            //Act
            var papers = _parser.Parse(invalidFile);
        }
    }
}