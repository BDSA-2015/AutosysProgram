using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using SystematicStudyService.Models;
using WebApi.Controllers;
using WebApi.Models;
using ApplicationLogics.AutosysServer;

namespace WebApi.Adapter
{
    public class StudyControllerAdaptorcs : IStudyControllerAdapter
    {

        private readonly MainHandler _facade;

        public StudyControllerAdaptorcs(MainHandler facade)
        {
            _facade = facade;
        }


        public StudyOverview GetOverview(int id)
        {
            var study =_facade.GetStudy(id);
            var returnValue = new StudyOverview();

            returnValue.Name = study.Name; 
            study.UserId.CopyTo(returnValue.UserIds);

            









            throw new NotImplementedException();
        }

        public IHttpActionResult GetResource(int id, int resourceId)
        {
            throw new NotImplementedException();
        }

        public TaskRequest GetTask(int id, int taskId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<int> GetTaskIDs(int id, int userId, TaskRequest.Filter filter = TaskRequest.Filter.Editable, TaskRequest.Type type = TaskRequest.Type.Both)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TaskRequest> GetTasks(int id, int userId, int count = 1, TaskRequest.Filter filter = TaskRequest.Filter.Remaining, TaskRequest.Type type = TaskRequest.Type.Both)
        {
            throw new NotImplementedException();
        }

        public IHttpActionResult PostTask(int id, int taskId, [FromBody] TaskSubmission task)
        {
            throw new NotImplementedException();
        }
    }
}