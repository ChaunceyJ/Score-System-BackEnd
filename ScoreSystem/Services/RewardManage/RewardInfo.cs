using ScoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Web;

namespace ScoreSystem.Services.RewardManage
{
    public class RewardInfo
    {
        private sorce_systemEntities db = new sorce_systemEntities();

        public exam_record AddOne(int _id_crimal, int _rule, DateTime dateTime, int _group, int _score)
        {
            exam_record ner = new exam_record
            {
                id_crimial = _id_crimal,
                id_rule = _rule,
                exam_date = dateTime,
                group_check_id = _group,
                score = _score
            };
            try
            {
                db.exam_record.Add(ner);
                 db.SaveChanges();
               
            }
            catch (Exception e)
            {
                throw e;
            }
            return ner;
        }

        public exam_record GetExamRecord(int id)
        {
            return db.exam_record.Find(id);
        }

        public bool ChangeContext(int id_exam, int _rule, DateTime dateTime, int _group, int _score, string _kind, string _detail)
        {
            bool num;
            try
            {
                exam_record cr = db.exam_record.Find(id_exam);
                if (cr != null)
                {
                    if(_rule != cr.id_rule)
                    {
                        cr.id_rule = _rule;
                    }
                    if(dateTime != null && !dateTime.Equals(cr.exam_date))
                    {
                        cr.exam_date = dateTime;
                    }
                    cr.group_check_id = _group;
                    if (_score != cr.score)
                    {
                        cr.score = _score;
                    }
                    if(_kind != null && !_kind.Equals(cr.kind))
                    {
                        cr.kind = _kind;
                    }
                    if(_detail != null && !_detail.Equals(cr.detail))
                    {
                        cr.detail = _detail;
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
            bool num;
            try
            {
                exam_record wk = db.exam_record.Find(id);
                db.exam_record.Remove(wk);
                 db.SaveChanges();
                num = true;
            }
            catch (Exception e)
            {
                throw e;
            }
            return num;
        }

        public bool AreaAdminCheck(int id_record, int are_admin)
        {
            bool num;
            try
            {
                exam_record cr = db.exam_record.Find(id_record);
                if (cr != null)
                {
                    cr.area_check_id = are_admin;
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

        public bool RootAdminCheck(int id_record, int rootAdmin)
        {
            bool num;
            try
            {
                exam_record cr = db.exam_record.Find(id_record);
                if (cr != null)
                {
                    cr.root_check_id = rootAdmin;
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

        public Array GetRewardInfo(int skip, int limit, int grouo_id, DateTime start, DateTime end)
        {
            var pageData = db.exam_record.Where(p => p.group_check_id == grouo_id && p.exam_date >= start && p.exam_date <= end)
                .OrderBy(b => b.exam_date)
                .Skip(skip)
                .Take(limit);
            return pageData.ToArray();
        }

        public Array GetRewardInfo(int skip, int limit, int grouo_id)
        {
            var pageData = db.exam_record.Where(p => p.group_check_id == grouo_id)
                .OrderBy(b => b.exam_date)
                .Skip(skip)
                .Take(limit);
            return pageData.ToArray();
        }

        public int GetSize(int grouo_id)
        {
            return db.exam_record.Where(p => p.group_check_id == grouo_id).Count();
        }
    }
}