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

        public bool ChangeInfo(int id_crim, int _group, string _name, DateTime _birthday, int _work)
        {
            int num;
            try
            {
                criminal cr = db.criminals.Find(id_crim);
                if (cr != null)
                {
                    if(_group != 0 && _group != cr.id_group)
                    {
                        cr.id_group = _group;
                    }
                    if(_name != null && !_name.Equals(cr.name))
                    {
                        cr.name = _name;
                    }
                    if(_birthday != null && _birthday.Equals(cr.birthday))
                    {
                        cr.birthday = _birthday;
                    }
                    if(_work != 0 && _work != cr.id_work)
                    {
                        cr.id_work = _work;
                    }
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

        public bool DeleteOne(int id_crim)
        {
            int num;
            try
            {
                criminal wk = db.criminals.Find(id_crim);
                db.criminals.Remove(wk);
                num = db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return num > 0;
        }

        public bool HasUsed(int id_crim)
        {
            var result = db.exam_record.AsEnumerable().Where(p => p.id_crimial.Equals(id_crim));
            return result.ToArray().Length > 0;
        }

        public Array GetPersonInfo(int skip, int limit, int admin)
        {
            var pageData = db.criminals.Where(p => p.id_group == admin)
                .OrderBy(b => b.id_criminal)
                .Skip(skip)
                .Take(limit);
            return pageData.ToArray();
        }

        public string GetPersonName(int id)
        {
            return db.criminals.Find(id).name;
        }
    }
}