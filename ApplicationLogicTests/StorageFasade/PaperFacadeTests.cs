using System;
using System.Collections.Generic;
using ApplicationLogics.PaperManagement.Bibtex;
using ApplicationLogics.StorageFasade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace ApplicationLogicTests.StorageFasade
{
    [TestClass()]
    public class PaperFacadeTests
    {
        private Mock<IRepository<StoredPaper>> mockRepo;
        private PaperFacade _facade;

        [TestInitialize()]
        public void Initialize()
        {
            mockRepo = new Mock<IRepository<StoredPaper>>();
            _facade = new PaperFacade(mockRepo.Object);
        }

        /// <summary>
        /// Test the creation of a single paper, by checking the paperId 
        /// </summary>
        [TestMethod()]
        public void CreatePaperTest()
        {
            //Arrange
            AutoMapper.Mapper.CreateMap<Paper, StoredPaper>();
            var storedPaper = new StoredPaper() {Id = 0, Type = "article"};
            mockRepo.Setup(r => r.Create(storedPaper)).Returns(storedPaper.Id);
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will BeGood");
            fieldValues.Add("1905");
           
            var paper = new Paper("article", fieldTypes, fieldValues);

            //Act
            var paperId = _facade.Create(paper);

            //Assert
            Assert.IsTrue(paperId == 0);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreatePaperNullTest()
        {
            //Arrange
            var storedPaper = new StoredPaper() { Id = 0, Type = "article" };
            mockRepo.Setup(r => r.Create(storedPaper)).Returns(storedPaper.Id);

            //Act
            var paperId = _facade.Create(null);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            //Arrange
           
            //Act
            
            //Assert
            
        }

        [TestMethod()]
        public void ReadTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void ReadTest1()
        {
            throw new NotImplementedException();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            throw new NotImplementedException();
        }
    }
}