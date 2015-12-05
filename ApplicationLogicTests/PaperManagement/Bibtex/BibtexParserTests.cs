using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ApplicationLogicTests.PaperManagement.Bibtex
{
    /// <summary>
    /// Class for testing the parsing of bibtex files into the program
    /// </summary>
    [TestClass()]
    public class BibtexParserTests
    {
        private BibtexParser _parser;

        [TestInitialize]
        public void Initialize()
        {
            _parser = new BibtexParser(new PaperValidator());
        }

        /// <summary>
        /// Tests the parsing of a bibtex file using a default field checker
        /// </summary>
        /// <param name="field">The type of a bibtex field</param>
        /// <param name="data">The data associated with a bibtex field</param>
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
            var fieldTypes = new List<string>();
            var fieldValues = new List<string>();

            //Act
            var papers = _parser.Parse(fileString);
            fieldTypes.Add(field);
            fieldValues.Add(data);

            //Assert
            Assert.IsTrue(field == fieldTypes.ElementAt(0) && data == fieldValues.ElementAt(1));
        }

        /// <summary>
        /// Tests the parsing of a bibtex file where the author field is missing
        /// </summary>
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

        /// <summary>
        /// Tests the parsing of a bibtex file where the start @ tag is missing
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(InvalidDataException))]
        public void ParseDefaultValidatorMissingStartInputTest()
        {
            //Arrange
            var bibtexInput = Properties.Resources.missingstarttag1;
            var invalidFile = System.Text.Encoding.Default.GetString(bibtexInput);
            var papers = _parser.Parse(invalidFile);
        }

        /// <summary>
        /// Tests the parsing of a bibtex file where the enclosing brackets are missing
        /// </summary>
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