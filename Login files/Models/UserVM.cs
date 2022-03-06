using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Linq;
using System.Web;

namespace Login_Role_MVC.Models
{
    public class UserVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
        public string RoleName { get; set; }
    }
    public class LoginVM
    {
        public List<UserVM> LoginLst { get; set; } = new List<UserVM>();
    }

    public class AddUserVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
        public List<SelectListItem> RoleLst { get; set; } = new List<SelectListItem>();
    }
    public class RoleVM
    {
        public long RoleId { get; set; }
        public string RoleName { get; set; }
    }
}