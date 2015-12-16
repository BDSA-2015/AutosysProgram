using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationLogics.StorageAdapter.Interface;
using Storage.Models;

namespace ApplicationLogics.StudyManagement
{
    public class TaskHandler
    {
        private readonly IAdapter<TaskRequest, StoredTaskRequest> _taskAdapter;

        public TaskHandler(IAdapter<TaskRequest, StoredTaskRequest> adapter)
        {
            _taskAdapter = adapter;
        }

        public async Task<int> Create(TaskRequest task)
        {
            return await _taskAdapter.Create(task);
        }

        public async Task<TaskRequest> Read(int taskId)
        {
            return await _taskAdapter.Read(taskId);
        }

        public IEnumerable<TaskRequest> Read()
        {
            return _taskAdapter.Read();
        }

        public async Task<bool> Update(TaskRequest task)
        {
            return await _taskAdapter.UpdateIfExists(task);
        }

        public async Task<bool> Delete(int id)
        {
            return await _taskAdapter.DeleteIfExists(id);
        }
    }
}
