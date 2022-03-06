using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Final_Case_Study;
using Final_Case_Study.Controllers;
using Final_Case_Study.Models;
using System.Web.Mvc;

namespace ClassLibrary1
{
    public class Class1
    {

        [Fact]
        public void DalMethod2()
        {
            DataAccessLayer dal = new DataAccessLayer();
            var lst = dal.ViewDept();
            Assert.Equal(1, lst[0].DeptId);
        }
        [Fact]
        public void DalMethod3()
        {
            DataAccessLayer dal = new DataAccessLayer();
            var lst = dal.DispalyEmployee();
            Assert.Equal(1, lst[0].Eid);
        }
        [Fact]
        public void DalMethod4()
        {
            DataAccessLayer dal = new DataAccessLayer();
            var lst = dal.GetDept();
            Assert.Equal(1, lst[0].DeptId);
        }
        [Fact]
        public void DalMethod5()
        {
            DataAccessLayer dal = new DataAccessLayer();
            var lst = dal.GetEmp();
            Assert.Equal(1, lst[0].Eid);
        }
        [Fact]
        public void DalMethod6()
        {
            DataAccessLayer dal = new DataAccessLayer();
            LoginVM obj = new LoginVM();
            obj.UserName = "Lasya";
            obj.Password = "123";
            bool check = dal.CheckLogin(obj);
            Assert.True(check);
        }
        [Fact]
        public void DalMethod7()
        {
            DataAccessLayer dal = new DataAccessLayer();
            DepartmentVM d = new DepartmentVM();
            dal.DeleteDept(d.DeptId);
            Assert.Null(d.DeptName);
        }
        [Fact]
        public void DalMethod8()
        {
            DataAccessLayer dal = new DataAccessLayer();
            EmployeeVM a = new EmployeeVM();
            a.Ename = "Ami";
            a.Egrade = "A";
            a.Deptid = 1;
            a.Esal = 12000;
            a.Mname = "Lasya";
            bool check = dal.AddEmp(a);
            Assert.True(check);
        }
        [Fact]
        public void DalMethod9()
        {
            DataAccessLayer dal = new DataAccessLayer();
            EmployeeVM a = new EmployeeVM();
            EmployeeVM obj = dal.ShowEmp(a.Eid);
            Assert.NotNull(obj);
        }
        [Fact]
        public void DalMethod10()
        {
            DataAccessLayer dal = new DataAccessLayer();
            EmployeeVM a = new EmployeeVM();
            a.Eid = 5;
            a.Ename = "Ami";
            a.Egrade = "A";
            a.Deptid = 1;
            a.Esal = 12000;
            a.Mname = "Lasya";
            bool check = dal.UpdateEmp(a);
            Assert.True(check);
        }
        [Fact]
        public void DalMethod11()
        {
            DataAccessLayer dal = new DataAccessLayer();
            EmployeeVM e = new EmployeeVM();
            dal.DeleteEmp(e.Eid);
            Assert.Null(e.Ename);
        }
        [Fact]
        public void DalMethod12()
        {
            DataAccessLayer dal = new DataAccessLayer();
            var lst = dal.DisplayBon();
            Assert.Equal(1, lst[0].Bonid);
        }
        [Fact]
        public void DalMethod13()
        {
            DataAccessLayer dal = new DataAccessLayer();
            AddBonusVM b1 = new AddBonusVM();
            BonusVM b2 = new BonusVM();
            var lst = dal.GetBonData(b1);
            Assert.NotNull(lst);
        }
        [Fact]
        public void DalMethod14()
        {
            DataAccessLayer dal = new DataAccessLayer();
            BonusVM e = new BonusVM();
            dal.DeleteBon(e.Bonid);
            Assert.Equal(0,e.Bonamt);
        }
        [Fact]
        public  void DalMethod15()
        {
            DataAccessLayer dal = new DataAccessLayer();
            BonusVM b = new BonusVM();
            var lst = dal.EditBon(b.Bonid);
            Assert.NotNull(lst);
        }
        [Fact]
        public void DalMethod16()
        {
            DataAccessLayer dal = new DataAccessLayer();
            EmpHisVM e = new EmpHisVM();
            dal.DeleteHis(e.Emphid);
            Assert.Equal(0, e.Emphid);
        }
        [Fact]
        public void DalMethod17()
        {
            DataAccessLayer dal = new DataAccessLayer();
            EmpHisVM b = new EmpHisVM();
            var lst = dal.EditHis(b.Emphid);
            Assert.NotNull(lst);
        }
        [Fact]
        public void DalMethod18()
        {
            DataAccessLayer dal = new DataAccessLayer();
            BonusVM b = new BonusVM();
            b.BonDate = Convert.ToDateTime("10/1/2020");
            b.Bonamt = 10000;
            b.Eid = 1;
            bool check = dal.AddBonus(b);
            Assert.True(check);
        }
        [Fact]
        public void DalMethod19()
        {
            DataAccessLayer dal = new DataAccessLayer();
            BonusVM b = new BonusVM();
            b.Bonid = 2;
            b.BonDate = Convert.ToDateTime("10/1/2020");
            b.Bonamt = 12000;
            b.Eid = 1;
            bool check = dal.UpdateBon(b);
            Assert.True(check);
        }
        [Fact]
        public void DalMethod20()
        {
            DataAccessLayer dal = new DataAccessLayer();
            AddEmpHisVM a = new AddEmpHisVM();
            var lst = dal.GetHisData(a);
            Assert.NotNull(lst);
        }
        [Fact]
        public void DalMethod21()
        {
            DataAccessLayer dal = new DataAccessLayer();
            EmpHisVM a = new EmpHisVM();
            a.SDate= Convert.ToDateTime("1/1/2020");
            a.TDate = Convert.ToDateTime("12/1/2021");
            a.Cname = "TCS";
            a.Eid = 2;
            bool check = dal.AddHis(a);
            Assert.True(check);
        }
        [Fact]
        public void DalMethod22()
        {
            DataAccessLayer dal = new DataAccessLayer();
            EmpHisVM a = new EmpHisVM();
            a.Emphid = 2;
            a.SDate = Convert.ToDateTime("1/1/2020");
            a.TDate = Convert.ToDateTime("12/1/2021");
            a.Cname = "IBM";
            a.Eid = 2;
            bool check = dal.UpdateHis(a);
            Assert.True(check);
        }
        [Fact]
        public void ConMethod1()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.Login();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod2()
        {
            HRDeptController h = new HRDeptController();
            LoginVM lobj = new LoginVM();
            ActionResult ar = h.Login(lobj);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod3()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.Dashboard();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod4()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.DisplayDept();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod5()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.AddDept();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod6()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.DeleteDept();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod7()
        {
            HRDeptController h = new HRDeptController();
            DepartmentVM d = new DepartmentVM();
            ActionResult ar = h.Demo(d.DeptId);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod8()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.DisplayEmp();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod9()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.AddEmp();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod10()
        {
            HRDeptController h = new HRDeptController();
            AddEmpVM a = new AddEmpVM();
            ActionResult ar = h.AddEmp(a);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod11()
        {
            HRDeptController h = new HRDeptController();
            var ar = h.GetDepts();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod12()
        {
            HRDeptController h = new HRDeptController();
            var ar = h.GetEmps();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod13()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.EditEmp();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod14()
        {
            HRDeptController h = new HRDeptController();
            EmployeeVM a = new EmployeeVM();
            ActionResult ar = h.ViewEmp(a.Eid);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod15()
        {
            HRDeptController h = new HRDeptController();
            AddEmpVM a = new AddEmpVM();
            ActionResult ar = h.ViewEmp(a);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod16()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.DeleteEmp();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod17()
        {
            HRDeptController h = new HRDeptController();
            AddEmpVM a = new AddEmpVM();
            ActionResult ar = h.DeleteEmp2(a.Eid);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod18()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.DisplayBonus();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod19()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.AddBonus();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod20()
        {
            HRDeptController h = new HRDeptController();
            AddBonusVM a = new AddBonusVM();
            ActionResult ar = h.AddBonus(a);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod21()
        {
            HRDeptController h = new HRDeptController();
            AddBonusVM a = new AddBonusVM();
            ActionResult ar = h.DeleteBon(a.Bonid);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod22()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.ViewEmpBonus();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod23()
        {
            HRDeptController h = new HRDeptController();
            AddBonusVM a = new AddBonusVM();
            ActionResult ar = h.ViewEmpBonus2(a);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod24()
        {
            HRDeptController h = new HRDeptController();
            BonusVM b = new BonusVM();
            ActionResult ar = h.EditBon(b.Bonid);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod25()
        {
            HRDeptController h = new HRDeptController();
            AddBonusVM b = new AddBonusVM();
            ActionResult ar = h.EditBon(b);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod26()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.ViewEmpHis();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod27()
        {
            HRDeptController h = new HRDeptController();
            AddEmpHisVM a = new AddEmpHisVM();
            ActionResult ar = h.ViewEmpHis2(a);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod28()
        {
            HRDeptController h = new HRDeptController();
            EmployeeVM a = new EmployeeVM();
            ActionResult ar = h.DeleteHis(a.Eid);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod29()
        {
            HRDeptController h = new HRDeptController();
            EmployeeVM a = new EmployeeVM();
            ActionResult ar = h.EditHis(a.Eid);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod30()
        {
            HRDeptController h = new HRDeptController();
            AddEmpHisVM a = new AddEmpHisVM();
            ActionResult ar = h.EditHis(a);
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod31()
        {
            HRDeptController h = new HRDeptController();
            ActionResult ar = h.AddHis();
            Assert.NotNull(ar);
        }
        [Fact]
        public void ConMethod32()
        {
            HRDeptController h = new HRDeptController();
            AddEmpHisVM a = new AddEmpHisVM();
            ActionResult ar = h.AddHis(a);
            Assert.NotNull(ar);
        }
    }
}
