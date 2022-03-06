using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Login_Role_MVC;
using Login_Role_MVC.Controllers;
using Login_Role_MVC.Models;
using System.Web.Mvc;

namespace ClassLibrary2
{
    public class Class1
    {
        [Fact]
        public void TestDataAccess_Getinfo()
        {
            UserController ctrl = new UserController();
            ActionResult ar = ctrl.GetUserData();
            Assert.NotNull(ar);
        }
        [Fact]
        public void TestDBAccess_GetList()
        {
            DataAccessLayer dal = new DataAccessLayer();
            var Lst = dal.Display();
            Assert.Equal(1, Lst[0].Id);
        }
    }
}
