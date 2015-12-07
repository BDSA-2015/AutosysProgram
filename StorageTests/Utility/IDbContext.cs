using System;
using System.Data.Entity;
using System.Threading.Tasks;

namespace StorageTests.Utility
{

    /// <summary>
    /// This interface is used to mock a database context with a collection of stored entities. 
    /// </summary>
    public interface IDbContext : IDisposable
    {
        DbSet<T> Set<T>() where T : class;

        Task<int> SaveChangesAsync();
    }

}
