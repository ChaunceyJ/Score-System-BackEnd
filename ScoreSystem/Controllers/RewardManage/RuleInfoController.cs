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
    public class RuleInfoController : ApiController
    {

        // POST api/<controller>
        public List<Hashtable> Post([FromBody] int skip, [FromBody] int limit)
        {
            List<Hashtable> ls = new List<Hashtable>();
            foreach (rule i in new RuleInfo().GetRuleInfo(skip, limit))
            {
                Hashtable ht = new Hashtable();
                ht.Add("rule_id", i.id_rule);
                ht.Add("article_id", i.article_id);
                ht.Add("num_id", i.num_id);
                ht.Add("context", i.context);
                ls.Add(ht);
            }
            return ls;
        }

        public Hashtable Get()
        {
            Hashtable ht = new Hashtable();
            List<Hashtable> item = getInfo(0, 30);
            ht.Add("code", 20000);
            ht.Add("data", item);
            return ht;
        }
        private List<Hashtable> getInfo(int skip, int limit)
        {
            List<Hashtable> ls = new List<Hashtable>();
            // int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            foreach (rule i in new RuleInfo().GetRuleInfo(skip, limit))
            {
                Hashtable ht = new Hashtable();
                ht.Add("id", i.id_rule);
                ht.Add("content", i.context);
                ls.Add(ht);
            }
            return ls;
        }
    }
}