using ScoreSystem.Services.AreaManage;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ScoreSystem.Controllers.AreaManage
{
    public class DeleteAreaController : ApiController
    {

        // GET api/<controller>/5
        public Hashtable Get(int id)
        {
            Hashtable ht = new Hashtable();
            Hashtable data = new Hashtable();
            AreaInfo ai = new AreaInfo();
            if (ai.HasUsed(id))
            {
                ht.Add("code", 40000);
                data.Add("message", "部门已被使用，无法删除");
            }
            else
            {
                try
                {
                    if (ai.DeleteOne(id))
                    {
                        ht.Add("code", 20000);
                        data.Add("status", "success");
                    }
                    else
                    {
                        ht.Add("code", 40000);
                        data.Add("message", "failed");
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

    }
}