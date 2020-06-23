using ScoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreSystem.Services.AdminManage
{
    public class UserInfo
    {
        private sorce_systemEntities db = new sorce_systemEntities();

        private string[] auth = { "root", "area", "group", "all" };

        // 密码加密

        // login
        public bool CheckPassword(int type, string userNumber, string password)
        {
            switch (type)
            {
                case 0:
                    var result = db.root_admin.AsEnumerable().Where(p => p.user_number.Equals(userNumber));
                    return result.ToArray()[0].password.Equals(password);
                case 1:
                    var result1 = db.area_admin.AsEnumerable().Where(p => p.user_number.Equals(userNumber));
                    return result1.ToArray()[0].password.Equals(password);
                case 2:
                    var result2 = db.group_admin.AsEnumerable().Where(p => p.user_number.Equals(userNumber));
                    return result2.ToArray()[0].password.Equals(password);
                default:
                    return false;
            }
        }

        public int GetUserIdFromCookie(string cookies)
        {
            return 0;
        }

        public string GetAuthFromCookie(string cookies)
        {
            return auth[3];
        }

        public string GenerateCookie(int type, int user_id)
        {
            return "";
        }
    }
}