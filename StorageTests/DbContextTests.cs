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

        /// <summary>
        /// This test is used to check whether the database connection works. 
        /// </summary>
        [TestMethod]
        public void CheckConnection()
        {
            bool result; 
            try
            {
                _dbContext.Database.Connection.Open();
                _dbContext.Database.Connection.Close();
                result = true;
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.Message);
                result = false;
            }
            
            Assert.AreEqual(true, result);
        }

        /// <summary>
        /// This test is used to check if the database can be created correctly. 
        /// </summary>
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
