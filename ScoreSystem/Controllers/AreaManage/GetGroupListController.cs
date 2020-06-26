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
    public class GetGroupListController : ApiController
    {
        // GET api/<controller>
        public Hashtable Get()
        {
            Hashtable res = new Hashtable();
            List<Hashtable> ls = new List<Hashtable>();
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            string auth = UserInfo.GetAuthFromCookie(HttpContext.Current);
            AreaInfo ai = new AreaInfo();
            if (auth.Equals("root"))
            {
                foreach (area_admin i in ai.GetAreaInfo(0, 10, admin)) // admin = 1
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("id", i.id_area_admin);
                    ht.Add("name", i.area_name);
                    ls.Add(ht);
                }
            }
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("id", admin);
                ht.Add("name", ai.GetAreaName(admin));
                ls.Add(ht);
            }
            res.Add("code", 20000);
            res.Add("data", ls);
            return res;
        }

        // GET api/<controller>/5
        public Hashtable Get(int id)
        {
            Hashtable res = new Hashtable();
            List<Hashtable> ls = new List<Hashtable>();
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            string auth = UserInfo.GetAuthFromCookie(HttpContext.Current);
            GroupInfo ai = new GroupInfo();
            if (!auth.Equals("group"))
            {
                foreach (group_admin i in ai.GetGroupInfo(0, 10, id)) // admin = 1
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("id", i.group_id_in_area);
                    ht.Add("name", i.id_group_admin);
                    ls.Add(ht);
                }
             }
            else
            {
                Hashtable ht = new Hashtable();
                ht.Add("id", admin);
                ht.Add("name", ai.GetGroupName(admin));
                ls.Add(ht);
            }
            res.Add("code", 20000);
            res.Add("data", ls);
            return res;
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