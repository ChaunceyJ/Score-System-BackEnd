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
    public class DeleteRewardController : ApiController
    {
        // GET api/<controller>
        public Hashtable Get(int id)
        {
            Hashtable ht = new Hashtable();
            RewardInfo ai = new RewardInfo();
            try
            {
                ht.Add("state", ai.DeleteOne(id));
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