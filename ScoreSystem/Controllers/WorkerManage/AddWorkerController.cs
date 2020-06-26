using ScoreSystem.Services.AdminManage;
using ScoreSystem.Services.AreaManage;
using ScoreSystem.Services.WorkerManage;
using System;
using System.Collections;
using System.Web;
using System.Web.Http;

namespace ScoreSystem.Controllers.WorkerManage
{
    public class AddWorkerController : ApiController
    {

        // POST api/<controller>
        public Hashtable Post( int id,  string name,  DateTime birthday,  int work_id)
        {
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            Hashtable ht = new Hashtable();
            PersonInfo ai = new PersonInfo();
            Hashtable data = new Hashtable();
            try
            {
                // ht.Add("state", ai.AddOne(id, name, birthday, admin, work));
                if (ai.AddOne(id, name, birthday, admin, work_id))
                {
                    ht.Add("code", 20000);
                    data.Add("id", id);
                    data.Add("work_content", new WorkInfo().GetContent(work_id));
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

        public Hashtable Put(int id,  string name,  DateTime birthday,  int work_id)
        {
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            Hashtable ht = new Hashtable();
            PersonInfo ai = new PersonInfo();
            Hashtable data = new Hashtable();
            try
            {
                // ht.Add("state", ai.AddOne(id, name, birthday, admin, work));
                if (ai.ChangeInfo(id ,0 , name, birthday, work_id))
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