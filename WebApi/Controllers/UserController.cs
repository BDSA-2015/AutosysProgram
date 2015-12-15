using System;
using System.Collections.Generic;
using System.Web.Http;

using AutoMapper;
using ApplicationLogics.AutosysServer;
using System.Net;
using System.Diagnostics;
using WebApi.Mapping.Profiles;
using WebApi.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Models;
using ApplicationLogics.StudyManagement;
using DConflictingData = ApplicationLogics.StudyManagement.ConflictingData;
using AConflictingData = WebApi.Models.ConflictingData;
using DCriteria = ApplicationLogics.StudyManagement.Criteria;
using DDataField = ApplicationLogics.StudyManagement.DataField;
using ADataField = WebApi.Models.DataField;
using AStage = WebApi.Models.StageOverview;
using DStage = ApplicationLogics.StudyManagement.Phase;
using DTask = ApplicationLogics.StudyManagement.TaskRequest;
using ATask = WebApi.Models.TaskRequest;
using DUser = ApplicationLogics.UserManagement.Entities.User;
using DTeam = ApplicationLogics.UserManagement.Entities.Team;
using AUser = WebApi.Models.User;
using ATeam = WebApi.Models.Team;
using System.Net.Http;

namespace WebApi.Controllers
{
    /// <summary>
    ///     Controller to access and modify users.
    /// </summary>
    [RoutePrefix("api/User")]
    public class UserController : ApiController
    {




        private readonly MainHandler _facade;

        // Injecting a facade with IDisposable 
        public UserController()
        {
             _facade = MainHandler();
        }

        /// <summary>
        ///     Get all users.
        /// </summary>
        /// <param name="name">Search for users which match the specified name.</param>
        public IEnumerable<User> Get(string name = "")
        {
            AUser[] aUsers = null;


            DUser[] dUsers = null;//_facade.getAllUsers(name);
            aUsers = new User[dUsers.Length];
            for (int i = 0; i < dUsers.Length; i++)
            {
                aUsers[i] = Mapper.Map<AUser>(dUsers[i]);
            }

            return aUsers;

        }

        /// <summary>
        ///     Get the user with the specific ID.
        /// </summary>
        /// <param name="id">The ID of the user to retrieve.</param>
        public User Get(int id)
        {
            DUser dUser = null;// _facade.getUser(id);


            return null;

            return Mapper.Map<AUser>(dUser);


        }

        public UserController()
        {

        }

        /// <summary>
        ///     Get all study IDs of studies a given user is part of.
        /// </summary>
        /// <param name="id">The ID of the user to get study IDs for.</param>
        /// <returns></returns>
        [Route("{id}/StudyIDs")]
        public IEnumerable<int> GetStudyIDs(int id)
        {
            return new int[] { 1, 2, 3 };
            // GET: api/User/5/StudyIDs
            throw new NotImplementedException();
        }

        /// <summary>
        ///     Create a new user.
        /// </summary>
        /// <param name="user">The new user to create.</param>
        public IHttpActionResult Post([FromBody] User user)
        {
             
            HttpResponseMessage databaseResponse =  _facade.CreateUser();
            
            return ResponseMessage(Request.CreateErrorResponse(databaseResponse.StatusCode, databaseResponse.ReasonPhrase));
        }

        /// <summary>
        ///     Update the user with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="user">The new user data.</param>
        public IHttpActionResult Put(int id, [FromBody] AUser user)
        {
            // PUT: api/User/5

           HttpResponseMessage databaseResponse = _facade.UpdateUser();

           return ResponseMessage(Request.CreateErrorResponse(databaseResponse.StatusCode, databaseResponse.ReasonPhrase));
        }

        /// <summary>
        ///     Delete the user with the specified ID.
        ///     A user can not be deleted when the user is participating in a study.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        public IHttpActionResult Delete(int id)
        {
            // DELETE: api/User/5
            HttpResponseMessage databaseResponse = _facade.DeleteUser();

            return ResponseMessage(Request.CreateErrorResponse(databaseResponse.StatusCode, databaseResponse.ReasonPhrase));
        }

        /// <summary>
        ///     Clean up, allows to release resources per request when using underlying logic to access database.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            // _facade.Dispose(); TODO make all interfaces down to db implement IDisposable 
            base.Dispose(disposing);
        }
    }
}