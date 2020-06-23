using ScoreSystem.Services.AdminManage;
using ScoreSystem.Services.WorkerManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ScoreSystem.Controllers
{
    
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /*        public void Get()
                {

                }*/

        // GET api/values/5
        public Hashtable Get(int id)
        {
            Hashtable ht = new Hashtable();
            ht.Add("re", new WorkInfo().HasUsed(id));
            return ht;
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}
