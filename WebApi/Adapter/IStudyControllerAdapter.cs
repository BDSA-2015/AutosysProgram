using System.Collections.Generic;
using System.Web.Http;
using SystematicStudyService.Models;
using WebApi.Models;

namespace WebApi.Controllers
{
    
    public interface IStudyControllerAdapter
    {
        StudyOverview GetOverview(int id);
        IHttpActionResult GetResource(int id, int resourceId);
        TaskRequest GetTask(int id, int taskId);
        IEnumerable<int> GetTaskIDs(int id, int userId, TaskRequest.Filter filter = TaskRequest.Filter.Editable, TaskRequest.Type type = TaskRequest.Type.Both);
        IEnumerable<TaskRequest> GetTasks(int id, int userId, int count = 1, TaskRequest.Filter filter = TaskRequest.Filter.Remaining, TaskRequest.Type type = TaskRequest.Type.Both);
        IHttpActionResult PostTask(int id, int taskId, [FromBody] TaskSubmission task);
    }
}