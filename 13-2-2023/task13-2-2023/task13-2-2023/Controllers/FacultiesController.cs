﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace task13_2_2023.Controllers
{
    public class FacultiesController : ApiController
    {
        // GET: api/Faculties
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Faculties/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Faculties
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Faculties/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Faculties/5
        public void Delete(int id)
        {
        }
    }
}
