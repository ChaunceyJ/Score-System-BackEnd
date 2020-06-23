using ScoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
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

        public int GetUserIdFromCookie(HttpContext context)
        {
            HttpCookie cookie = context.Request.Cookies["UserInfo"];
            string name = cookie["id"];
            return int.Parse(name);
        }

        public string GetAuthFromCookie(HttpContext context)
        {
            HttpCookie cookie = context.Request.Cookies["UserInfo"];
            string name = cookie["type"];
            return auth[int.Parse(name)];
        }

        public HttpCookie GenerateCookie(int type, int user_id)
        {
            HttpCookie cookie = new HttpCookie("UserInfo");//初使化并设置Cookie的名称
            cookie.HttpOnly = true;      //设置cookie只有服务器才能访问
            cookie.Values["id"] = user_id.ToString();       //设置cookie的值
            cookie.Values["type"] = type.ToString();
            return cookie;
        }

        public void test()
        {
            
        }
    }
}