using ScoreSystem.Services.AdminManage;
using ScoreSystem.Services.RewardManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace ScoreSystem.Controllers.RewardManage
{
    public class RootCheckController : ApiController
    {
        
        // GET api/<controller>/5
        public Hashtable Get(int id)
        {
            Hashtable res = new Hashtable();
            Hashtable ht = new Hashtable();
            int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
            new RewardInfo().RootAdminCheck(id, admin);
            res.Add("code", 20000);
            ht.Add("root_admin_id", admin);
            ht.Add("root_admin_name", new AdminInfo().GetRootAdminName(admin));
            res.Add("data", ht);
            return res;
        }

    }
}