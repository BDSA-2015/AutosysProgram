using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using SystematicStudyService.Models;
using ApplicationLogics.AutosysServer;
using ApplicationLogics.StudyManagement;
using ApplicationLogics.UserManagement;

namespace WebApi.Adapters
{
    public class StudyAdapter
    {
        
        public StudyOverview GetOverview(int id)
        {
            var database = new MainHandler();
            StudyOverview overview = new StudyOverview();

            var study = database.GetStudy(id);

            overview.Name = study.Name;
            //A list of all team members who have been working on the study in either one or more phases
            var teamMembers = new HashSet<int>();
            //A list of phases represented in the API format
            var stages = new List<StageOverview>();
            
            //Transform our representation of the data to the API's representation of the data
            foreach (Phase phase in study.Phases )
            {
                var currentStage = new StageOverview();
                var StageIncompleteTasks = new Dictionary<int, int>();
                var StageCompletedTasks= new  Dictionary<int, int> ();

                //Extract Each user which has a role in the Phase and adds it to a list of Users who have contributed to the Study
                foreach (KeyValuePair<Role,List<ApplicationLogics.UserManagement.User>> PhaseRoles in phase.AssignedRole) //Multiple packes have Classes have identical names which creates the need for specification when refering  to a class
                {
                    foreach(ApplicationLogics.UserManagement.User user in PhaseRoles.Value)
                    {
                        teamMembers.Add(user.Id);
                    }  
                }

                //Extract Each users current progress on assigned tasks
                foreach (KeyValuePair<ApplicationLogics.StudyManagement.TaskRequest, List<ApplicationLogics.UserManagement.User>> AssignedTasks in phase.AssignedTask)
                {
                    if (AssignedTasks.Key.TaskState == ApplicationLogics.StudyManagement.TaskRequest.State.Started)
                        foreach (ApplicationLogics.UserManagement.User user in AssignedTasks.Value)
                        {
                            int usersAmountOfUnfinishedTasks;
                            if (!StageIncompleteTasks.TryGetValue(user.Id, out usersAmountOfUnfinishedTasks))
                            {
                                //First time we encounter this user. Create user in Dictionary with 1 unfinished task
                                StageIncompleteTasks.Add(user.Id, 1);
                            }
                            else
                            {
                                //User is already known  in the dictionary, increment his count of unfinished tasks
                                StageIncompleteTasks[user.Id] = 1 + usersAmountOfUnfinishedTasks;
                            }
                        }

                    
                    else if (AssignedTasks.Key.TaskState == ApplicationLogics.StudyManagement.TaskRequest.State.Done)
                        foreach (ApplicationLogics.UserManagement.User user in AssignedTasks.Value)
                        {
                            int usersAmountOfFinishedTasks;
                            if (!StageIncompleteTasks.TryGetValue(user.Id, out usersAmountOfFinishedTasks))
                            {
                                //First time we encounter this user. Create user in Dictionary with 1 finished task
                                StageCompletedTasks.Add(user.Id, 1);
                            }
                            else
                            {
                                //User is already known  in the dictionary, increment his count of finished tasks
                                StageCompletedTasks[user.Id] = 1 + usersAmountOfFinishedTasks;
                            }
                        }
                }
                //Transform our representation of  a Phase into the expected returntype of the API
                currentStage.Name = phase.Name;
                currentStage.IncompleteTasks = StageIncompleteTasks;
                currentStage.CompletedTasks = StageCompletedTasks;
                stages.Add(currentStage);
            }
            //Converts teamlist to a arrray list 
            var teamMemberInArrayFormat = new int[teamMembers.Count];
            teamMembers.CopyTo(teamMemberInArrayFormat);
            overview.UserIds = teamMemberInArrayFormat;

            var StagesInArrayForm = new StageOverview[stages.Count];
            stages.CopyTo(StagesInArrayForm);
            overview.Stages = StagesInArrayForm;

            return overview;
        }

        /// <summary>
        /// Get requested tasks for a specific user of a given study. By default, the first remaining (still to be completed) task is retrieved.
        /// Optionally, the amount of tasks to retrieve, and the type of tasks to retrieve are specified.
        /// </summary>
        /// <param name="id">The ID of the study to get tasks for.</param>
        /// <param name="userId">The ID of the user to get tasks for.</param>
        /// <param name="count">The amount of tasks to retrieve.</param>
        /// <param name="filter">Defines whether to get remaining tasks, delivered (but still editable) tasks, or completed tasks.</param>
        /// <param name="type">The type of tasks to retrieve.</param>
        public IEnumerable<SystematicStudyService.Models.TaskRequest> GetTasks(int id, int userId, int count = 1, SystematicStudyService.Models.TaskRequest.Filter filter = SystematicStudyService.Models.TaskRequest.Filter.Remaining, SystematicStudyService.Models.TaskRequest.Type type = SystematicStudyService.Models.TaskRequest.Type.Both)
        {

            type = SystematicStudyService.Models.TaskRequest.Type.

            var database = new MainHandler();
            database.GetTasks(id,userId,count,
            throw new NotImplementedException();
        }

        
        public IEnumerable<int> GetTaskIDs(int id, int userId, TaskRequest.Filter filter = TaskRequest.Filter.Editable, TaskRequest.Type type = TaskRequest.Type.Both)
        {
            // GET: api/Study/4/TaskIDs?userId=5&filter=Editable
            throw new NotImplementedException();
        }

        
        public TaskRequest GetTask(int id, int taskId)
        {
            // GET: api/Study/4/Task/5
            throw new NotImplementedException();
        }
        
        public IHttpActionResult PostTask(int id, int taskId, [FromBody]TaskSubmission task)
        {
            // POST: api/Study/4/Task/5
            throw new NotImplementedException();
        }
        
        public IHttpActionResult GetResource(int id, int resourceId)
        {
            // GET: api/Study/4/Resource/5
            throw new NotImplementedException();
        }
    }
}