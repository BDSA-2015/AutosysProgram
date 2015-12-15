using System;
using System.Collections.Generic;
using System.Web.Http;
using ApplicationLogics.AutosysServer;
using WebApi.Models;
using System.Net.Http;
using DStage = ApplicationLogics.StudyManagement.Phase;
using DTask = ApplicationLogics.StudyManagement.TaskRequest;
using ATask = WebApi.Models.TaskRequest;
using DUser = ApplicationLogics.UserManagement.Entities.User;
using DTeam = ApplicationLogics.UserManagement.Entities.Team;
using AUser = WebApi.Models.User;
using ATeam = WebApi.Models.Team;
using AutoMapper;
using System.Linq;

namespace WebApi.Controllers
{
    /// <summary>
    ///     Controller to access and modify teams.
    /// </summary>
    public class TeamController : ApiController
    {
        private readonly MainHandler _facade;

        // Injecting a facade with IDisposable 
        public TeamController()
        {
            _facade = new MainHandler();
        }

        /// <summary>
        ///     Get all teams.
        /// </summary>
        /// <param name="name">Search for teams which match the specified name.</param>
        public IEnumerable<Team> Get(string name = "")
        {
            // GET: api/Team
            // GET: api/Team?name=untouchables
            Tuple<IEnumerable<DTeam>, HttpResponseMessage> databaseReponse = _facade.GetTeams(name);
            if (databaseReponse.Item2.IsSuccessStatusCode)
            {
                foreach (DTeam team in databaseReponse.Item1)
                {
                    yield return Mapper.Map<ATeam>(team);
                }
            }
            else yield break;
        }

        /// <summary>
        ///     Get the team with the specific ID.
        /// </summary>
        /// <param name="id">The ID of the team to retrieve.</param>
        public Team Get(int id)
        {
            // GET: api/Team/5
            Tuple<DTeam, HttpResponseMessage> databaseReponse = _facade.GetTeam(name);
            if (databaseResponse.Item2.IsSuccessStatusCode)
            {
                return Mapper.Map<ATeam>(databaseReponse.Item1);
            }
            else return null;
        }

        /// <summary>
        ///     Create a new Team.
        /// </summary>
        /// <param name="team">The new team to create.</param>
        public IHttpActionResult Post([FromBody] Team team)
        {
            // POST: api/Team
            var dTeam = Mapper.Map<DTeam>(team);
            HttpResponseMessage databaseResponse = _facade.CreateTeam(dTeam);
            return ResponseMessage(Request.CreateResponse(databaseResponse.StatusCode, databaseResponse.ReasonPhrase));
        }

        /// <summary>
        ///     Update the team with the specified ID.
        ///     The list of users part of the team can not be modified once it has been created.
        /// </summary>
        /// <param name="id">The ID of the team to update.</param>
        /// <param name="user">The new team data.</param>
        public IHttpActionResult Put(int id, [FromBody] ATeam team)
        {
            // PUT: api/Team/5
            var dTeam = Mapper.Map<DTeam>(team);

            HttpResponseMessage databaseResponse = _facade.UpdateTeam(Id, dTeam);
            return ResponseMessage(Request.CreateResponse(databaseResponse.StatusCode, databaseResponse.ReasonPhrase));
        }

        /// <summary>
        ///     Delete the team with the specified ID.
        ///     A team can not be deleted when it is participating in a study.
        /// </summary>
        /// <param name="id">The ID of the team to delete.</param>
        public IHttpActionResult Delete(int id)
        {
            // DELETE: api/Team/5
            HttpResponseMessage databaseResponse = _facade.DeleteTeam(id);
            return ResponseMessage(Request.CreateResponse(databaseResponse.StatusCode, databaseResponse.ReasonPhrase));
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