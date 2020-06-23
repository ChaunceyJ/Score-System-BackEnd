using ScoreSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreSystem.Services.AdminManage
{
    public class AdminInfo
    {
        private sorce_systemEntities db = new sorce_systemEntities();

        public bool ChangeAreaAdmin(int _areaid, string _name, string _password, string _user_number, int _admin)
        {
            int num;
            try
            {
                area_admin cr = db.area_admin.Find(_areaid);
                if (cr != null)
                {
                    if(_name != null && _name.Equals(cr.name))
                    {
                        cr.name = _name;
                    }
                    if(_password != null)
                    {
                        cr.password = _password;
                    }
                    if(_user_number != null && _user_number.Equals(cr.user_number))
                    {
                        cr.user_number = _user_number;
                    }
                    if(_admin != cr.id_root_admin)
                    {
                        cr.id_root_admin = _admin;
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

        public bool HasAreaUserName(string userNumber)
        {
            var result = db.area_admin.AsEnumerable().Where(p => p.user_number.Equals(userNumber));
            return result.ToArray().Length > 0;
        }

        public bool DeleteAreaUser(int areaID)
        {
            int num;
            try
            {
                area_admin cr = db.area_admin.Find(areaID);
                if (cr != null)
                {
                    cr.user_number = "None";
                    cr.name = "None";
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

        public bool ChangeGroupAdmin(int _groupid, string _name, string _password, string _user_number, int _areaAdmin)
        {
            int num;
            try
            {
                group_admin cr = db.group_admin.Find(_groupid);
                if (cr != null)
                {
                    if (_name != null && _name.Equals(cr.name))
                    {
                        cr.name = _name;
                    }
                    if (_password != null)
                    {
                        cr.password = _password;
                    }
                    if (_user_number != null && _user_number.Equals(cr.user_number))
                    {
                        cr.user_number = _user_number;
                    }
                    if (_areaAdmin != cr.id_area_admin)
                    {
                        cr.id_area_admin = _areaAdmin;
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

        public bool HasGroupUserName(string userNumber)
        {
            var result = db.group_admin.AsEnumerable().Where(p => p.user_number.Equals(userNumber));
            return result.ToArray().Length > 0;
        }

        public bool DeleteGroupUser(int areaID)
        {
            int num;
            try
            {
                group_admin cr = db.group_admin.Find(areaID);
                if (cr != null)
                {
                    cr.user_number = "None";
                    cr.name = "None";
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

        public bool ChangeRootAdmin(int _rootid, string _name, string _password, string _user_number)
        {
            int num;
            try
            {
                group_admin cr = db.group_admin.Find(_rootid);
                if (cr != null)
                {
                    if (_name != null && _name.Equals(cr.name))
                    {
                        cr.name = _name;
                    }
                    if (_password != null)
                    {
                        cr.password = _password;
                    }
                    if (_user_number != null && _user_number.Equals(cr.user_number))
                    {
                        cr.user_number = _user_number;
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
    }
}