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
    public class AreaInfoController : ApiController
    {
        public Hashtable Get()
        {
            Hashtable ht = new Hashtable();
            List<Hashtable> item = Post(0, 10);
            ht.Add("code", 20000);
            ht.Add("data", item);
            return ht;
        }
        
        // POST api/<controller>
        public List<Hashtable> Post([FromBody] int skip, [FromBody] int limit)
        {
            List<Hashtable> ls = new List<Hashtable>();
            //int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            foreach (area_admin i in new AreaInfo().GetAreaInfo(skip, limit, 1))
            {
                Hashtable ht = new Hashtable();
                ht.Add("id", i.id_area_admin);
                ht.Add("area_name", i.area_name);
                ht.Add("user_number", i.user_number);
                ht.Add("name", i.name);
                ls.Add(ht);
            }
            return ls;
        }

    }
}