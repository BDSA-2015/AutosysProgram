﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Storage.Entities;
using Storage.Models;

namespace Storage.Repository
{
    public class TaskRepository : IRepository<StoredTaskRequest>
    {
        public int CreateOrUpdate(StoredTaskRequest item)
        {
            throw new NotImplementedException();
        }

        public void DeleteIfExists(StoredTaskRequest item)
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

        public void UpdateIfExists(StoredTaskRequest item)
        {
            throw new NotImplementedException();
        }
    }
}
