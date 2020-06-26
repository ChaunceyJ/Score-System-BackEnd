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
    public class RewardInfoController : ApiController
    {

        // POST api/<controller>
        public List<Hashtable> Post([FromBody] int skip, [FromBody] int limit, [FromBody] int group_id, [FromBody] DateTime start_time, [FromBody] DateTime end_time)
        {
            List<Hashtable> ls = new List<Hashtable>();

            foreach (exam_record i in new RewardInfo().GetRewardInfo(skip, limit, group_id, start_time, end_time))
            {
                Hashtable ht = new Hashtable();
                ht.Add("record_id", i.idexam_record);
                ht.Add("rule_id", i.id_rule);
                //ht.Add("article_id", i.rule.article_id);
                //ht.Add("num_id", i.rule.num_id);
                ht.Add("context", i.rule.context);
                ht.Add("score", i.score);
                ht.Add("date", i.exam_date);
                ht.Add("worker_id", i.id_crimial);
                ht.Add("worker_name", i.criminal.name);
                ht.Add("group_admin_id", i.group_check_id);
                ht.Add("group_admin_name", i.group_admin.name);
                ht.Add("area_admin_id", i.area_check_id);
                ht.Add("area_admin_name", i.area_admin.name);
                ht.Add("root_admin_id", i.root_check_id);
                ht.Add("root_admin_name", i.root_admin.name);
                ls.Add(ht);
            }
            return ls;
        }

        public Hashtable Get(int page,  int limit,  int group_id)
        {
            Hashtable ht = new Hashtable();
            Hashtable data = new Hashtable();
            RewardInfo ai = new RewardInfo();
            ht.Add("code", 20000);
            data.Add("items", Hashtables(ai.GetRewardInfo((page-1)*limit, limit, group_id)));
            data.Add("total", ai.GetSize(group_id));
            ht.Add("data", data);
            return ht;
        }

        public Hashtable Get( int page,  int limit,  int group_id,  string worker_name,  int worker_id)
        {
            Hashtable ht = new Hashtable();
            Hashtable data = new Hashtable();
            RewardInfo ai = new RewardInfo();
            ht.Add("code", 20000);
            data.Add("items", Hashtables(ai.GetRewardInfo((page - 1) * limit, limit, group_id)));
            data.Add("total", ai.GetSize(group_id));
            ht.Add("data", data);
            return ht;
        }

        private List<Hashtable> Hashtables(Array array)
        {
            List<Hashtable> ls = new List<Hashtable>();
            ScoreSystem.Services.AdminManage.AdminInfo adminInfo = new Services.AdminManage.AdminInfo();

            foreach (exam_record i in array)
            {
                Hashtable ht = new Hashtable();
                ht.Add("record_id", i.idexam_record);
                ht.Add("rule_id", i.id_rule);
                //ht.Add("article_id", i.rule.article_id);
                //ht.Add("num_id", i.rule.num_id);
                ht.Add("context", i.rule.context);
                ht.Add("score", i.score);
                ht.Add("date", i.exam_date);
                ht.Add("worker_id", i.id_crimial);
                ht.Add("worker_name", i.criminal.name);
                ht.Add("group_admin_id", i.group_check_id);
                ht.Add("group_admin_name", i.group_admin.name);
                ht.Add("area_admin_id", i.area_check_id);
                if(i.area_check_id == null)
                {
                    ht.Add("area_admin_name", null);
                }
                else
                {
                    ht.Add("area_admin_name",adminInfo.GetAreaAdminName((int)i.area_check_id));
                }
                ht.Add("root_admin_id", i.root_check_id);
                if (i.root_check_id == null)
                {
                    ht.Add("root_admin_name", null);
                }
                else
                {
                    ht.Add("root_admin_name", adminInfo.GetRootAdminName((int)i.root_check_id));
                }
                ls.Add(ht);
            }
            return ls;
        }
    }
}