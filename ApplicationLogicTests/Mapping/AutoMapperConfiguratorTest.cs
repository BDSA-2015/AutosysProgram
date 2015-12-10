using ApplicationLogics.AutosysServer.Mapping;
using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.Mapping
{
    [TestClass]
    public class AutoMapperConfiguratorTest
    {
        /// <summary>
        ///     This test utilize AutoMapper's own Assert method
        ///     that dry run all configured type maps and throw
        ///     AutoMapperConfigurationException for each problem.
        ///     If no exception are thrown, the automapper has been
        ///     correctly created
        ///     This tests the automapper configurator in application logic
        /// </summary>
        [TestMethod]
        public void AutoMapper_Configuration_Valid_Test()
        {
            AutoMapperConfigurator.Configure();
            Mapper.AssertConfigurationIsValid();
        }
    }
}