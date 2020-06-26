using ScoreSystem.Services.AdminManage;
using ScoreSystem.Services.AreaManage;
using ScoreSystem.Services.WorkerManage;
using System;
using System.Collections;
using System.Web;
using System.Web.Http;

namespace ScoreSystem.Controllers.WorkerManage
{
    public class AddWorkController : ApiController
    {

        // POST api/<controller>
        public Hashtable Post( string content)
        {
            Hashtable ht = new Hashtable();
            WorkInfo ai = new WorkInfo();
            Hashtable data = new Hashtable();
            try
            {
                // ht.Add("state", ai.AddOne(id, name, birthday, admin, work));
                if (ai.AddOne(content, 0))
                {
                    ht.Add("code", 20000);
                    data.Add("id", ai.GetId(content));
                }
                else
                {
                    ht.Add("code", 40000);
                    data.Add("message", "error");
                }
            }
            catch (Exception e)
            {
                ht.Add("code", 40000);
                data.Add("message", e.Message);
            }
            ht.Add("data", data);
            return ht;
        }

        public Hashtable Put(int id, string content)
        {
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            Hashtable ht = new Hashtable();
            WorkInfo ai = new WorkInfo();
            Hashtable data = new Hashtable();
            try
            {
                // ht.Add("state", ai.AddOne(id, name, birthday, admin, work));
                if (ai.ChangeContent(id, content))
                {
                    ht.Add("code", 20000);
                    data.Add("id", id);
                }
                else
                {
                    ht.Add("code", 40000);
                    data.Add("message", "error");
                }
            }
            catch (Exception e)
            {
                ht.Add("code", 40000);
                data.Add("message", e.Message);
            }
            ht.Add("data", data);
            return ht;
        }
    }
}