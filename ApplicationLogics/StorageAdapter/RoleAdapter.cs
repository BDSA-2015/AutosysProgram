using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.StudyManagement;

namespace ApplicationLogics.StorageAdapter
{
    public class RoleAdapter : IAdapter<Role>
    {
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<int> Create(Role user)
        {
            throw new NotImplementedException();
        }

        public Task<Role> Read(int id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Role> Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateIfExists(Role user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIfExists(int id)
        {
            throw new NotImplementedException();
        }

        public Role Map(Role item)
        {
            throw new NotImplementedException();
        }
    }

}