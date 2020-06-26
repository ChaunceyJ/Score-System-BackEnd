using ScoreSystem.Services.WorkerManage;
using System;
using System.Collections;
using System.Web.Http;

namespace ScoreSystem.Controllers.WorkerManage
{
    public class ChangePersonInfoController : ApiController
    {

        // POST api/<controller>
        public Hashtable Post([FromBody] int id_crim, [FromBody] int group, [FromBody] string name, [FromBody] DateTime birthday, [FromBody] int work)
        {
            Hashtable ht = new Hashtable();
            PersonInfo ai = new PersonInfo();
            try
            {
                ht.Add("state", ai.ChangeInfo(id_crim, group, name, birthday, work));
            }
            catch (Exception e)
            {
                ht.Add("state", false);
                ht.Add("reason", e.Message);
            }
            return ht;
        }

    }
}