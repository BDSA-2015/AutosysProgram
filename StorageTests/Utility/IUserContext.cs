using System.Data.Entity;
using System.Threading.Tasks;
using Storage.Models;

namespace StorageTests.Utility
{

    /// <summary>
    /// This interface is used to mock a database context with a collection of Users. 
    /// </summary>
    public interface IUserContext : IDbContext
    {
            DbSet<StoredUser> Users { get; set; }

            new Task<int> SaveChangesAsync();
    }

}
