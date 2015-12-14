using System;
using System.IO;
using System.Linq;
using ApplicationLogics.PaperManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.PaperManagement
{
    /// <summary>
    ///     Class for testing the parsing of bibtex files into the program
    /// </summary>
    [TestClass]
    public class BibtexParserTests
    {
        private BibtexParser _parser;

        [TestInitialize]
        public void Initialize()
        {
            _parser = new BibtexParser();
        }

        /// <summary>
        ///     Tests the parsing of a bibtex file
        ///     by checking that the Paper is referring to the correct resource
        /// </summary>
        [TestMethod]
        public void ParseValidPaperResourceTest()
        {
            //Arrange
            var file = "@book{ 839269," +
                       "author = { David A. Aaker}," +
                       "title = { Multivariate Analysis in Marketing}," +
                       "edition = { 2}," +
                       "publisher = { The Scientific Press}," +
                       "year = { 1981}," +
                       "address = { Palo Alto}," +
                       "topic = { multivariate - statistics; market - research;}}";

            //Act
            var papers = _parser.ParseToPapers(file);

            //Assert
            Assert.IsTrue(papers.ElementAt(0).ResourceRef == "839269");
        }

        /// <summary>
        ///     Tests the parsing of a bibtex file
        ///     by checking that entry types are parsed correctly and saved in a Paper
        /// </summary>
        [TestMethod]
        public void ParseValidPaperEntryTest()
        {
            //Arrange
            var file = "@book{ 839269," +
                       "author = {David A. Aaker}}";

            //Act
            var papers = _parser.ParseToPapers(file);

            //Assert
            Assert.IsTrue(papers.ElementAt(0).Type == "book");
        }

        /// <summary>
        ///     Tests the parsing of a bibtex file
        ///     by checking that fields are parsed correctly and saved in a Paper
        /// </summary>
        [TestMethod]
        public void ParseValidPaperFieldTest()
        {
            //Arrange
            var file = "@book{ 839269," +
                       "author = {David A. Aaker}}";

            //Act
            var papers = _parser.ParseToPapers(file);

            //Assert
            Assert.IsTrue(papers.ElementAt(0).FieldTypes.ElementAt(0) == "author" &&
                          papers.ElementAt(0).FieldValues.ElementAt(0) == "David A. Aaker");
        }

        /// <summary>
        ///     Tests the parsing of a bibtex file where the entry e.g. (article, book, ...) is missing
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (InvalidDataException))]
        public void ParseMissingEntryTest()
        {
            //Arrange
            var file = "@ {839269," +
                       "author  {David A. Aaker}," +
                       "title = {Multivariate Analysis in Marketing}," +
                       "edition = {2}," +
                       "publisher = {The Scientific Press}," +
                       "year = {1981}," +
                       "address = {Palo Alto}," +
                       "topic = {multivariate - statistics; market - research;}}";

            //Act
            var papers = _parser.ParseToPapers(file);
        }

        /// <summary>
        ///     Tests the parsing of a bibtex file where the enclosing start and end brackets are missing
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (InvalidDataException))]
        public void ParseMissingStartAndEndBracketsTest()
        {
            //Arrange
            var file = "@book 839269," +
                       "author = {David A. Aaker}," +
                       "title = {Multivariate Analysis in Marketing}," +
                       "year = {1981;}";

            //Act
            var papers = _parser.ParseToPapers(file);
        }

        /// <summary>
        ///     Tests that the parsing of an empty input i handled correctly
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ParseEmptyInputTest()
        {
            //Act
            var papers = _parser.ParseToPapers("");
        }
    }
}