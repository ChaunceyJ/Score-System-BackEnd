using ScoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreSystem.Services.AreaManage
{
    public class AreaInfo
    {
        private sorce_systemEntities db = new sorce_systemEntities();

        public bool AddOne(string _area_name, string _name, string _password, string _user_number, int _admin)
        {
            int num;
            try
            {
                db.area_admin.Add(new area_admin
                {
                    area_name = _area_name,
                    name = _name,
                    password = _password,
                    user_number = _user_number,
                    id_root_admin = _admin
                });
                num = db.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
            return num > 0;
        }

        public bool HasAreaName(string name)
        {
            var result = db.area_admin.AsEnumerable().Where(p => p.area_name.Equals(name));
            return result.ToArray().Length > 0;
        }

        public bool ChangeAreaName(int id_area, string _name)
        {
            int num;
            try
            {
                area_admin cr = db.area_admin.Find(id_area);
                if (cr != null)
                {
                    cr.area_name = _name;
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
                area_admin wk = db.area_admin.Find(id);
                db.area_admin.Remove(wk);
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
            var result = db.group_admin.AsEnumerable().Where(p => p.id_area_admin == id);
            return result.ToArray().Length > 0;

        }
    }
}