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

namespace ScoreSystem.Controllers.AdminManage
{
    public class ChangeGroupController : ApiController
    {
        
        // POST api/<controller>
        public Hashtable Post([FromBody] int areaid, [FromBody] string name, [FromBody] string user_number)
        {
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            Hashtable ht = new Hashtable();
            AdminInfo ai = new AdminInfo();
            if (ai.HasGroupUserName(name))
            {
                ht.Add("state", false);
                ht.Add("reason", "管理员已存在");
            }
            else
            {
                try
                {
                    ht.Add("state", ai.ChangeGroupAdmin(areaid, name, null, user_number, admin));
                }
                catch (Exception e)
                {
                    ht.Add("state", false);
                    ht.Add("reason", e.Message);
                }
            }
            return ht;
        }

    }
}