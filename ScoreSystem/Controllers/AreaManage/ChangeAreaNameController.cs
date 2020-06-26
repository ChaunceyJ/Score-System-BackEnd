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
    public class ChangeAreaNameController : ApiController
    {

        // POST api/<controller>
        public Hashtable Post([FromBody] int id_area, [FromBody] string area_name)
        {
            Hashtable ht = new Hashtable();
            AreaInfo ai = new AreaInfo();
            if (ai.HasAreaName(area_name))
            {
                ht.Add("state", false);
                ht.Add("reason", "部门名字已存在");
            }
            else
            {
                try
                {
                    ht.Add("state", ai.ChangeAreaName(id_area, area_name));
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