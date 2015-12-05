using ApplicationLogicTests.Mapping.Stub;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.Mapping
{
    /// <summary>
    /// This class will test the automapper and its functionalities.
    /// It will basically test various ways of mappings and also 
    /// if AutoMapper is configured correct.
    /// </summary>
    [TestClass]
    public class AutoMapperTests
    {

        private ObjectDto _objectDto;
        [TestInitialize]
        public void Initialize()
        {
            AutoMaperConfiguratorStub.Configure();
            _objectDto = new ObjectDto() {Name="John Doe"};
        }

        /// <summary>
        /// Test mapping of two objects with same property names
        /// </summary>
        [TestMethod]
        public void Map_SameProperty_ValidTarget_Test()
        {
            //Arrange
            var target = new ObjectSameOneProperty();

            //Act
            var result = AutoMapper.Mapper.Map(_objectDto, target);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Name == _objectDto.Name);

        }

        /// <summary>
        /// Test mapping of two objects with different property names.
        /// The expected outcome is both property values must be the same after 
        /// the transfer
        /// </summary>
        [TestMethod]
        public void Map_DifferentPropertyName_ValidTarget_Test()
        {
            //Arrange
            var target = new ObjectDifferentProperty();

            //Act
            var result = AutoMapper.Mapper.Map(_objectDto, target);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.FullName == _objectDto.Name);
        }

        /// <summary>
        /// Test mapping of two objects with different numbers of properties.
        /// The expected outcome is Name from DTO must be transfered correctly to target object that has
        /// two properties. EG FirstName and LastName.
        /// </summary>
        [TestMethod]
        public void Map_ManyProperties_ValidTarget_Test()
        {
            //Arrange
            var target = new ObjectManyProperties();

            //Act
            var result = AutoMapper.Mapper.Map(_objectDto, target);

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(result.FirstName == "John");
            Assert.IsTrue(result.LastName == "Doe");
        }



        /// <summary>
        /// This test utilize AutoMapper's own Assert method
        /// that dry run all configured type maps and throw
        /// AutoMapperConfigurationException for each problem.
        /// If no exception are thrown, the automapper has been 
        /// correctly created
        /// </summary>
        [TestMethod]
        public void AutoMapper_Configuration_Valid_Test()
        {
            Mapper.AssertConfigurationIsValid();
        }


      

    }
}
