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
    public class ChangeGroupIdController : ApiController
    {

        // POST api/<controller>
        public Hashtable Post([FromBody] int id_group, [FromBody] int id_in_area)
        {
            Hashtable ht = new Hashtable();
            GroupInfo ai = new GroupInfo();
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            if (ai.HasGroup(id_in_area, admin))
            {
                ht.Add("state", false);
                ht.Add("reason", "小组号已存在");
            }
            else
            {
                try
                {
                    ht.Add("state", ai.ChangeGroupid(id_group, id_in_area));
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