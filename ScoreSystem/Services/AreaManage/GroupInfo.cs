using ScoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreSystem.Services.AreaManage
{
    public class GroupInfo
    {
        private sorce_systemEntities db = new sorce_systemEntities();

        public bool AddOne(int _groupID, string _name, string _password, string _user_number, int _admin)
        {
            int num;
            try
            {
                db.group_admin.Add(new group_admin
                {
                    group_id_in_area = _groupID,
                    name = _name,
                    password = _password,
                    user_number = _user_number,
                    id_area_admin = _admin
                });
                num = db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return num > 0;
        }

        public int GetId(int gi)
        {
            return db.group_admin.Where(p => p.group_id_in_area == gi).ToArray()[0].id_group_admin;
        }

        public bool HasGroup(int id_in_area, int area_id)
        {
            var result = db.group_admin.AsEnumerable()
                .Where(p => p.group_id_in_area == id_in_area && p.id_area_admin == area_id);
            return result.ToArray().Length > 0;

        }

        public group_admin GetAdmin(int id)
        {
            return db.group_admin.Find(id);
        }

        public int GetGroupName(int gi)
        {
            return (int)db.group_admin.Find(gi).group_id_in_area;
        }

        public bool ChangeGroupid(int id_group, int groupid_in_area)
        {
            bool num;
            try
            {
                group_admin cr = db.group_admin.Find(id_group);
                if (cr != null)
                {
                    cr.group_id_in_area = groupid_in_area;
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
                group_admin wk = db.group_admin.Find(id);
                db.group_admin.Remove(wk);
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
            var result = db.criminals.AsEnumerable().Where(p => p.id_group == id);
            return result.ToArray().Length > 0;

        }

        public Array GetGroupInfo(int skip, int limit, int admin)
        {
            var pageData = db.group_admin.Where(p => p.id_area_admin == admin)
                .OrderBy(b => b.id_group_admin)
                .Skip(skip)
                .Take(limit);
            return pageData.ToArray();
        }
    }
}