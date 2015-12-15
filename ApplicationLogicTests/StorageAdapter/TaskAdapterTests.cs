using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.AutosysServer.Mapping;
using ApplicationLogics.StorageAdapter;
using ApplicationLogics.StudyManagement;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Storage.Models;
using Storage.Repository.Interface;

namespace ApplicationLogicTests.StorageAdapter
{
    [TestClass]
    public class TaskAdapterTests
    {
        private Mock<IRepository<StoredTaskRequest>> _repositoryMock;
        private StoredTaskRequest _storedTask;
        private TaskRequest _task;

        [TestInitialize]
        public void Initialize()
        {
            AutoMapperConfigurator.Configure();
            _repositoryMock = new Mock<IRepository<StoredTaskRequest>>();
            _storedTask = new StoredTaskRequest {}; // TODO insert data 
            _task = new TaskRequest { }; // TODO insert data 
        }

        /// <summary>
        ///     Test when a task is created
        /// </summary>
        [TestMethod]
        public void CreateTask_Success_Test()
        {
            //Arrange 
            const int expectedReturnId = 0; 
            _repositoryMock.Setup(r => r.Create(_storedTask)).Returns(Task.FromResult(expectedReturnId));
            var taskAdapter = new TaskAdapter(_repositoryMock.Object);
            
            //Act
            var actualId = taskAdapter.Read(_storedTask.Id).Id;

            //Assert
            Assert.IsTrue(expectedReturnId == actualId);
        }

        /// <summary>
        ///     Test if read does not return null when given a valid task id
        /// </summary>
        [TestMethod]
        public async void GetTask_Valid_NotNull_Test()
        {
            //Arrange
            const int idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedTask));
            var taskAdapter = new TaskAdapter(_repositoryMock.Object);

            //Act
            var returnedTask = await taskAdapter.Read(idToRead);

            //Assert
            Assert.IsNotNull(returnedTask);
        }

        /// <summary>
        ///     Test if read returns a task object when given a valid task id
        /// </summary>
        [TestMethod]
        public async void GetTask_Valid_IsTask_Test()
        {
            //Arrange
            const int idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedTask));
            var taskAdapter = new TaskAdapter(_repositoryMock.Object);

            //Act
            var returnedTask = await taskAdapter.Read(idToRead);

            //Assert
            Assert.IsInstanceOfType(returnedTask, typeof(TaskRequest));
        }


        /// <summary>
        ///     Test if read returns a task object with correct information
        /// </summary>
        [TestMethod]
        public async void GetTask_Valid_CorrectTaskInfo_Test()
        {
            //Arrange
            const int idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead)).Returns(Task.FromResult(_storedTask));
            var adapter = new TaskAdapter(_repositoryMock.Object);

            //Act
            var actualTask = await adapter.Read(idToRead);
            
            //Assert
            Assert.IsTrue(_task.Id == actualTask.Id);
            Assert.IsTrue(_task.Description == actualTask.Description);
            // TODO add more? 

        }

        /// <summary>
        ///     Test that returned task is null if task does not exist.
        /// </summary>
        [TestMethod]
        public async void GetTask_Invalid_NoExistingTask_Test()
        {
            //Arrange
            const int idToRead = 0;
            _repositoryMock.Setup(r => r.Read(idToRead));
            var adapter = new TaskAdapter(_repositoryMock.Object);

            //Act
            var returnedTask = await adapter.Read(idToRead);

            //Assert
            Assert.IsNull(returnedTask);
        }

        /// <summary>
        ///     Test if read with parameters returns correct numbers of tasks
        /// </summary>
        [TestMethod]
        public void GetAllTasks_Valid_ReturnsCorrectNumberOfTasks_Test()
        {
            //Arrange
            var task1 = new StoredTaskRequest { }; 
            var task2 = new StoredTaskRequest { };
            var task3 = new StoredTaskRequest { };
            var taskList = new List<StoredTaskRequest> { task1, task2, task3 }.AsQueryable();

            _repositoryMock.Setup(r => r.Read()).Returns(taskList);
            var adapter = new TaskAdapter(_repositoryMock.Object);
            const int expectedCount = 3;

            //Act
            var result = adapter.Read();
            var actualCount = result.ToList().Count;

            //Assert
            Assert.IsTrue(expectedCount == actualCount);
        }

        /// <summary>
        ///     Test if read with parameters returns tasks with correct information
        /// </summary>
        [TestMethod]
        public void GetAllTasks_Valid_ReturnsCorrectTasks_Test()
        {
            // TODO add property values 
            //Arrange
            var task1 = new StoredTaskRequest { Id = 0};
            var task2 = new StoredTaskRequest { Id = 1};
            var task3 = new StoredTaskRequest { Id = 2};
            var taskList = new List<StoredTaskRequest> { task1, task2, task3 }.AsQueryable();

            _repositoryMock.Setup(r => r.Read()).Returns(taskList);
            var adapter = new TaskAdapter(_repositoryMock.Object);

            //Act
            var result = adapter.Read();
            var actualTasks = result.ToList();

            //Assert
            var counter = 0;
            foreach (var actualTask in taskList.AsEnumerable())
            {
                var returnedTask = actualTasks[counter];
                // Todo add property asserts 
                Assert.IsTrue(returnedTask.Id == actualTask.Id);
                counter++;
            }

        }


        /// <summary>
        ///     Test if a task can be deleted.
        /// </summary>
        [TestMethod]
        public async void DeleteTask_Success_Test()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<StoredTaskRequest>>();
            const int toDeleteId = 0;
            repositoryMock.Setup(r => r.DeleteIfExists(toDeleteId)).Returns(Task.FromResult(true));
            var adapter = new TaskAdapter(repositoryMock.Object);

            //Act
            var result = await adapter.DeleteIfExists(toDeleteId);

            //Assert
            Assert.IsTrue(result);
        }


        /// <summary>
        ///     Test when trying to delete a non-existing task. 
        ///     Exception must be thrown to pass test.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))] // Assert 
        public async void DeleteTask_Fail_TaskDoesNotExist_Test()
        {
            //Arrange
            var repositoryMock = new Mock<IRepository<StoredTaskRequest>>();
            const int toDeleteId = 0;
            repositoryMock.Setup(r => r.DeleteIfExists(toDeleteId)).Returns(Task.FromResult(false));
            var adapter = new TaskAdapter(repositoryMock.Object);

            //Act
            await adapter.DeleteIfExists(toDeleteId);
        }

    }

}
