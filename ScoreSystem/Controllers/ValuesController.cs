using ScoreSystem.Services.AdminManage;
using ScoreSystem.Services.AreaManage;
using ScoreSystem.Services.WorkerManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Results;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ScoreSystem.Controllers
{
    // [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ValuesController : ApiController
    {

        // GET api/values
        public IEnumerable<string> Get([FromUri] string name, [FromUri] int page)
        {

            // HttpContext.Current.Response.AppendCookie(UserInfo.GenerateCookie(0, 0));
            return new string[] { "value1", "value2", name, page.ToString() };
        }

        // GET api/values/5
        public Hashtable Get(int id)
        {
            Hashtable ht = new Hashtable();
            ht.Add("111", UserInfo.GetAuthFromCookie(HttpContext.Current));
            return ht;
        }

        // POST api/values
  /*      public Hashtable Post( string area_name,string name,  string password, string user_number) { 
        
            Hashtable ht = new Hashtable();
            ht.Add("111", "111");
            return ht;
        }*/

        public Hashtable Post( string area_name,string name,  string password, string user_number) 
         {
             int admin = UserInfo.GetUserIdFromCookie(HttpContext.Current);
             Hashtable ht = new Hashtable();
             Hashtable data = new Hashtable();
             AreaInfo ai = new AreaInfo();
             if (ai.HasAreaName(area_name))
             {
                 ht.Add("code", 40000);
                 data.Add("message", "部门已存在");
             }
             else if (new AdminInfo().HasAreaUserName(name))
             {
                 ht.Add("code", 40000);
                 data.Add("message", "管理员已存在");
             }
             else
             {
                 try
                 {
                     if (ai.AddOne(area_name, name, UserInfo.cypher(password), user_number, admin))
                     {
                         ht.Add("code", 20000);
                         data.Add("id", ai.GetId(area_name));
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

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

    }
}
