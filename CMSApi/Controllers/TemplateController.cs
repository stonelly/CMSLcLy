using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CMSApi.Models;

namespace CMSApi.Controllers
{

    public class TemplateController : ApiController
    {
        public TemplateController()
        {
        }
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public IHttpActionResult Post(DocumentModel documentmodel)
        {
            if (!ModelState.IsValid)
                return BadRequest("Not a valid model");

            DataHelper.AddDocumentTemplate(documentmodel);
            return Ok();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}