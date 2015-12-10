using System;
using System.Collections.Generic;
using System.Web.Http;
using ApplicationLogics.AutosysServer;
using ApplicationLogics.UserManagement;
using Team = SystematicStudyService.Models.Team;

namespace WebApi.Controllers
{
    /// <summary>
    /// Controller to access and modify teams.
    /// </summary>
    public class TeamController : ApiController
    {

        /*
        private IDisposable _facade;
         
        public UserController(IDisposable facade)
        {
            _facade = facade;
        }
        */

        private readonly MainHandler _facade;

        // Injecting a facade with IDisposable 
        public TeamController(MainHandler facade)
        {
            _facade = facade;
        }

        /// <summary>
        /// Get all teams.
        /// </summary>
        /// <param name="name">Search for teams which match the specified name.</param>
        public IEnumerable<Team> Get(string name = "")
        {
            // GET: api/Team
            // GET: api/Team?name=untouchables
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the team with the specific ID.
        /// </summary>
        /// <param name="id">The ID of the team to retrieve.</param>
        public Team Get(int id)
        {
            // GET: api/Team/5
            throw new NotImplementedException();
        }

        /// <summary>
        /// Create a new Team.
        /// </summary>
        /// <param name="team">The new team to create.</param>
        public IHttpActionResult Post([FromBody]Team team)
        {
            // POST: api/Team
            throw new NotImplementedException();
        }

        /// <summary>
        /// Update the team with the specified ID.
        /// The list of users part of the team can not be modified once it has been created.
        /// </summary>
        /// <param name="id">The ID of the team to update.</param>
        /// <param name="user">The new team data.</param>
        public IHttpActionResult Put(int id, [FromBody]Team user)
        {
            // PUT: api/Team/5
            throw new NotImplementedException();
        }

        /// <summary>
        /// Delete the team with the specified ID.
        /// A team can not be deleted when it is participating in a study.
        /// </summary>
        /// <param name="id">The ID of the team to delete.</param>
        public IHttpActionResult Delete(int id)
        {
            // DELETE: api/Team/5
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clean up, allows to release resources per request when using underlying logic to access database. 
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            // _facade.Dispose(); TODO make all interfaces down to db implement IDisposable 
            base.Dispose(disposing);
        }
    }
}
