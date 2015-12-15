using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StorageAdapter;
using ApplicationLogics.StudyManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogicTests.StorageAdapter
{
    [TestClass]
    public class StudyAdapterTests
    {

        private Mock<IRepository<StoredStudy>> _repositoryMock;
        private StoredStudy _storedStudy;
        private Study _study;

        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfigurator.Configure();
            _repositoryMock = new Mock<IRepository<StoredStudy>>();
            _storedStudy = new StoredStudy(); { }; // TODO insert data 
            _study = new Study { }; // TODO insert data 
        }

        /// <summary>
        ///     Test when a study is created
        /// </summary>
        [TestMethod]
        public void CreateStudy_Success_Test()
        {
            //Arrange 
            const int expectedReturnId = 0;
            _repositoryMock.Setup(r => r.Create(_storedStudy)).Returns(Task.FromResult(expectedReturnId));
            var studyAdapter = new StudyAdapter(_repositoryMock.Object);

            //Act
            var actualId = studyAdapter.Read(_storedStudy.Id).Id;

            //Assert
            Assert.IsTrue(expectedReturnId == actualId);
        }

        /// <summary>
        ///     Test if read does not return null when given a valid study id
        /// </summary>
        [TestMethod]
        public async void GetStudy_Valid_NotNull_Test()
        {
            //Arrange
            const int idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedStudy));
            var studyAdapter = new StudyAdapter(_repositoryMock.Object);

            //Act
            var returnedStudy = await studyAdapter.Read(idToRead);

            //Assert
            Assert.IsNotNull(returnedStudy);
        }

        /// <summary>
        ///     Test if read returns a study object when given a valid protocol id
        /// </summary>
        [TestMethod]
        public async void GetProtocol_Valid_IsProtocol_Test()
        {
            //Arrange
            const int idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedStudy));
            var studyAdapter = new StudyAdapter(_repositoryMock.Object);

            //Act
            var returnedProtocol = await studyAdapter.Read(idToRead);

            //Assert
            Assert.IsInstanceOfType(returnedProtocol, typeof(Protocol));
        }


        /// <summary>
        ///     Test if read returns a study object with correct information
        /// </summary>
        [TestMethod]
        public async void GetProtocol_Valid_CorrectProtocolInfo_Test()
        {
            //Arrange
            const int idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedStudy));
            var adapter = new StudyAdapter(_repositoryMock.Object);

            //Act
            var actualStudy = await adapter.Read(idToRead);

            //Assert 
            Assert.IsTrue(_study.Id == actualStudy.Id);
            Assert.IsTrue(_study.Name == actualStudy.Name);
            Assert.IsTrue(_study.UserIds == actualStudy.UserIds);
            Assert.IsTrue(_study.Phases == actualStudy.Phases);
        }

        /// <summary>
        ///     Test that returned study is null if study does not exist.
        /// </summary>
        [TestMethod]
        public async void GetStudy_Invalid_NoExistingStudy_Test()
        {
            //Arrange
            const int idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead));
            var adapter = new StudyAdapter(_repositoryMock.Object);

            //Act
            var returnedStudy = await adapter.Read(idToRead);

            //Assert
            Assert.IsNull(returnedStudy);
        }

        /// <summary>
        ///     Test if read with parameters returns correct numbers of studies
        /// </summary>
        [TestMethod]
        public void GetAllStudies_Valid_ReturnsCorrectNumberOfStudies_Test()
        {
            //Arrange
            var study1 = new StoredStudy(); { };
            var study2 = new StoredStudy(); { };
            var study3 = new StoredStudy(); { };
            var studyList = new List<StoredStudy> { study1, study2, study3 }.AsQueryable();

            _repositoryMock.Setup(r => r.Read()).Returns(studyList);
            var adapter = new StudyAdapter(_repositoryMock.Object);
            const int expectedCount = 3;

            //Act
            var result = adapter.Read();
            var actualCount = result.ToList().Count;

            //Assert
            Assert.IsTrue(expectedCount == actualCount);
        }

        /// <summary>
        ///     Test if read with parameters returns studies with correct information
        /// </summary>
        [TestMethod]
        public void GetAllStudies_Valid_ReturnsCorrectStudies_Test()
        {
            // TODO add property values 
            //Arrange
            var study1 = new StoredStudy { };
            var study2 = new StoredStudy { };
            var study3 = new StoredStudy { };
            var studyList = new List<StoredStudy> { study1, study2, study3 }.AsQueryable();

            _repositoryMock.Setup(r => r.Read()).Returns(studyList);
            var adapter = new StudyAdapter(_repositoryMock.Object);

            //Act
            var result = adapter.Read();
            var actualStudies = result.ToList();

            //Assert
            var counter = 0;
            foreach (var actualStudy in studyList.AsEnumerable())
            {
                var returnedStudy = actualStudies[counter];
                // Todo add property asserts 
                Assert.IsTrue(returnedStudy.Name == actualStudy.Name);
                counter++;
            }

        }


        /// <summary>
        ///     Test if a study can be deleted.
        /// </summary>
        [TestMethod]
        public async void DeleteStudy_Success_Test()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<StoredStudy>>();
            const int toDeleteId = 0;
            repositoryMock.Setup(r => r.DeleteIfExists(toDeleteId)).Returns(Task.FromResult(true));
            var adapter = new StudyAdapter(repositoryMock.Object);

            //Act
            var result = await adapter.DeleteIfExists(toDeleteId);

            //Assert
            Assert.IsTrue(result);
        }


        /// <summary>
        ///     Test when trying to delete a non-existing study. 
        ///     Exception must be thrown to pass test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))] // Assert 
        public async void DeleteStudy_Fail_StudyDoesNotExist_Test()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<StoredStudy>>();
            const int toDeleteId = 0;
            repositoryMock.Setup(r => r.DeleteIfExists(toDeleteId)).Returns(Task.FromResult(false));
            var adapter = new StudyAdapter(repositoryMock.Object);

            //Act
            await adapter.DeleteIfExists(toDeleteId);
        }

    }

}
