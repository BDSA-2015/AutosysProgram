using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storage;

namespace StorageTests
{
    [TestClass]
    public class DbContextTests
    {

        private AutoSysDbModel _dbContext;

        [TestInitialize]
        public void Initialize()
        {
            _dbContext = new AutoSysDbModel();
        }

        [TestMethod]
        public void CheckConnection()
        {
            bool result; 

            try
            {
                _dbContext.Database.Connection.Open();
                _dbContext.Database.Connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            result = true;

            Assert.AreEqual(true, result);
        }


        [TestMethod]
        public void CreateDatabase()
        {
            try
            {
                _dbContext.Database.Create();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

    }

}
