using System;
using ApplicationLogics.StorageFasade.Mapper;
using ApplicationLogics.StorageFasade.Mapping;
using ApplicationLogicTests.Mapping.Stub;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.Mapping
{
    [TestClass]
    public class BaseMapperTests
    {

        private IMap _mapper;
        private ObjectDto _objectDto;
        [TestInitialize]
        public void Initialize()
        {
            _mapper = new BaseMapperStub();
            _mapper.CreateMappings();
            _objectDto = new ObjectDto() {Name="John Doe"};
        }

        /// <summary>
        /// Test mapping of two objects with same property names
        /// </summary>
        [TestMethod]
        public void DtoToObjectWithSamePropertyTest()
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
        public void DtoToObjectWithDifferentPropertyNameTest()
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
        public void DtoToObjectWithManyPropertiesTest()
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




        [TestMethod]
        public void ValidConfigurationTest()
        {
            Mapper.AssertConfigurationIsValid();
        }



    }
}
