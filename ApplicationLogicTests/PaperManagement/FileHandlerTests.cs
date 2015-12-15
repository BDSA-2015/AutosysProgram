using System;
using System.Linq;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.PaperManagement.Bibtex;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace ApplicationLogicTests.PaperManagement
{
    [TestClass]
    public class FileHandlerTests
    {
        private FileHandler _handler;

        [TestInitialize]
        public void Initialize()
        {
            _handler = new FileHandler(new BibtexParser());
        }

        #region SaveTags

        /// <summary>
        ///     Tests that a 
        /// </summary>
        [TestMethod()]
        public void ParseBibtex_ValidInput_LengthIs4()
        {
            //Arrange
            var file = "@Article{py03," +
                       "author = {Xavier D ecoret}," +
                       "title = {PyBiTex}," +
                       "year = {2003}}" +
                       "@Article{key03," +
                       "author = {Xavier D ecoret}," +
                       "title = {A {bunch {of} braces {in}} title}," +
                       "year = {2003}}" +
                       "@Article{key01," +
                       "author = {Simon the saint Templar}," +
                       "title = {Something nice}," +
                       "year = {700}}";

            //Act
            var tags = _handler.ParseTags(file);

            //Assert
            Assert.IsTrue(tags.Length == 4);

        }

        [TestMethod, ExpectedException(typeof (ArgumentNullException))]
        public void ParseBibtex_NullInput_ExceptionThrown()
        {
            //Act
            _handler.ParseTags(null);
        }

        [TestMethod, ExpectedException(typeof (ArgumentNullException))]
        public void ParseBibtex_EmptyInput_ExceptionThrown()
        {
            //Act
            _handler.ParseTags("");
        }

        #endregion

        #region ImportPaper

        /// <summary>
        ///     Tests the import of a single bibtex file as a Paper
        /// </summary>
        [TestMethod]
        public void ImportBibtex_SinglePaper_PapersCountIs1()
        {
            //Arrange
            var file = "@book{839269," +
                       "author = {Will Newman}," +
                       "title = {My book}," +
                       "year = {1905}}";

            //Act
            var papers = _handler.ParseToPapers(file);

            //Assert
            Assert.IsTrue(papers.Count() == 1);
        }

        /// <summary>
        ///     Tests the import of multiple papers
        /// </summary>
        [TestMethod]
        public void ImportBibtex_3Papers_PapersCountIs3()
        {
            //Arrange
            var file = "@Article{py03," +
                       "author = {Xavier D ecoret}," +
                       "title = {PyBiTex}," +
                       "year = {2003}}" +
                       "@Article{key03," +
                       "author = {Xavier D ecoret}," +
                       "title = {A {bunch {of} braces {in}} title}," +
                       "year = {2003}}" +
                       "@Article{key01," +
                       "author = {Simon the saint Templar}," +
                       "title = {Something nice}," +
                       "year = {700}}";

            //Act
            var papers = _handler.ParseToPapers(file);

            //Assert
            Assert.IsTrue(papers.Count() == 3);
        }

        /// <summary>
        ///     Tests the import of a bibtex file which is null
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ImportBibtex_NullInput_ExceptionThrown()
        {
            //Act
            _handler.ParseToPapers(null);
        }

        /// <summary>
        ///     Tests the import of a bibtex file which is empty
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void ImportBibtex_EmptyInput_ExceptionThrown()
        {
            //Act
            _handler.ParseToPapers("");
        }

        #endregion
    }
}