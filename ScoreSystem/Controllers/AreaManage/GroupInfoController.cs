using ScoreSystem.Models;
using ScoreSystem.Services.AdminManage;
using ScoreSystem.Services.AreaManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ScoreSystem.Controllers.AreaManage
{
    public class GroupInfoController : ApiController
    {

        // POST api/<controller>
        public List<Hashtable> Post([FromBody] int skip, [FromBody] int limit)
        {
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            return getInfo(skip, limit, admin);
        }
        public Hashtable Get(int id)
        {
            Hashtable ht = new Hashtable();
            List<Hashtable> item = getInfo(0, 10, id);
            ht.Add("code", 20000);
            ht.Add("data", item);
            return ht;
        }

        private List<Hashtable> getInfo(int skip, int limit, int admin)
        {
            List<Hashtable> ls = new List<Hashtable>();
            foreach (group_admin i in new GroupInfo().GetGroupInfo(skip, limit, admin))
            {
                Hashtable ht = new Hashtable();
                ht.Add("id", i.id_group_admin);
                ht.Add("group_name", i.group_id_in_area);
                ht.Add("user_number", i.user_number);
                ht.Add("name", i.name);
                ls.Add(ht);
            }
            return ls;
        }
    }
}