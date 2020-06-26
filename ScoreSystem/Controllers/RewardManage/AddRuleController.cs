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
    public class AddRuleController : ApiController
    {

        // POST api/<controller>
        /*public Hashtable Post([FromBody] int article_id, [FromBody] int num_id, [FromBody] string context)
        {
            Hashtable ht = new Hashtable();
            RuleInfo ai = new RuleInfo();
            if (ai.HasName(article_id, num_id))
            {
                ht.Add("state", false);
                ht.Add("reason", "条款已存在");
            }
            else
            {
                try
                {
                    ht.Add("state", ai.AddOne(article_id, num_id, context));
                }
                catch (Exception e)
                {
                    ht.Add("state", false);
                    ht.Add("reason", e.Message);
                }
            }
            return ht;
        }*/

        public Hashtable Post( string content)
        {
            Hashtable ht = new Hashtable();
            RuleInfo ai = new RuleInfo();
            Hashtable data = new Hashtable();
            try
            {
                if (ai.AddOne(0, 0, content))
                {
                    ht.Add("code", 20000);
                    data.Add("id", ai.GetId(content));
                }
                else
                {
                    ht.Add("code", 40000);
                    data.Add("message", "error");
                }
            }
            catch (Exception e)
            {
                ht.Add("code", 40000);
                data.Add("message", e.Message);
            }
            ht.Add("data", data);
            return ht;
        }

        public Hashtable Put(int id,  string content)
        {
            Hashtable ht = new Hashtable();
            RuleInfo ai = new RuleInfo();
            Hashtable data = new Hashtable();
            try
            {
                // ht.Add("state", ai.AddOne(id, name, birthday, admin, work));
                if (ai.ChangeContext(id, content))
                {
                    ht.Add("code", 20000);
                    data.Add("id", id);
                }
                else
                {
                    ht.Add("code", 40000);
                    data.Add("message", "error");
                }
            }
            catch (Exception e)
            {
                ht.Add("code", 40000);
                data.Add("message", e.Message);
            }
            ht.Add("data", data);
            return ht;
        }
    }
}