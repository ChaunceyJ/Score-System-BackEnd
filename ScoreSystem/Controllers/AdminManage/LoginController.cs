using ScoreSystem.Services.AdminManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ScoreSystem.Controllers.AdminManage
{
   
    public class LoginController : ApiController
    {
        // POST api/<controller>
        public Hashtable Post( int type,  string username,  string password)
        {
            Hashtable ht = new Hashtable();
            // var type1 = int.Parse(type);
            if (UserInfo.CheckPassword(type, username, UserInfo.cypher(password)))
            {
                ht.Add("code", 20000);
                // ht.Add("data", UserInfo.GenerateCookie(UserInfo.GetUserId(username, type), type));
                Hashtable data = new Hashtable();
                data.Add("token", type);
                data.Add("user_id", UserInfo.GetUserId(username, type));
                ht.Add("data", data);
                //HttpContext.Current.Response.AppendCookie(
                //   UserInfo.GenerateCookie(UserInfo.GetUserId(username, type), type));
            }
            else
            {
                ht.Add("code", 40000); ;
            }
            return ht;
        }

        public Hashtable Get()
        {
            Hashtable ht = new Hashtable();
            Hashtable data = new Hashtable();
            data.Add("token", "admin-token");
            data.Add("user_id", 100);
            ht.Add("code", 20000);
            ht.Add("data", data);
            return ht;
        }
    }
}