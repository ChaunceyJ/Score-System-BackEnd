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
    public class ChangeRuleController : ApiController
    {
        public Hashtable Post([FromBody] int id,  [FromBody] string context)
        {
            Hashtable ht = new Hashtable();
            RuleInfo ai = new RuleInfo();
            try
            {
                ht.Add("state", ai.ChangeContext(id, context));
            }
            catch (Exception e)
            {
                ht.Add("state", false);
                ht.Add("reason", e.Message);
            }
            return ht;
        }
    }
}