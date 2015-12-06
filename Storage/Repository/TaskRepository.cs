using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;
using Storage.Models;
using Storage.Repository.Interface;

namespace Storage.Repository
{

    /// <summary>
    /// This class outlines the CRUD operations used to store tasks in the database. 
    /// </summary>
    public class TaskRepository : IRepository<StoredTaskRequest>
    {
        public int Create(StoredTaskRequest user)
        {
            throw new NotImplementedException();
        }

        public void Delete(StoredTaskRequest user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StoredTaskRequest> Read()
        {
            throw new NotImplementedException();
        }

        public StoredTaskRequest Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(StoredTaskRequest updatedUser)
        {
            throw new NotImplementedException();
        }
    }
}
