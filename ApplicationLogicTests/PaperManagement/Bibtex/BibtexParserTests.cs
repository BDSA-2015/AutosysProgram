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

        [TestCase("athor", "William, Funstuff")]
        [TestCase("booktitle", "ITU student anno 2015")]
        [TestCase("title", "A student's thoughts on programming")]
        [TestCase("year", "2015")]
        [TestCase("month", "Aug")]
        [TestCase("volume", "1")]
        public void ParseDefaultInputPaperTest(string field, string data)
        {
            //Arrange
            var file = Properties.Resources.valid1;
            var fileString = System.Text.Encoding.Default.GetString(file);

            //Act
            var papers = _parser.Parse(fileString);

            //Assert
            var validPaper = papers[0];

            Assert.AreEqual(validPaper.Fields[field], data);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseDefaultValidatorMissingAuthorTypeInputTest()
        {
            //Arrange
            var bibtexInput = Properties.Resources.missingauthor1;
            var invalidFile = System.Text.Encoding.Default.GetString(bibtexInput);
            //Act
            var papers = _parser.Parse(invalidFile);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseDefaultValidatorMissingStartInputTest()
        {
            //Arrange
            var bibtexInput = Properties.Resources.missingstarttag1;
            var invalidFile = System.Text.Encoding.Default.GetString(bibtexInput);
            var papers = _parser.Parse(invalidFile);
        }

        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseDefaultValidatorMissingBracketTypeInputTest()
        {
            //Arrange
            var bibtexInput = Properties.Resources.missingbrackets1;
            var invalidFile = System.Text.Encoding.Default.GetString(bibtexInput);
            //Act
            var papers = _parser.Parse(invalidFile);
        }
    }
}