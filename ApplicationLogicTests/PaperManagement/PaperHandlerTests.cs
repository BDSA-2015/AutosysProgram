using System;
using System.Collections.Generic;
using System.Linq;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.StorageFasade;
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
        private Mock<IRepository<StoredPaper>> _mockRepo;
        private PaperHandler _paperHandler;

        [TestInitialize()]
        public void Initialize()
        {
            _mockRepo = new Mock<IRepository<StoredPaper>>();
            AutoMapper.Mapper.CreateMap<Paper, StoredPaper>();
            _paperHandler = new PaperHandler(new BibtexParser(), new PaperFacade(_mockRepo.Object));
        }

        /// <summary>
        /// Tests the import of a single bibtex file as a Paper
        /// </summary>
        [TestMethod()]
        public void ImportSinglePaperTest()
        {
            //Arrange
            var parser = new BibtexParser();

            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will Newman");
            fieldValues.Add("My book");
            fieldValues.Add("1905");

            var paper = new Paper("article", fieldTypes, fieldValues);

            var mapperPaper = AutoMapper.Mapper.Map<StoredPaper>(paper);
            _mockRepo.Setup(r => r.Create(mapperPaper)).Returns(mapperPaper.Id);

            var file = "@book{839269," +
                       "author = {Will Newman}," +
                       "title = {My book}," +
                       "year = {1905}}";

            //Act
            var paperIds = _paperHandler.ImportBibtex(file);

            //Assert
            Assert.IsTrue(paperIds.Count() == 1 && paperIds.First() == 0);

        }

        /// <summary>
        /// Tests the import of multiple papers
        /// </summary>
        [TestMethod()]
        public void ImportMultiplePapers()
        {
            //Arrange
            var fieldTypes1 = new List<string>();
            fieldTypes1.Add("author");
            fieldTypes1.Add("title");
            fieldTypes1.Add("year");
            var fieldValues1 = new List<string>();
            fieldValues1.Add("Xavier D ecoret");
            fieldValues1.Add("PyBiTex");
            fieldValues1.Add("2003");
            var fieldTypes2 = new List<string>();
            fieldTypes2.Add("author");
            fieldTypes2.Add("title");
            fieldTypes2.Add("year");
            var fieldValues2 = new List<string>();
            fieldValues2.Add("Xavier D ecoret");
            fieldValues2.Add("A {bunch {of} braces {in}} title");
            fieldValues2.Add("1700");
            var fieldTypes3 = new List<string>();
            fieldTypes3.Add("author");
            fieldTypes3.Add("title");
            fieldTypes3.Add("year");
            var fieldValues3 = new List<string>();
            fieldValues3.Add("Simon the saint Templar");
            fieldValues3.Add("Something nice");
            fieldValues3.Add("700");
            
            //Testing papers
            var paper1 = new Paper("article", fieldTypes1, fieldValues1);
            var paper2 = new Paper("article", fieldTypes2, fieldValues2);
            var paper3 = new Paper("article", fieldTypes3, fieldValues3);

            //paper1 mock setup
            var mapperPaper1 = AutoMapper.Mapper.Map<StoredPaper>(paper1);
            _mockRepo.Setup(r => r.Create(mapperPaper1)).Returns(mapperPaper1.Id);

            //paper2 mock setup
            var mapperPaper2 = AutoMapper.Mapper.Map<StoredPaper>(paper2);
            _mockRepo.Setup(r => r.Create(mapperPaper2)).Returns(mapperPaper2.Id);

            //paper3 mock setup
            var mapperPaper3 = AutoMapper.Mapper.Map<StoredPaper>(paper3);
            _mockRepo.Setup(r => r.Create(mapperPaper3)).Returns(mapperPaper3.Id);

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
            var receivedFile = JsonConvert.SerializeObject(file);
            var paperIDs = _paperHandler.ImportBibtex(JsonConvert.DeserializeObject<string>(receivedFile));

            //Assert
            Assert.IsTrue(paperIDs.Count() == 3);
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