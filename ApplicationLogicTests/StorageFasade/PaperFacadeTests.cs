using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using ApplicationLogics.PaperManagement.Bibtex;
using ApplicationLogics.StorageFasade;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
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
            AutoMapper.Mapper.CreateMap<Paper, StoredPaper>();
            AutoMapper.Mapper.CreateMap<StoredPaper, Paper>();
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
            var storedPaper = new StoredPaper() {Id = 0, Type = "article"};
            mockRepo.Setup(r => r.CreateOrUpdate(storedPaper)).Returns(storedPaper.Id);
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will BeGood");
            fieldValues.Add("Life's Questions");
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
            mockRepo.Setup(r => r.CreateOrUpdate(storedPaper)).Returns(storedPaper.Id);

            //Act
            var paperId = _facade.Create(null);
        }

        [TestMethod()]
        public void DeleteObjectNotNullTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will BeGood");
            fieldValues.Add("Life's Questions");
            fieldValues.Add("1905");
            var paper = new Paper("article", fieldTypes, fieldValues);

            StoredPaper callBackPaper = null;
            mockRepo.Setup(r => r.DeleteIfExists(It.IsAny<StoredPaper>())).Callback<StoredPaper>(o => callBackPaper = o);

            //Act
            _facade.Delete(paper);

            //Assert
            Assert.IsNotNull(callBackPaper);
        }

        [TestMethod()]
        public void DeleteObjectCorrectStateTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will BeGood");
            fieldValues.Add("Life's Questions");
            fieldValues.Add("1905");
            var paper = new Paper("article", fieldTypes, fieldValues);

            StoredPaper callBackPaper = null;
            mockRepo.Setup(r => r.DeleteIfExists(It.IsAny<StoredPaper>())).Callback<StoredPaper>(o => callBackPaper = o);

            //Act
            _facade.Delete(paper);

            //Assert
            //TODO Make NUnit TestCase() work and reduce method to a single Assert
            Assert.IsTrue(callBackPaper.Id == 0);
            Assert.IsTrue(callBackPaper.Type == "article");
            Assert.IsTrue(callBackPaper.FieldTypes.Count == 3);
            Assert.IsTrue(callBackPaper.FieldValues.Count == 3);
            Assert.IsTrue(callBackPaper.FieldTypes.ElementAt(0) == "author");
            Assert.IsTrue(callBackPaper.FieldTypes.ElementAt(1) == "title");
            Assert.IsTrue(callBackPaper.FieldTypes.ElementAt(2) == "year");
            Assert.IsTrue(callBackPaper.FieldValues.ElementAt(0) == "Will BeGood");
            Assert.IsTrue(callBackPaper.FieldValues.ElementAt(1) == "Life's Questions");
            Assert.IsTrue(callBackPaper.FieldValues.ElementAt(2) == "1905");
        }

       [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteNullTest()
        {
            //Arrange
            
            //Act
            _facade.Delete(null);

            //Assert
            

        }

        [TestMethod()]
        public void ReadAllObjectsTypeTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will BeGood");
            fieldValues.Add("Life's Questions");
            fieldValues.Add("1905");
            var paper1 = new Paper("article", fieldTypes, fieldValues);
            var paper2 = new Paper("phdthesis", fieldTypes, fieldValues);
            var paper3 = new Paper("book", fieldTypes, fieldValues);
            var paper4 = new Paper("notebook", fieldTypes, fieldValues);
            var paper5 = new Paper("ebook", fieldTypes, fieldValues);

            var paperCollection = new List<StoredPaper>();
            paperCollection.Add(AutoMapper.Mapper.Map<StoredPaper>(paper1));
            paperCollection.Add(AutoMapper.Mapper.Map<StoredPaper>(paper2));
            paperCollection.Add(AutoMapper.Mapper.Map<StoredPaper>(paper3));
            paperCollection.Add(AutoMapper.Mapper.Map<StoredPaper>(paper4));
            paperCollection.Add(AutoMapper.Mapper.Map<StoredPaper>(paper5));

            IEnumerable<Paper> callBackPaper = null;
            mockRepo.Setup(r => r.Read()).Returns(paperCollection);

            //Act
            var papers = _facade.Read();

            //Assert
            for (int i = 0; i < papers.Count(); i++)
            {
                Assert.IsTrue(papers.ElementAt(i).Type == paperCollection.ElementAt(i).Type);
            }
        }

        [TestMethod()]
        public void ReadObjectTest()
        {
            //Arrange
            int callBackPaperId = -1;
            mockRepo.Setup(r => r.Read(It.IsAny<int>())).Callback<int>(o => callBackPaperId = o);

            //Act
            _facade.Read(5);

            //Assert
            //TODO Make NUnit TestCase() work and reduce method to a single Assert
            Assert.IsTrue(callBackPaperId == 5);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReadObjectNegativeIdTest()
        {
            //Arrange

            //Act
            _facade.Read(-1);

            //Assert
        }

        [TestMethod()]
        public void UpdateObjectNotNullTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will BeGood");
            fieldValues.Add("Life's Questions");
            fieldValues.Add("1905");
            var paper = new Paper("article", fieldTypes, fieldValues);

            StoredPaper callBackPaper = null;
            mockRepo.Setup(r => r.UpdateIfExists(It.IsAny<StoredPaper>())).Callback<StoredPaper>(o => callBackPaper = o);

            //Act
            _facade.Update(paper);

            //Assert
            Assert.IsNotNull(callBackPaper);
        }

        [TestMethod()]
        public void UpdateObjectCorrectStateTest()
        {
            //Arrange
            var fieldTypes = new List<string>();
            fieldTypes.Add("author");
            fieldTypes.Add("title");
            fieldTypes.Add("year");
            var fieldValues = new List<string>();
            fieldValues.Add("Will BeGood");
            fieldValues.Add("Life's Questions");
            fieldValues.Add("1905");
            var paper = new Paper("article", fieldTypes, fieldValues);

            StoredPaper callBackPaper = null;
            mockRepo.Setup(r => r.UpdateIfExists(It.IsAny<StoredPaper>())).Callback<StoredPaper>(o => callBackPaper = o);

            //Act
            _facade.Update(paper);

            //Assert
            //TODO Make NUnit TestCase() work and reduce method to a single Assert
            Assert.IsTrue(callBackPaper.Id == 0);
            Assert.IsTrue(callBackPaper.Type == "article");
            Assert.IsTrue(callBackPaper.FieldTypes.Count == 3);
            Assert.IsTrue(callBackPaper.FieldValues.Count == 3);
            Assert.IsTrue(callBackPaper.FieldTypes.ElementAt(0) == "author");
            Assert.IsTrue(callBackPaper.FieldTypes.ElementAt(1) == "title");
            Assert.IsTrue(callBackPaper.FieldTypes.ElementAt(2) == "year");
            Assert.IsTrue(callBackPaper.FieldValues.ElementAt(0) == "Will BeGood");
            Assert.IsTrue(callBackPaper.FieldValues.ElementAt(1) == "Life's Questions");
            Assert.IsTrue(callBackPaper.FieldValues.ElementAt(2) == "1905");
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void UpdateNullTest()
        {
            //Arrange

            //Act
            _facade.Update(null);

            //Assert


        }
    }
}