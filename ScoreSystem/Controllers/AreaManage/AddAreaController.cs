using ScoreSystem.Services.AdminManage;
using ScoreSystem.Services.AreaManage;
using System;
using System.Collections;
using System.Web;
using System.Web.Http;

namespace ScoreSystem.Controllers.AreaManage
{
    public class AddAreaController : ApiController
    {

        // POST api/<controller>
        //public Hashtable Post([FromBody] string area_name, [FromBody] string name, [FromBody] string password, [FromBody] string user_number)
        //{
        //  int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
        public Hashtable Post(string area_name, string name, string password, string user_number)
        {
            int admin = 1;
            Hashtable ht = new Hashtable();
            Hashtable data = new Hashtable();
            AreaInfo ai = new AreaInfo();
            if (ai.HasAreaName(area_name))
            {
                ht.Add("code", 40000);
                data.Add("message", "部门已存在");
            }
            else if(new AdminInfo().HasAreaUserName(name))
            {
                ht.Add("code", 40000);
                data.Add("message", "管理员已存在");
            }
            else
            {
                try
                {
                    if(ai.AddOne(area_name, name, UserInfo.cypher(password), user_number, admin))
                    {
                        ht.Add("code", 20000);
                        data.Add("id", ai.GetId(area_name));
                    }
                    else
                    {
                        ht.Add("code", 40000);
                        data.Add("message", "error");
                    }
                }catch (Exception e)
                {
                    ht.Add("code", 40000);
                    data.Add("message", e.Message);
                }
            }
            ht.Add("data", data);
            return ht;
        }

        // PUT api/values/5
       // public Hashtable Put(int id, [FromBody] string area_name, [FromBody] string name, [FromBody] string user_number)
        //{
            public Hashtable Put(int id, string area_name, string name, string user_number)
        {
            //int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            int admin = 1;
            Hashtable ht = new Hashtable();
            Hashtable data = new Hashtable();
            AdminInfo ai = new AdminInfo();
            AreaInfo ari = new AreaInfo();
            /* if (ai.HasAreaUserName(name))
             {
                 ht.Add("code", 40000);
                 data.Add("message", "管理员已存在");
                             }
             else if(ari.HasAreaName(area_name))
             {
                 ht.Add("code", 40000);
                 data.Add("message", "部门名字已存在");
             }
             else
             {*/
            try
            {
                    if (ari.ChangeAreaName(id, area_name) &&
                        ai.ChangeAreaAdmin(id, name, null, user_number, admin))
                    {
                        ht.Add("code", 20000);
                        data.Add("status", "success");
                    }
                    else
                    {
                        ht.Add("code", 40000);
                        data.Add("message", "failed");
                    }
                }
                catch (Exception e)
                {
                    ht.Add("code", 40000);
                    data.Add("message", e.Message);
                }
               
            //}
            ht.Add("data", data);
            return ht;
        }
    }
}