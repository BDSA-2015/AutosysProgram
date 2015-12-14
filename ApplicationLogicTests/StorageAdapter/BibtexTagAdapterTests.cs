using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.PaperManagement;
using ApplicationLogics.StorageAdapter;
using AutoMapper.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogicTests.StorageAdapter
{
    [TestClass]
    public class BibtexTagAdapterTests
    {
            private Mock<IRepository<StoredBibtexTag>> _repositoryMock;
            private StoredBibtexTag _storedTag;
            private BibtexTag _tag;

            [TestInitialize]
            public void Initialize()
            {
                AutoMapperConfigurator.Configure();
                _repositoryMock = new Mock<IRepository<StoredBibtexTag>>();
                _storedTag = new StoredBibtexTag {Id = 0, Type = "Author" };
                _tag = new BibtexTag { Type = "Author" };
        }

            /// <summary>
            ///     Test when a tag is created
            /// </summary>
            [TestMethod]
            public void CreateTag_Success_Test()
            {
                //Arrange 
                const int expectedReturnId = 0;
                _repositoryMock.Setup(r => r.Create(_storedTag)).Returns(Task.FromResult(expectedReturnId));
                var tagAdapter = new BibtexTagAdapter(_repositoryMock.Object);

                //Act
                // var actualId = tagAdapter.Create(_storedTag);
                var actualId = tagAdapter.Read(_storedTag.Id).Id;


                //Assert
                Assert.IsTrue(expectedReturnId == actualId);
            }

            /// <summary>
            ///     Test if read does not return null when given a valid tag id
            /// </summary>
            [TestMethod]
            public async void GetTag_Valid_NotNull_Test()
            {
                //Arrange
                const int idToRead = 0;
                _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedTag));
                var tagAdapter = new BibtexTagAdapter(_repositoryMock.Object);

                //Act
                var returnedTag = await tagAdapter.Read(idToRead);

                //Assert
                Assert.IsNotNull(returnedTag);
            }

            /// <summary>
            ///     Test if read returns a tag object when given a valid tag id
            /// </summary>
            [TestMethod]
            public async void GetTag_Valid_IsTag_Test()
            {
                //Arrange
                const int idToRead = 0;
                _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedTag));
                var tagAdapter = new BibtexTagAdapter(_repositoryMock.Object);

                //Act
                var returnedTag = await tagAdapter.Read(idToRead);

                //Assert
                Assert.IsInstanceOfType(returnedTag, typeof(BibtexTag));
            }


            /// <summary>
            ///     Test if read returns a tag object with correct information
            /// </summary>
            [TestMethod]
            public async void GetTag_Valid_CorrectTagInfo_Test()
            {
                //Arrange
                const int idToRead = 0;
                _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedTag));
                var adapter = new BibtexTagAdapter(_repositoryMock.Object);

                //Act
                var returnedTag = await adapter.Read(idToRead);

                //Assert
                //Assert.IsTrue(_tag.Id == returnedTag.Id);
                Assert.IsTrue(_tag.Type == returnedTag.Type);
            }

            /// <summary>
            ///     Test that returned tag is null if tag does not exist.
            /// </summary>
            [TestMethod]
            public async void GetTag_Invalid_NoExistingTag_Test()
            {
                //Arrange
                const int idToRead = 0;
                _repositoryMock.Setup(r => r.Read(idToRead));
                var adapter = new BibtexTagAdapter(_repositoryMock.Object);

                //Act
                var returnedTag = await adapter.Read(idToRead);

                //Assert
                Assert.IsNull(returnedTag);
            }

            /// <summary>
            ///     Test if read with parameters returns correct numbers of tags
            /// </summary>
            [TestMethod]
            public void GetAllTags_Valid_ReturnsCorrectNumberOfTags_Test()
            {
                //Arrange
                var tag1 = new StoredBibtexTag {Id = 0, Type = "Actor" };
                var tag2 = new StoredBibtexTag { Id = 1, Type = "Year" };
                var tag3 = new StoredBibtexTag { Id = 2, Type = "Title" };
                var list = new List<StoredBibtexTag> { tag1, tag2, tag3 }.AsQueryable();

                _repositoryMock.Setup(r => r.Read()).Returns(list);
                var adapter = new BibtexTagAdapter(_repositoryMock.Object);
                const int expectedCount = 3;

                //Act
                var result = adapter.Read();
                var actualCount = result.ToList().Count;

                //Assert
                Assert.IsTrue(expectedCount == actualCount);
            }

            /// <summary>
            ///     Test if read with parameters returns tags with correct information
            /// </summary>
            [TestMethod]
            public void GetAllTags_Valid_ReturnsCorrectTags_Test()
            {
                //Arrange
                var tag1 = new StoredBibtexTag { Id = 0, Type = "Author" };
                var tag2 = new StoredBibtexTag { Id = 1, Type = "Year" };
                var tag3 = new StoredBibtexTag { Id = 2, Type = "Title" };
                var list = new List<StoredBibtexTag> { tag1, tag2, tag3 }.AsQueryable();

                _repositoryMock.Setup(r => r.Read()).Returns(list);
                var adapter = new BibtexTagAdapter(_repositoryMock.Object);

                //Act
                var result = adapter.Read();
                var actualTags = result.ToList();

                //Assert
                var counter = 0;
                foreach (var actualTag in list.AsEnumerable())
                {
                    var returnedTag = actualTags[counter];
                    //Assert.IsTrue(returnedTag.Id == actualTag.Id);
                    Assert.IsTrue(returnedTag.Type == actualTag.Type);
                    counter++;
                }
            }


            /// <summary>
            ///     Test if a tag can be deleted.
            /// </summary>
            [TestMethod]
            public async void DeleteTag_Success_Test()
            {
                //Arrange
                var repositoryMock = new Mock<IRepository<StoredBibtexTag>>();
                const int toDeleteId = 0;
                repositoryMock.Setup(r => r.DeleteIfExists(toDeleteId)).Returns(Task.FromResult(true));
                var adapter = new BibtexTagAdapter(repositoryMock.Object);

                //Act
                var result = await adapter.DeleteIfExists(toDeleteId);

                //Assert
                Assert.IsTrue(result);
            }


            /// <summary>
            ///     Test when trying to delete a non-existing tag. 
            ///     Exception must be thrown to pass test.
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof(NullReferenceException))] // Assert 
            public async void DeleteTag_Fail_TagDoesNotExist_Test()
            {
                //Arrange
                var repositoryMock = new Mock<IRepository<StoredBibtexTag>>();
                const int toDeleteId = 0;
                repositoryMock.Setup(r => r.DeleteIfExists(toDeleteId)).Returns(Task.FromResult(false));
                var adapter = new BibtexTagAdapter(repositoryMock.Object);

                //Act
                await adapter.DeleteIfExists(toDeleteId);
            }

        }

}
