using ScoreSystem.Controllers.WorkerManage;
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
    public class AddRewardController : ApiController
    {

        // POST api/<controller>
        /*public Hashtable Post([FromBody] int id_crimal, [FromBody] int rule, [FromBody] DateTime dateTime, [FromBody] int score, [FromBody] string kind, [FromBody] string detail)
        {
            Hashtable ht = new Hashtable();
            RewardInfo ai = new RewardInfo();
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            try
            {
                ht.Add("state", ai.AddOne(id_crimal, rule, dateTime, admin, score, kind, detail));
            }
            catch (Exception e)
            {
                ht.Add("state", false);
                ht.Add("reason", e.Message);
            }
            return ht;
        }*/

        // POST api/<controller>
        public Hashtable Post( int worker_id,  int rule_id,  DateTime date,  int score)
        {
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            Hashtable ht = new Hashtable();
            Hashtable data = new Hashtable();
            RewardInfo ai = new RewardInfo();
            try
            {
                Models.exam_record record = ai.AddOne(worker_id, rule_id, date, admin, score);
                ht.Add("code", 20000);
                int id_record = record.idexam_record;
                data.Add("record_id", id_record);
                data.Add("worker_name", new Services.WorkerManage.PersonInfo().GetPersonName((int)record.id_crimial));
                data.Add("context", new RuleInfo().GetContent((int)record.id_rule));
                data.Add("group_admin_name", new AdminInfo().GetGroupAdminName((int)record.group_check_id));
            }
            catch (Exception e)
            {
                if (ht.ContainsKey("code"))
                {
                    ht.Remove("code");
                }
                ht.Add("code", 40000);
                data.Add("message", e.Message);
            }
            ht.Add("data", data);
            return ht;
        }

        // PUT api/values/5
        public Hashtable Put(int id, int worker_id, int rule_id, DateTime date, int score)
        {
            Hashtable ht = new Hashtable();
            Hashtable data = new Hashtable();
            RewardInfo ai = new RewardInfo();
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            try
            {
                ht.Add("code", 20000);
                ai.ChangeContext(id, rule_id, date, admin, score, null, null);
            }
            catch (Exception e)
            {
                if (ht.ContainsKey("code"))
                {
                    ht.Remove("code");
                }
                ht.Add("code", 40000);
                data.Add("message", e.Message);
            }
            ht.Add("data", data);
            return ht;
        }

    }
}