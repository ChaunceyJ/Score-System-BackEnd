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
            var result = db.works.AsEnumerable().Where(p => p.id_work == id);
            return result.ToArray().Length > 0;

        }
    }
}