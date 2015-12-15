using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.ProtocolManagement;
using ApplicationLogics.StorageAdapter;
using AutoMapper.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogicTests.StorageAdapter
{
    [TestClass]
    public class ProtocolAdapterTests
    {
            private Mock<IRepository<StoredProtocol>> _repositoryMock;
            private StoredProtocol _storedProtocol;
            private Protocol _protocol;

            [TestInitialize]
            public void Initialize()
            {
                AutoMapperConfigurator.Configure();
                _repositoryMock = new Mock<IRepository<StoredProtocol>>();
                _storedProtocol = new StoredProtocol {}; // TODO insert data 
                _protocol = new Protocol {}; // TODO insert data 
            }

            /// <summary>
            ///     Test when a protocol is created
            /// </summary>
            [TestMethod]
            public void CreateProtocol_Success_Test()
            {
                //Arrange 
                const int expectedReturnId = 0;
                _repositoryMock.Setup(r => r.Create(_storedProtocol)).Returns(Task.FromResult(expectedReturnId));
                var protocolAdapter = new ProtocolAdapter(_repositoryMock.Object);

                //Act
                var actualId = protocolAdapter.Read(_storedProtocol.Id).Id;

                //Assert
                Assert.IsTrue(expectedReturnId == actualId);
            }

            /// <summary>
            ///     Test if read does not return null when given a valid protocol id
            /// </summary>
            [TestMethod]
            public async void GetProtocol_Valid_NotNull_Test()
            {
                //Arrange
                const int idToRead = 0;
                _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedProtocol));
                var protocolAdapter = new ProtocolAdapter(_repositoryMock.Object);

                //Act
                var returnedProtocol = await protocolAdapter.Read(idToRead);

                //Assert
                Assert.IsNotNull(returnedProtocol);
            }

            /// <summary>
            ///     Test if read returns a protocol object when given a valid protocol id
            /// </summary>
            [TestMethod]
            public async void GetProtocol_Valid_IsProtocol_Test()
            {
                //Arrange
                const int idToRead = 0;
                _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedProtocol));
                var protocolAdapter = new ProtocolAdapter(_repositoryMock.Object);

                //Act
                var returnedProtocol = await protocolAdapter.Read(idToRead);

                //Assert
                Assert.IsInstanceOfType(returnedProtocol, typeof(Protocol));
            }


            /// <summary>
            ///     Test if read returns a protocol object with correct information
            /// </summary>
            [TestMethod]
            public async void GetProtocol_Valid_CorrectProtocolInfo_Test()
            {
                //Arrange
                const int idToRead = 0;
                _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedProtocol));
                var adapter = new ProtocolAdapter(_repositoryMock.Object);

                //Act
                var actualProtocol = await adapter.Read(idToRead);

                //Assert 
                Assert.IsTrue(_protocol.StudyName == actualProtocol.StudyName);
                // TODO add more? 

            }

            /// <summary>
            ///     Test that returned protocol is null if protocol does not exist.
            /// </summary>
            [TestMethod]
            public async void GetProtocol_Invalid_NoExistingProtocol_Test()
            {
                //Arrange
                const int idToRead = 0;
                _repositoryMock.Setup(r => r.Read(idToRead));
                var adapter = new ProtocolAdapter(_repositoryMock.Object);

                //Act
                var returnedProtocol = await adapter.Read(idToRead);

                //Assert
                Assert.IsNull(returnedProtocol);
            }

            /// <summary>
            ///     Test if read with parameters returns correct numbers of protocols
            /// </summary>
            [TestMethod]
            public void GetAllProtocols_Valid_ReturnsCorrectNumberOfProtocols_Test()
            {
                //Arrange
                var protocol1 = new StoredProtocol { };
                var protocol2 = new StoredProtocol { };
                var protocol3 = new StoredProtocol { };
                var protocolList = new List<StoredProtocol> { protocol1, protocol2, protocol3 }.AsQueryable();

                _repositoryMock.Setup(r => r.Read()).Returns(protocolList);
                var adapter = new ProtocolAdapter(_repositoryMock.Object);
                const int expectedCount = 3;

                //Act
                var result = adapter.Read();
                var actualCount = result.ToList().Count;

                //Assert
                Assert.IsTrue(expectedCount == actualCount);
            }

            /// <summary>
            ///     Test if read with parameters returns protocols with correct information
            /// </summary>
            [TestMethod]
            public void GetAllProtocols_Valid_ReturnsCorrectProtocols_Test()
            {
                // TODO add property values 
                //Arrange
                var protocol1 = new StoredProtocol {};
                var protocol2 = new StoredProtocol {};
                var protocol3 = new StoredProtocol {};
                var protocolList = new List<StoredProtocol> { protocol1, protocol2, protocol3 }.AsQueryable();

                _repositoryMock.Setup(r => r.Read()).Returns(protocolList);
                var adapter = new ProtocolAdapter(_repositoryMock.Object);

                //Act
                var result = adapter.Read();
                var actualProtocols = result.ToList();

                //Assert
                var counter = 0;
                foreach (var actualProtocol in protocolList.AsEnumerable())
                {
                    var returnedProtocol = actualProtocols[counter];
                    // Todo add property asserts 
                    Assert.IsTrue(returnedProtocol.StudyName == actualProtocol.StudyName);
                    counter++;
                }

            }


            /// <summary>
            ///     Test if a protocol can be deleted.
            /// </summary>
            [TestMethod]
            public async void DeleteProtocol_Success_Test()
            {
                //Arrange
                var repositoryMock = new Mock<IRepository<StoredProtocol>>();
                const int toDeleteId = 0;
                repositoryMock.Setup(r => r.DeleteIfExists(toDeleteId)).Returns(Task.FromResult(true));
                var adapter = new ProtocolAdapter(repositoryMock.Object);

                //Act
                var result = await adapter.DeleteIfExists(toDeleteId);

                //Assert
                Assert.IsTrue(result);
            }


            /// <summary>
            ///     Test when trying to delete a non-existing protocol. 
            ///     Exception must be thrown to pass test.
            /// </summary>
            [TestMethod]
            [ExpectedException(typeof(NullReferenceException))] // Assert 
            public async void DeleteProtocol_Fail_ProtocolDoesNotExist_Test()
            {
                //Arrange
                var repositoryMock = new Mock<IRepository<StoredProtocol>>();
                const int toDeleteId = 0;
                repositoryMock.Setup(r => r.DeleteIfExists(toDeleteId)).Returns(Task.FromResult(false));
                var adapter = new ProtocolAdapter(repositoryMock.Object);

                //Act
                await adapter.DeleteIfExists(toDeleteId);
            }

        }

}
