using ScoreSystem.Services.AdminManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ScoreSystem.Controllers.AdminManage
{
    public class ResetPasswordController : ApiController
    {

        // POST api/<controller>
        public Hashtable Post( string password,  int type,  int id)
        {
            Hashtable ht = new Hashtable();
            Hashtable data = new Hashtable();
            bool res = false;
            AdminInfo ai = new AdminInfo();
            if (type == 1)
            {
                res = ai.ChangeAreaAdmin(id, null, UserInfo.cypher(password), null, 0);
            }else if(type == 2)
            {
                res = ai.ChangeGroupAdmin(id, null, UserInfo.cypher(password), null, 0);
            }
            if (res)
            {
                ht.Add("code", 20000);
                data.Add("id", id);
                ht.Add("data", data);
            }
            else
            {
                ht.Add("code", 40000);
                data.Add("message", "重置");
                ht.Add("data", data);
            }
            return ht;
        }

    }
}