using ScoreSystem.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Web;

namespace ScoreSystem.Services.AdminManage
{
    public class UserInfo
    {
        private static sorce_systemEntities db = new sorce_systemEntities();

        private static string[] auth = { "root", "area", "group", "all" };

        // 密码加密
        public static string cypher(string ps)
        {
            return ps;
        }

        // login
        public static bool CheckPassword(int type, string userNumber, string password)
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

        public static int GetUserId(string userNumber, int type)
        {
            switch (type)
            {
                case 0:
                    var result = db.root_admin.AsEnumerable().Where(p => p.user_number.Equals(userNumber));
                    return result.ToArray()[0].id_root_admin;
                case 1:
                    var result1 = db.area_admin.AsEnumerable().Where(p => p.user_number.Equals(userNumber));
                    return result1.ToArray()[0].id_area_admin;
                case 2:
                    var result2 = db.group_admin.AsEnumerable().Where(p => p.user_number.Equals(userNumber));
                    return result2.ToArray()[0].id_group_admin;
                default:
                    return 0;
            }
        }

        public static int GetUserIdFromCookie(HttpContext context)
        {
            /*HttpCookie cookie = context.Request.Cookies["UserInfo"];
            string name = cookie["id"];
            return int.Parse(name);*/
            string s = context.Request.Headers.Get("user_id");
            return int.Parse(s);
        }

        public static string GetAuthFromCookie(HttpContext context)
        {
            //HttpCookie cookie = context.Request.Cookies["UserInfo"];
            //string name = cookie["type"];
            string name = context.Request.Headers.Get("X-Token");
            return auth[int.Parse(name)];
        }

        public static HttpCookie GenerateCookie2(int type, int user_id)
        {
            HttpCookie cookie = new HttpCookie("UserInfo");//初使化并设置Cookie的名称
            cookie.HttpOnly = true;      //设置cookie只有服务器才能访问
            cookie.Values["id"] = user_id.ToString();       //设置cookie的值
            cookie.Values["type"] = type.ToString(); 
            return cookie;
        }

        public static Hashtable GenerateCookie(int type, int user_id)
        {
            Hashtable cookie = new Hashtable();//初使化并设置Cookie的名称
            /* cookie.HttpOnly = true;      //设置cookie只有服务器才能访问
            cookie.Values["id"] = user_id.ToString();       //设置cookie的值
            cookie.Values["type"] = type.ToString(); */
            cookie.Add("token", "admin-token");
            cookie.Add("id", user_id);
            cookie.Add("type", type);
            return cookie;
        }

        public void test()
        {
            
        }
    }
}