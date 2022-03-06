using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Login_Role_MVC.Models;

namespace Login_Role_MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        [HttpGet]
        public ActionResult GetUserData()
        {
            DataAccessLayer dal = new DataAccessLayer();

            LoginVM model = new LoginVM();
            model.LoginLst = dal.Display();

            return View(model);
        }
        [HttpGet]
        public ActionResult AddNewUser()
        {
            AddUserVM model = new AddUserVM();
            model.RoleLst = GetRoleData();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddNewUser(AddUserVM model)
        {
            UserVM ur = new UserVM();
            ur.Id = model.Id;
            ur.Name = model.Name;
            ur.UserId = model.UserId;
            ur.Password = model.Password;
            ur.RoleId = model.RoleId;
            
            DataAccessLayer dal = new DataAccessLayer();
            model.RoleLst = GetRoleData();
            bool flag = dal.AddUser(ur);

            if(flag)
            {
                ViewBag.Msg = "Details Added Successfully";
            }
            else
            {
                ViewBag.Msg = "Error Occurred while adding";
            }
            
            return View(model);
        }
        public List<SelectListItem> GetRoleData()
        {
            DataAccessLayer dal = new DataAccessLayer();

            List<SelectListItem> Rlst = new List<SelectListItem>();

            List<RoleVM> lst = dal.GetRole();

            foreach(var r in lst)
            {
                Rlst.Add(new SelectListItem() { Text = r.RoleName, Value = r.RoleId.ToString() });
            }
            return Rlst;
        }
        [HttpGet]
        public ActionResult DeleteData(long id)
        {
            DataAccessLayer dal = new DataAccessLayer();
            dal.DeleteRow(id);
            return RedirectToAction("GetUserData");
        }
        [HttpGet]
        public ActionResult EditData(long id)
        {
            AddUserVM model = new AddUserVM();

            DataAccessLayer dal = new DataAccessLayer();
            UserVM obj = dal.ShowUserDetails(id);
            if (obj != null)
            {
                model.Id = obj.Id;
                model.Name = obj.Name;
                model.UserId = obj.UserId;
                model.Password = obj.Password;
                model.RoleId = obj.RoleId;

                model.RoleLst = GetRoleData();

                return View(model);
            }
            else
            {
                return RedirectToAction("GetUserData");
            }

        }
        [HttpPost]
        public ActionResult EditData(AddUserVM model)
        {
            DataAccessLayer dal = new DataAccessLayer();
            UserVM obj = new UserVM();
            obj.Id = model.Id;
            obj.Name = model.Name;
            obj.UserId = model.UserId;
            obj.Password = model.Password;
            obj.RoleId = model.RoleId;
            dal.UpdateUser(obj);
            return RedirectToAction("GetUserData");
        }
    }
}