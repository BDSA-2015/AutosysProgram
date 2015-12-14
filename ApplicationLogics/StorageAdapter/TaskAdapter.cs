using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using ApplicationLogics.StudyManagement;
using AutoMapper;
using Storage.Models;
using Storage.Repository;
using Storage.Repository.Interface;

namespace ApplicationLogics.StorageAdapter
{
    public class TaskAdapter : IAdapter<TaskRequest>
    {

        private readonly IRepository<StoredTaskRequest> _taskRepository;

        public TaskAdapter(IRepository<StoredTaskRequest> taskRepository)
        {
            _taskRepository = taskRepository;   
        } 

        public async Task<int> Create(TaskRequest user)
        {
            var storedTask = Mapper.Map<StoredTaskRequest>(user);
            return await _taskRepository.Create(storedTask);
        }

        public Task<TaskRequest> Read(int id)
        {
            
        }

        public IQueryable<TaskRequest> Read()
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateIfExists(TaskRequest user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteIfExists(int id)
        {
            throw new NotImplementedException();
        }

        public TaskRequest Map(TaskRequest item)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _taskRepository.Dispose();
        }
    }


}