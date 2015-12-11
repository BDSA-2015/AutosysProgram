using System;
using System.Data.SqlClient;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Storage;

namespace StorageTests
{
    /// <summary>
    ///     This class has been used for internal test purposes to see if could connect to database.
    /// </summary>
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
        ///     This test method is used to see if it is possible to connect to the database.
        /// </summary>
        [TestMethod]
        [Ignore]
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
        ///     Checks if it is possible to create the database.
        /// </summary>
        [TestMethod]
        [Ignore]
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