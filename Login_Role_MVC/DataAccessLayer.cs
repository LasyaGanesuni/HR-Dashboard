using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Login_Role_MVC.Models;

namespace Login_Role_MVC
{
    public class DataAccessLayer
    {
        LasyaEntities EDMObj = new LasyaEntities();
        public bool UpdateUser(UserVM obj)
        {
            bool success = false;
            try
            {
                LoginInfo li = (from o in EDMObj.LoginInfoes
                               where o.Id==obj.Id
                               select o).FirstOrDefault();
                if (li!=null)
                {
                    //li.Id = obj.Id;
                    li.Name = obj.Name;
                    li.UserId = obj.UserId;
                    li.Password = obj.Password;
                    li.RoleId = obj.RoleId;
                    
                    EDMObj.SaveChanges();
                    success = true;
                }
            }
            catch
            {

            }
            return success;
        }
            public UserVM ShowUserDetails(long id)
        {
            UserVM obj = null;
            var res = (from o in EDMObj.LoginInfoes
                       where o.Id == id
                       select o).FirstOrDefault();
            if(res!=null)
            {
                obj = new UserVM();
                obj.Id = res.Id;
                obj.Name = res.Name;
                obj.UserId = res.UserId;
                obj.Password = res.Password;
                obj.RoleId = res.RoleId;
            }
            return obj;
        }
        public void DeleteRow(long id)
        {
            var res = (from o in EDMObj.LoginInfoes
                       where o.Id == id
                       select o).FirstOrDefault();
            if(res!=null)
            {
                EDMObj.LoginInfoes.Remove(res);
                EDMObj.SaveChanges();
            }
        }
        public bool AddUser(UserVM obj)
        {
            bool success = false;
            try
            {
                LoginInfo li = new LoginInfo();
                //li.Id = obj.Id;
                li.Name = obj.Name;
                li.UserId = obj.UserId;
                li.Password = obj.Password;
                li.RoleId = obj.RoleId;
                EDMObj.LoginInfoes.Add(li);
                EDMObj.SaveChanges();
                success = true;
            }
            catch
            {

            }
            return success;
        }
        public List<UserVM> Display()
        {
            /*var res = (from o1 in EDMObj.LoginInfoes
                       select new UserVM
                       {
                           Id = o1.Id,
                           Name = o1.Name,
                           UserId = o1.UserId,
                           Password = o1.Password,
                           RoleId = o1.RoleId
                       }).ToList();*/
            var res = (from o1 in EDMObj.LoginInfoes
                       join o2 in EDMObj.RoleInfoes on o1.RoleId equals o2.RoleId
                       select new UserVM
                       {
                           Id = o1.Id,
                           Name = o1.Name,
                           UserId = o1.UserId,
                           Password = o1.Password,
                           RoleName = o2.RoleName
                       }).ToList();
            return res;
        }
        public List<RoleVM> GetRole()
        {
            var res = (from o in EDMObj.RoleInfoes
                       select new RoleVM
                       {
                           RoleId=o.RoleId,
                           RoleName=o.RoleName
                       }).ToList();
            return res;
        }
    }
}