
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
            bool num;
            try
            {
                db.rules.Add(new rule { article_id = _article_id, num_id = _num_id, context = _context });
               db.SaveChanges();
                num = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return num;
        }

        public bool HasName(int ar, int num)
        {
            var result = db.rules.AsEnumerable().Where(p => p.article_id == ar && p.num_id == num);
            return result.ToArray().Length > 0;

        }

        public int GetId(string _area_name)
        {
            return db.rules.Where(p => p.context.Equals(_area_name)).ToArray()[0].id_rule;
        }

        public string GetContent(int id)
        {
            return db.rules.Find(id).context;
        }

        public bool ChangeContext(int id, string context)
        {
            bool num;
            try
            {
                rule cr = db.rules.Find(id);
                if (cr != null)
                {
                    cr.context = context;
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
            bool num;
            try
            {
                rule wk = db.rules.Find(id);
                db.rules.Remove(wk);
                 db.SaveChanges();
                num = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return num;
        }

        public bool HasUsed(int id)
        {
            var result = db.exam_record.AsEnumerable().Where(p => p.id_rule == id);
            return result.ToArray().Length > 0;
        }

        public Array GetRuleInfo(int skip, int limit)
        {
            var pageData = db.rules
                .OrderBy(b => b.article_id).ThenBy(b => b.num_id)
                .Skip(skip)
                .Take(limit);
            return pageData.ToArray();
        }
    }
}
