using ApplicationLogics.AutosysServer;
using ApplicationLogics.PaperManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class BibtexController : ApiController
    {
        private readonly MainHandler _facade = new MainHandler();

        // GET: api/Bibtex
        public IHttpActionResult Get()
        {
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ""));
        }

        // GET: api/Bibtex/5
        public IHttpActionResult Get(int id)
        {
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ""));
        }

        // POST: api/Bibtex
        public BibtexTag[] Post([FromBody]string value)
        {
            Tuple<BibtexTag[], IHttpActionResult> dataAnswer = _facade.ConvertBibTexContentToTags(string value);
            if (dataAnswer.Item1 == null)
            {
                return null;
            }
            else return dataAnswer.Item1;
        }

//ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "You must provide a valid User"));        }

            // PUT: api/Bibtex/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ""));
        }

        // DELETE: api/Bibtex/5
        public IHttpActionResult Delete(int id)
        {
            return ResponseMessage(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ""));
        }
    }
}
