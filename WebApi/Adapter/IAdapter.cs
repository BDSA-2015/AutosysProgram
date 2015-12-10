using System.Collections.Generic;
using System.Web.Http;
using SystematicStudyService.Models;
using WebApi.Models;

namespace WebApi.Adapter
{
    public interface IAdapter
    {
        //Originaly taken from StudyController
        StudyOverview GetOverview(int id);

        IEnumerable<TaskRequest> GetTasks(int id, int userId, int count = 1,
            TaskRequest.Filter filter = TaskRequest.Filter.Remaining, TaskRequest.Type type = TaskRequest.Type.Both);

        IEnumerable<int> GetTaskIDs(int id, int userId, TaskRequest.Filter filter = TaskRequest.Filter.Editable,
            TaskRequest.Type type = TaskRequest.Type.Both);

        TaskRequest GetTask(int id, int taskId);

        IHttpActionResult PostTask(int id, int taskId, [FromBody] TaskSubmission task);

        IHttpActionResult GetResource(int id, int resourceId);


        //Originaly taken from TeamController
        IEnumerable<Team> GetTeam(string name = "");

        Team Get(int id);

        IHttpActionResult Post([FromBody] Team team);

        IHttpActionResult Put(int id, [FromBody] Team user);

        IHttpActionResult Delete(int id);

        //Orinaly taken from UserController

        IEnumerable<User> GetUser(string name = "");
    }
}