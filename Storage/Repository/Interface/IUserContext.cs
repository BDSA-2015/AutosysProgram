using System;
using System.Data.Entity;
using System.Threading.Tasks;
using Storage.Models;

namespace Storage.Repository.Interface
{

    /// <summary>
    /// This interface is used to mock a database context with a collection of Users. 
    /// </summary>
    public interface IUserContext : IDisposable
    {
            DbSet<StoredUser> Users { get; set; }

            int SaveChanges();

            Task<int> SaveChangesAsync();
    }

}
