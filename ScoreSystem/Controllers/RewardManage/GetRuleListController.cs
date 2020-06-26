using ScoreSystem.Models;
using ScoreSystem.Services.RewardManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ScoreSystem.Controllers.RewardManage
{
    public class GetRuleListController : ApiController
    {
        // GET api/<controller>
        public Hashtable Get()
        {
            Hashtable res = new Hashtable();
            List<Hashtable> ls = new List<Hashtable>();
            RuleInfo ai = new RuleInfo();

            foreach (rule i in ai.GetRuleInfo(0, 20)) // admin = 1
            {
                Hashtable ht = new Hashtable();
                ht.Add("id", i.id_rule);
                ht.Add("name", i.context);
                ls.Add(ht);
            }
            res.Add("code", 20000);
            res.Add("data", ls);
            return res;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
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