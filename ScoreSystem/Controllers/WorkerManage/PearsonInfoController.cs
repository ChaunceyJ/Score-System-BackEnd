using ScoreSystem.Models;
using ScoreSystem.Services.AdminManage;
using ScoreSystem.Services.AreaManage;
using ScoreSystem.Services.WorkerManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ScoreSystem.Controllers.WorkerManage
{
    public class PearsonInfoController : ApiController
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
            List<Hashtable> item = getInfo(0, 30, id);
            ht.Add("code", 20000);
            ht.Add("data", item);
            return ht;
        }
        private List<Hashtable> getInfo(int skip, int limit, int admin)
        {
            List<Hashtable> ls = new List<Hashtable>();
            // int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            foreach (criminal i in new PersonInfo().GetPersonInfo(skip, limit, admin))
            {
                Hashtable ht = new Hashtable();
                ht.Add("id", i.id_criminal);
                ht.Add("name", i.name);
                ht.Add("birthday", i.birthday);
                ht.Add("work_content", i.work.context);
                ht.Add("work_id", i.id_work);
                ls.Add(ht);
            }
            return ls;
        }
    }
}