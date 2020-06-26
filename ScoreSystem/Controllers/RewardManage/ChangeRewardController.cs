using ScoreSystem.Services.AdminManage;
using ScoreSystem.Services.RewardManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ScoreSystem.Controllers.RewardManage
{
    public class ChangeRewardController : ApiController
    {
        public Hashtable Post([FromBody] int id_exam, [FromBody] int rule, [FromBody] DateTime dateTime, [FromBody] int score, [FromBody] string kind, [FromBody] string detail)
        {
            Hashtable ht = new Hashtable();
            RewardInfo ai = new RewardInfo();
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            try
            {
                ht.Add("state", ai.ChangeContext(id_exam, rule, dateTime, admin, score, kind, detail));
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