using ScoreSystem.Services.AdminManage;
using ScoreSystem.Services.AreaManage;
using System;
using System.Collections;
using System.Web;
using System.Web.Http;

namespace ScoreSystem.Controllers.AreaManage
{
    public class AddGroupController : ApiController
    {

        // POST api/<controller>
        public Hashtable Post( int group_name,  string name,  string password,  string user_number)
        {
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            Hashtable ht = new Hashtable();
            Hashtable data = new Hashtable();
            GroupInfo ai = new GroupInfo();
            if (ai.HasGroup(group_name, admin))
            {
                ht.Add("code", 40000);
                data.Add("message", "小组已存在");
            }
            else if(new AdminInfo().HasGroupUserName(name))
            {
                ht.Add("code", 40000);
                data.Add("message", "管理员已存在");
            }
            else
            {
                try
                {
                    // ht.Add("state", ai.AddOne(group_name, name, UserInfo.cypher(password), user_number, admin));
                    if (ai.AddOne(group_name, name, UserInfo.cypher(password), user_number, admin))
                    {
                        ht.Add("code", 20000);
                        data.Add("id", ai.GetId(group_name));
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
            }
            ht.Add("data", data);
            return ht;
        }

        public Hashtable Put(int id,  int group_name,  string name,  string user_number)
        {
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            Hashtable ht = new Hashtable();
            Hashtable data = new Hashtable();
            AdminInfo ai = new AdminInfo();
            GroupInfo ari = new GroupInfo();
            /*if (ai.HasAreaUserName(name))
            {
                ht.Add("code", 40000);
                data.Add("message", "管理员已存在");
            }
            else if (ari.HasGroup(group_name, admin))
            {
                ht.Add("code", 40000);
                data.Add("message", "小组号已存在");
            }
            else
            {*/
                try
                {
                    if (ari.ChangeGroupid(id, group_name) &&
                        ai.ChangeGroupAdmin(id, name, null, user_number, admin))
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