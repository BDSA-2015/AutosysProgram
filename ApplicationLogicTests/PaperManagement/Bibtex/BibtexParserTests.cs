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
        /// by checking that the Paper is referring to the correct resource
        /// </summary>
        [TestMethod()]
        public void ParseDefaultInputResourceRefPaperTest()
        {
            //Arrange
            var file = Properties.Resources.valid1;
            var fileString = System.Text.Encoding.Default.GetString(file);

            //Act
            var papers = _parser.Parse(fileString);

            //Assert
            Assert.IsTrue(papers.ElementAt(0).ResourceRef == "839269");
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

            //Act
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