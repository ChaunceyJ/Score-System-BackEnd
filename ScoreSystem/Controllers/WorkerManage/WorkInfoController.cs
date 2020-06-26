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
    public class WorkInfoController : ApiController
    {

        // POST api/<controller>
        public List<Hashtable> Post([FromBody] int skip, [FromBody] int limit)
        {
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            return getInfo(skip, limit);
        }
        public Hashtable Get()
        {
            Hashtable ht = new Hashtable();
            List<Hashtable> item = getInfo(0, 30);
            ht.Add("code", 20000);
            ht.Add("data", item);
            return ht;
        }
        private List<Hashtable> getInfo(int skip, int limit)
        {
            List<Hashtable> ls = new List<Hashtable>();
            // int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            foreach (work i in new WorkInfo().GetWorkInfo(skip, limit))
            {
                Hashtable ht = new Hashtable();
                ht.Add("id", i.id_work);
                ht.Add("content", i.context);
                ls.Add(ht);
            }
            return ls;
        }
    }
}