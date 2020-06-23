using ScoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreSystem.Services.WorkerManage
{
    // 人员信息管理
    public class PersonInfo
    {
        private sorce_systemEntities db = new sorce_systemEntities();

        public bool AddOne(int _id, string _name, DateTime _birthday, int _group, int _work)
        {
            int num;
            try
            {
                db.criminals.Add(new criminal { id_criminal=_id, name=_name, birthday=_birthday, id_work=_work, id_group = _group }) ;
                num = db.SaveChanges();
            }
            catch(Exception e)
            {
                throw e;
            }
            return num > 0;
        }

        public bool ChangeGroup(int id_crim, int _group)
        {
            int num;
            try
            {
                criminal cr = db.criminals.Find(id_crim);
                if (cr != null)
                {
                    cr.id_group = _group;
                    num = db.SaveChanges();
                }
                else
                {
                    return false;
                }
            }catch(Exception e)
            {
                throw e;
            }
            return num > 0;
        }

        public bool ChangeWork(int id_crim, int _work)
        {
            int num;
            try
            {
                criminal cr = db.criminals.Find(id_crim);
                if (cr != null)
                {
                    cr.id_work = _work;
                    num = db.SaveChanges();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            return num > 0;
        }
    }
}