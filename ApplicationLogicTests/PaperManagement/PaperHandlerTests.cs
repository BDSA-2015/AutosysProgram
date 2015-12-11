using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.StorageFasade;
using ApplicationLogics.StorageFasade.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using Storage.Models;
using Storage.Repository;
using Storage.Repository.Interface;

namespace ApplicationLogicTests.PaperManagement
{
    /// <summary>
    /// Class for testing the PaperHandler which handles import of papers
    /// </summary>
    [TestClass()]
    public class PaperHandlerTests
    {
        private Mock<IFacade<Paper>> _facade;
        private PaperHandler _paperHandler;

        [TestInitialize()]
        public void Initialize()
        {
            _facade = new Mock<IFacade<Paper>>();
            AutoMapper.Mapper.CreateMap<Paper, StoredPaper>();
            _paperHandler = new PaperHandler(new BibtexParser(), _facade.Object);
        }

        /// <summary>
        /// Tests the import of a single bibtex file as a Paper
        /// </summary>
        [TestMethod()]
        public void ImportSinglePaperTest()
        {
            //Arrange
            _facade.Setup(r => r.Create(It.IsAny<Paper>())).Returns(0);

            var file = "@book{839269," +
                       "author = {Will Newman}," +
                       "title = {My book}," +
                       "year = {1905}}";

            //Act
            _paperHandler.ImportBibtex(file);

            //Assert
            _facade.Verify(r => r.Create(It.IsAny<Paper>()), Times.Once());

        }

        /// <summary>
        /// Tests the import of multiple papers
        /// </summary>
        [TestMethod()]
        public void ImportMultiplePapers()
        {
            //mock setup
            _facade.Setup(r => r.Create(It.IsAny<Paper>()));


            var file = "@Article{py03," +
                       "author = {Xavier D ecoret}," +
                       "title = {PyBiTex}," +
                       "year = {2003}}"+

                       "@Article{key03," +
                       "author = {Xavier D ecoret}," +
                       "title = {A {bunch {of} braces {in}} title}," +
                       "year = {2003}}"+

                       "@Article{key01," +
                       "author = {Simon the saint Templar}," +
                       "title = {Something nice}," +
                       "year = {700}}";

            //Act
            _paperHandler.ImportBibtex(file);

            //Assert
            _facade.Verify(r => r.Create(It.IsAny<Paper>()), Times.Exactly(3));
        }

        /// <summary>
        /// Tests the import of a bibtex file which is null
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ImportNullBibtex()
        {
            //Act
            _paperHandler.ImportBibtex(null);
        }

        /// <summary>
        /// Tests the import of a bibtex file which is empty
        /// </summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ImportEmptyBibtex()
        {
            //Act
            _paperHandler.ImportBibtex("");
        }
    }
}