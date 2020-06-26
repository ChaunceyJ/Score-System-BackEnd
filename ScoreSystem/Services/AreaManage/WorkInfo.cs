using ScoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreSystem.Services.AreaManage
{
    // 工作种类管理
    public class WorkInfo
    {
        private sorce_systemEntities db = new sorce_systemEntities();

        public bool AddOne(string _context, int _grade)
        {
            int num;
            try
            {
                db.works.Add(new work { context = _context, grade = _grade });
                num = db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return num > 0;
        }

        public int GetId(string _area_name)
        {
            return db.works.Where(p => p.context.Equals(_area_name)).ToArray()[0].id_work;
        }

        public string GetContent(int id)
        {
            return db.works.Find(id).context;
        }

        public bool ChangeContent(int id, string s)
        {
            bool num;
            try
            {
                work cr = db.works.Find(id);
                if (cr != null)
                {
                    if (s != null && !s.Equals(cr.context))
                    {
                        cr.context = s;
                    }
                    db.SaveChanges();
                    num = true;
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
            return num;
        }

        public bool DeleteOne(int id)
        {
            int num;
            try
            {
                work wk = db.works.Find(id);
                db.works.Remove(wk);
                num = db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return num > 0;
        }

        public bool HasUsed(int id)
        {
            var result = db.criminals.AsEnumerable().Where(p => p.id_work == id);
            return result.ToArray().Length > 0;

        }

        public Array GetWorkInfo(int skip, int limit)
        {
            var pageData = db.works
                .OrderBy(b => b.id_work)
                .Skip(skip)
                .Take(limit);
            return pageData.ToArray();
        }
    }
}