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

        public bool AddOne(int _id_crimal, int _rule, DateTime dateTime, int _group, int _score, string _kind, string _detail)
        {
            int num;
            try
            {
                db.exam_record.Add(new exam_record
                {
                    id_crimial = _id_crimal,
                    id_rule = _rule,
                    exam_date = dateTime,
                    group_check_id = _group,
                    score = _score,
                    kind = _kind,
                    detail = _detail
                });
                num = db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return num > 0;
        }

        public bool ChangeContext(int id_exam, int _rule, DateTime dateTime, int _group, int _score, string _kind, string _detail)
        {
            int num;
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
                exam_record wk = db.exam_record.Find(id);
                db.exam_record.Remove(wk);
                num = db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return num > 0;
        }

        public bool AreaAdminCheck(int id_record, int are_admin)
        {
            int num;
            try
            {
                exam_record cr = db.exam_record.Find(id_record);
                if (cr != null)
                {
                    cr.area_check_id = are_admin;
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

        public bool RootAdminCheck(int id_record, int rootAdmin)
        {
            int num;
            try
            {
                exam_record cr = db.exam_record.Find(id_record);
                if (cr != null)
                {
                    cr.root_check_id = rootAdmin;
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