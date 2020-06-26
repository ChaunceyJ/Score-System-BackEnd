using ScoreSystem.Services.AdminManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace ScoreSystem.Controllers.AdminManage
{
    public class InfoController : ApiController
    {
        //[EnableCors(origins: "*", headers: "*", methods: "*")]

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public Hashtable Get([FromUri] int token)
        {
            Hashtable ht = new Hashtable();
            Hashtable data = new Hashtable();
            // HttpContext.Current.Response.AppendCookie(UserInfo.GenerateCookie2(0, 0));
            data.Add("avatar", "https://wpimg.wallstcn.com/f778738c-e4f8-4870-b634-56703b4acafe.gif");
            List<string> role = new List<string>();
            switch (token)
            {
                case 0:
                    data.Add("name", "超级管理员");
                    role.Clear();
                    role.Add("admin"); //
                    data.Add("role", role);
                    data.Add("introduction", "超级管理员");
                    break;
                case 1:
                    data.Add("name", "车间管理员");
                    role.Clear();
                    role.Add("admin"); //
                    data.Add("role", role);
                    data.Add("introduction", "车间管理员");
                    break;
                case 2:
                    data.Add("name", "小组管理员");
                    role.Clear();
                    role.Add("admin"); //
                    data.Add("role", role);
                    data.Add("introduction", "小组管理员");
                    break;
            }
            ht.Add("code", 20000);
            ht.Add("data", data);
            return ht;
        }

        // POST api/<controller>
        public string Post([FromBody] string value)
        {
            return value;
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}