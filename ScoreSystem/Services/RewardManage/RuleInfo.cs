using ScoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace ScoreSystem.Services.RewardManage
{
    public class RuleInfo
    {
        private sorce_systemEntities db = new sorce_systemEntities();

        public bool AddOne(int _article_id, int _num_id, string _context)
        {
            int num;
            try
            {
                db.rules.Add(new rule { article_id = _article_id, num_id = _num_id, context = _context });
                num = db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return num > 0;
        }

        public bool HasName(int ar, int num)
        {
            var result = db.rules.AsEnumerable().Where(p => p.article_id == ar && p.num_id == num);
            return result.ToArray().Length > 0;

        }

        public bool ChangeContext(int id, string context)
        {
            int num;
            try
            {
                rule cr = db.rules.Find(id);
                if (cr != null)
                {
                    cr.context = context;
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

        public bool DeleteOne(int id)
        {
            int num;
            try
            {
                rule wk = db.rules.Find(id);
                db.rules.Remove(wk);
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
            var result = db.exam_record.AsEnumerable().Where(p => p.id_rule == id);
            return result.ToArray().Length > 0;
        }
    }
}