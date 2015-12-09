using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;
using Moq;

namespace StorageTests.Utility
{

    /// <summary>
    /// This utility class is used to mock db set tables used to test that the repositories write correctly to the database.
    /// Credits goes to our lecturer, Rasmus Lystrøm who wrote the utility class during a lecture.
    /// EF6 enables mocking Dbsets more easily: http://thedatafarm.com/data-access/how-ef6-enables-mocking-dbsets-more-easily/ 
    /// Could also use in memory database using EF 7. 
    /// </summary>
    public static class MockUtility
    {

        /// <summary>
        /// This helper method is used to create a mocked DbSet from a stored entity.
        /// This is used in all repository tests to setup a mock for a given entity DbSet passed in a repository.
        /// </summary>
        /// <typeparam name="T">
        /// The entity collection to mock, e.g. users.  
        /// </typeparam>
        /// <param name="items">
        /// Items to add to the collection, e.g. a list of users. 
        /// </param>
        /// <param name="key">
        /// Id of the entity, e.g. 
        /// </param>
        /// <returns>
        /// A Mock DbSet used to test repositories. 
        /// </returns>
        public static Mock<DbSet<T>> CreateMockDbSet<T>(ICollection<T> items, Func<T, int> key) where T : class
        {
            var data = items.AsQueryable();
            var set = new Mock<DbSet<T>>();
            set.As<IQueryable<T>>().Setup(m => m.Provider).Returns(data.Provider);
            set.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            set.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            set.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            set.Setup(m => m.Find(It.IsAny<object[]>()))
                .Returns<object[]>(ids => items.FirstOrDefault(d => key(d) == (int) ids[0])); // Find first id on first spot 

            set.Setup(m => m.Add(It.IsAny<T>())).Callback<T>(a => items.Add(a));
            set.Setup(m => m.Remove(It.IsAny<T>())).Callback<T>(a => items.Remove(a));

            return set;
        }

        /// <summary>
        /// This helper method is used to create a mocked DbSet from a stored entity.
        /// This is used in all repository tests to setup a mock for a given entity DbSet passed in a repository.
        /// </summary>
        /// <typeparam name="T">
        /// The entity collection to mock, e.g. users.  
        /// </typeparam>
        /// <param name="items">
        /// Items to add to the collection, e.g. a list of users. 
        /// </param>
        /// <param name="key">
        /// Id of the entity, e.g. 
        /// </param>
        /// <returns>
        /// A Mock DbSet used to test async repositories. 
        /// </returns>
        public static Mock<DbSet<T>> CreateAsyncMockDbSet<T>(ICollection<T> items, Func<T, int> key) where T : class
        {
            var data = items.AsQueryable();
            var mockSet = new Mock<DbSet<T>>();

            mockSet.As<IDbAsyncEnumerable<T>>()
                .Setup(m => m.GetAsyncEnumerator())
                .Returns(new TestDbAsyncEnumerator<T>(data.GetEnumerator()));

            mockSet.As<IQueryable<T>>()
                .Setup(m => m.Provider)
                .Returns(new TestDbAsyncQueryProvider<T>(data.Provider));

            mockSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            mockSet.Setup(m => m.FindAsync(It.IsAny<object[]>())) // <Task<object[]>>
                .Returns<object[]>(ids => Task.FromResult(items.FirstOrDefault(d => key(d) == (int)ids[0])));

            mockSet.Setup(m => m.Add(It.IsAny<T>())).Callback<T>(a => items.Add(a));
            mockSet.Setup(m => m.Remove(It.IsAny<T>())).Callback<T>(a => items.Remove(a));

            return mockSet;
        }

    }
}
