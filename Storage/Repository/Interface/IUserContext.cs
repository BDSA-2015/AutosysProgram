using System.Threading.Tasks;
using System.Data.Entity;
using System.Security.Policy;
using Storage.Models;

namespace StorageTests
{

    /// <summary>
    /// This interface is used to mock a database context with a collection of Users. 
    /// </summary>
    public interface IUserContext
    {
            DbSet<StoredUser> Users { get; set; }

            int SaveChanges();

            Task<int> SaveChangesAsync();
    }

}
