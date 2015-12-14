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

    /// <summary>
    ///     This class is responsible for converting tasks in the logical layer to stored task entities in the storage layer and call appropriate database operations.
    /// </summary>
    public class TaskAdapter : IAdapter<TaskRequest>
    {

        private readonly IRepository<StoredTaskRequest> _taskRepository;

        public TaskAdapter(IRepository<StoredTaskRequest> taskRepository)
        {
            _taskRepository = taskRepository;   
        } 

        /// <summary>
        /// Creates and converts a task to store it in the storage layer. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// Id of the created task. 
        /// </returns>
        public async Task<int> Create(TaskRequest user)
        {
            var storedTask = Mapper.Map<StoredTaskRequest>(user);
            return await _taskRepository.Create(storedTask);
        }

        /// <summary>
        /// Returns a converted task from the storage layer based on its id. 
        /// </summary>
        /// <param name="id">
        /// Id of retrieved task. 
        /// </param>
        /// <returns>
        /// Found task. 
        /// </returns>
        public async Task<TaskRequest> Read(int id)
        {
            var storedTask = await _taskRepository.Read(id);
            var convertedTask = Mapper.Map<TaskRequest>(storedTask);
            return convertedTask;
        }

        /// <summary>
        /// Returns all tasks.
        /// </summary>
        /// <returns>
        /// All tasks. 
        /// </returns>
        public IQueryable<TaskRequest> Read()
        {
            var storedTasks = _taskRepository.Read();
            return storedTasks.Select(Mapper.Map<TaskRequest>).AsQueryable();
        }

        /// <summary>
        /// Updates a given task if it is already stored from the storage layer in the database. 
        /// </summary>
        /// <param name="task">
        /// Task to look up. 
        /// </param>
        /// <returns>
        /// True if task exists and was updated. 
        /// </returns>
        public async Task<bool> UpdateIfExists(TaskRequest task)
        {
            var storedTask = Mapper.Map<StoredTaskRequest>(task);
            return await _taskRepository.UpdateIfExists(storedTask);
        }

        /// <summary>
        /// Deletes a task if it exists in the database. 
        /// </summary>
        /// <param name="id">
        /// Id of task. 
        /// </param>
        /// <returns>
        /// True if task exists and is thus deleted. 
        /// </returns>
        public async Task<bool> DeleteIfExists(int id)
        {
            return await _taskRepository.DeleteIfExists(id);
        }

        // TODO remove from interface? 
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