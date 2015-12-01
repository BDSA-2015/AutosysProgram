using System;
using ApplicationLogics.StorageFasade.Mapper;
using ApplicationLogics.StorageFasade.Mapping;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.Mapping
{
    [TestClass]
    public class BaseMapperTests
    {

        private IMap<ObjectA, ObjectB> _mapper;
        [TestInitialize]
        public void Initialize()
        {
           _mapper = new BaseMapper<ObjectA, ObjectB>();
        }

        /// <summary>
        /// Test if returned destination object is not null
        /// </summary>
        [TestMethod]
        public void ValidMappingTest_NotNull()
        {
            //Arrange

            var inputObject = new ObjectA();
        
            //Act
            var outputObject = _mapper.Map(inputObject,new ObjectB());

            //Assert
            Assert.IsNotNull(outputObject);
        }

        /// <summary>
        /// Test if a correct destination class has been returned.
        /// </summary>
        [TestMethod]
        public void ValidMappingTest_CorrectClassReturned()
        {
            //Arrange
            var inputObject = new ObjectA();

            //Act
            var outputObject = _mapper.Map(inputObject, new ObjectB());

            //Assert
            Assert.IsInstanceOfType(outputObject, typeof(ObjectB));
        }

        /// <summary>
        /// Test if a property from a source object is correctly transfered to a destination object
        /// </summary>
        [TestMethod]
        public void ValidMappingTest_CorrectPropertyTransfer()
        {
            //Arrange
            const string expectedName = "Name";

            var inputObject = new ObjectA() { Name = expectedName };


            //Act
            var outputObject = _mapper.Map(inputObject, new ObjectB());

            //Assert
            Assert.AreEqual(inputObject.Name, outputObject.Name);
        }


        private class ObjectA
        {
            public string Name { get; set;} 
        }

        private class ObjectB
        {
            public string Name { get; set;}
        }
    }
}
