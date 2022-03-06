using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Final_Case_Study.Models;

namespace Final_Case_Study.Controllers
{
    [Authorize]
    public class HRDeptController : Controller
    {
        [AllowAnonymous]
        // GET: HRDept
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginVM model)
        {
            LoginVM obj = new LoginVM();
            obj.UserName = model.UserName;
            obj.Password = model.Password;
            DataAccessLayer dal = new DataAccessLayer();
            bool flag = dal.CheckLogin(obj);
            if(flag)
            {
                FormsAuthentication.SetAuthCookie(obj.UserName, false);
                return RedirectToAction("Dashboard");
            }
            else
            {
                ViewBag.ErrMsg = "Invalid Login Details";
            }
            return View();
        }
        [HttpGet]
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayDept()
        {
            DataAccessLayer dal = new DataAccessLayer();
            DeptLVM model = new DeptLVM();
            model.Dlst = dal.ViewDept();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddDept()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDept(DepartmentVM model)
        {
            DepartmentVM obj = new DepartmentVM();
            obj.DeptId = model.DeptId;
            obj.DeptName = model.DeptName;

            DataAccessLayer dal = new DataAccessLayer();
            bool flag = dal.AddDept(model);
            if(flag)
            {
                ViewBag.Msg = "Department Added Successfully!";
            }
            else
            {
                ViewBag.ErrMsg = "Error occurred while adding Department!";
            }
            return View();
        }
        [HttpGet]
        public ActionResult DeleteDept()
        {
            DataAccessLayer dal = new DataAccessLayer();
            DeptLVM model = new DeptLVM();
            model.Dlst = dal.ViewDept();
            return View(model);
        }
        public ActionResult Demo(long Deptid)
        {
            DataAccessLayer dal = new DataAccessLayer();
            dal.DeleteDept(Deptid);
            return RedirectToAction("DisplayDept");
        }
        [HttpGet]
        public ActionResult DisplayEmp()
        {
            DataAccessLayer dal = new DataAccessLayer();
            EmpLVM model = new EmpLVM();
            model.Elst = dal.DispalyEmployee();
            return View(model);
        }
        [HttpGet]
        public ActionResult AddEmp()
        {
            AddEmpVM model = new AddEmpVM();
            model.DLst = GetDepts();
            return View(model);
        }
        [HttpPost]
        public ActionResult AddEmp(AddEmpVM model)
        {
            EmployeeVM e = new EmployeeVM();
            e.Eid = model.Eid;
            e.Ename = model.Ename;
            e.Egrade = model.Egrade;
            e.Esal = model.Esal;
            e.Deptid = model.Deptid;
            e.Mname = model.Mname;

            DataAccessLayer dal = new DataAccessLayer();
            model.DLst = GetDepts();
            bool flag=dal.AddEmp(e);
            
            if(flag)
            {
                ViewBag.Msg = "Record added successfully!";
            }
            else
            {
                ViewBag.ErrMsg = "Error occured while adding record";
            }
            return View(model);
        }
        public List<SelectListItem> GetDepts()
        {
            DataAccessLayer dal = new DataAccessLayer();

            List<SelectListItem> Dlst = new List<SelectListItem>();

            List<DepartmentVM> lst = dal.GetDept();

            foreach (var r in lst)
            {
                Dlst.Add(new SelectListItem() { Text = r.DeptName, Value = r.DeptId.ToString() });
            }
            return Dlst;
        }
        public List<SelectListItem> GetEmps()
        {
            DataAccessLayer dal = new DataAccessLayer();

            List<SelectListItem> Bonlst = new List<SelectListItem>();

            List<EmployeeVM> lst = dal.GetEmp();

            foreach (var r in lst)
            {
                Bonlst.Add(new SelectListItem() { Text = r.Ename, Value = r.Eid.ToString() });
            }
            return Bonlst;
        }
        public ActionResult EditEmp()
        {
            DataAccessLayer dal = new DataAccessLayer();
            EmpLVM model = new EmpLVM();
            model.Elst = dal.DispalyEmployee();
            return View(model);
        }
        public ActionResult ViewEmp(long Empid)
        {
            AddEmpVM model = new AddEmpVM();

            DataAccessLayer dal = new DataAccessLayer();
            EmployeeVM obj = dal.ShowEmp(Empid);
            if (obj != null)
            {
                model.Eid = obj.Eid;
                model.Ename = obj.Ename;
                model.Egrade = obj.Egrade;
                model.Esal = obj.Esal;
                model.Deptid = obj.Deptid;
                model.Mname = obj.Mname;

                model.DLst = GetDepts();

                return View(model);
            }
            else
            {
                return RedirectToAction("EditEmp");
            }
            
        }
       [HttpPost]
        public ActionResult ViewEmp(AddEmpVM model)
        {
            EmployeeVM e = new EmployeeVM();
            
            e.Eid=model.Eid;
            e.Ename = model.Ename;
            e.Egrade = model.Egrade;
            e.Esal = model.Esal;
            e.Deptid = model.Deptid;
            e.Mname = model.Mname;
            DataAccessLayer dal = new DataAccessLayer();
            model.DLst = GetDepts();
            bool flag = dal.UpdateEmp(e);
            if (flag)
            {
                ViewBag.Msg = "Record Updated successfully!";
            }
            else
            {
                ViewBag.ErrMsg = "Error occured while updating record!";
            }
            return View(model);
        }
        [HttpGet]
        public ActionResult DeleteEmp()
        {
            DataAccessLayer dal = new DataAccessLayer();
            EmpLVM model = new EmpLVM();
            model.Elst = dal.DispalyEmployee();
            return View(model);
        }
        public ActionResult DeleteEmp2(long Empid)
        {
            DataAccessLayer dal = new DataAccessLayer();
            dal.DeleteEmp(Empid);
            return RedirectToAction("DisplayEmp");
        }
        public ActionResult DisplayBonus()
        {
            DataAccessLayer dal = new DataAccessLayer();
            BonLVM model = new BonLVM();
            model.Blst = dal.DisplayBon();
            return View(model);
        }
        public ActionResult AddBonus()
        {
            AddBonusVM model = new AddBonusVM();
            model.BSLst = GetEmps();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddBonus(AddBonusVM model)
        {
            BonusVM b = new BonusVM();
            b.Bonid = model.Bonid;
            b.BonDate = model.BonDate;
            b.Bonamt = model.Bonamt;
            b.Eid = model.Eid;

            DataAccessLayer dal = new DataAccessLayer();
            model.BSLst = GetEmps();
            bool flag = dal.AddBonus(b);

            if (flag)
            {
                ViewBag.Msg = "Record added successfully!";
            }
            else
            {
                ViewBag.ErrMsg = "Error occured while adding record";
            }
            return View(model);
        }
        public ActionResult DeleteBon(long Bonid)
        {
            DataAccessLayer dal = new DataAccessLayer();
            bool flag = dal.DeleteBon(Bonid);
            if(flag)
            {
                ViewBag.Msg = "Record Deleted Successfully!";
            }
            else
            {
                ViewBag.ErrMsg = "Error in deleting Record!";
            }
            return RedirectToAction("ViewEmpBonus");
        }
        public ActionResult ViewEmpBonus()
        {
            AddBonusVM model = new AddBonusVM();
            model.BSLst = GetEmps();
            return View(model);
        }
        [HttpPost]
        public ActionResult ViewEmpBonus2(AddBonusVM model)
        {
            DataAccessLayer dal = new DataAccessLayer();

            model.B2lst = dal.GetBonData(model);
            return View(model);
        }
        public ActionResult EditBon(long Bonid)
        {
            AddBonusVM model = new AddBonusVM();

            DataAccessLayer dal = new DataAccessLayer();
            BonusVM obj = dal.EditBon(Bonid);
            if(obj!=null)
            {
                model.Bonid = obj.Bonid;
                model.BonDate = obj.BonDate;
                model.Bonamt = obj.Bonamt;
                model.Eid = obj.Eid;

                model.BSLst = GetEmps();
                return View(model);
            }
            else
            {
                return RedirectToAction("ViewEmpBonus");
            }
        }
        [HttpPost]
        public ActionResult EditBon(AddBonusVM model)
        {
            BonusVM b = new BonusVM();

            b.Bonid = model.Bonid;
            b.BonDate = model.BonDate;
            b.Bonamt = model.Bonamt;
            b.Eid = model.Eid;

            DataAccessLayer dal = new DataAccessLayer();
            model.BSLst = GetEmps();
            bool flag = dal.UpdateBon(b);
            if (flag)
            {
                ViewBag.Msg = "Record Updated successfully!";
            }
            else
            {
                ViewBag.ErrMsg = "Error occured while updating record!";
            }
            return View(model);
        }
        public ActionResult ViewEmpHis()
        {
            AddEmpHisVM model = new AddEmpHisVM();
            model.ESLst = GetEmps();
            return View(model);
        }
        [HttpPost]
        public ActionResult ViewEmpHis2(AddEmpHisVM model)
        {
            DataAccessLayer dal = new DataAccessLayer();

            model.E2lst = dal.GetHisData(model);
            return View(model);
        }
        public ActionResult DeleteHis(long Emphid)
        {
            DataAccessLayer dal = new DataAccessLayer();
            bool flag = dal.DeleteHis(Emphid);
            if (flag)
            {
                ViewBag.Msg = "Record Deleted Successfully!";
            }
            else
            {
                ViewBag.ErrMsg = "Error in deleting Record!";
            }
            return RedirectToAction("ViewEmpHis");
        }
        public ActionResult EditHis(long Emphid)
        {
            AddEmpHisVM model = new AddEmpHisVM();

            DataAccessLayer dal = new DataAccessLayer();
            EmpHisVM obj = dal.EditHis(Emphid);
            if (obj != null)
            {
                model.Emphid = obj.Emphid;
                model.SDate = obj.SDate;
                model.TDate = obj.TDate;
                model.Cname = obj.Cname;
                model.Eid = obj.Eid;

                model.ESLst = GetEmps();
                return View(model);
            }
            else
            {
                return RedirectToAction("ViewEmpBonus");
            }
        }
        
        [HttpPost]
        public ActionResult EditHis(AddEmpHisVM model)
        {
            EmpHisVM b = new EmpHisVM();

            b.Emphid = model.Emphid;
            b.SDate = model.SDate;
            b.TDate = model.TDate;
            b.Cname = model.Cname;
            b.Eid = model.Eid;

            DataAccessLayer dal = new DataAccessLayer();
            model.ESLst = GetEmps();
            bool flag = dal.UpdateHis(b);
            if (flag)
            {
                ViewBag.Msg = "Record Updated successfully!";
            }
            else
            {
                ViewBag.ErrMsg = "Error occured while updating record!";
            }
            return View(model);
        }
        public ActionResult AddHis()
        {
            AddEmpHisVM model = new AddEmpHisVM();
            model.ESLst = GetEmps();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddHis(AddEmpHisVM model)
        {
            EmpHisVM b = new EmpHisVM();
            b.Emphid = model.Emphid;
            b.SDate = model.SDate;
            b.TDate = model.TDate;
            b.Eid = model.Eid;
            b.Cname = model.Cname;

            DataAccessLayer dal = new DataAccessLayer();
            model.ESLst = GetEmps();
            bool flag = dal.AddHis(b);

            if (flag)
            {
                ViewBag.Msg = "Record added successfully!";
            }
            else
            {
                ViewBag.ErrMsg = "Error occured while adding record";
            }
            return View(model);
        }
        public ActionResult Query2()
        {
            DataAccessLayer dal = new DataAccessLayer();
            Query2LVM model = new Query2LVM();
            model.q2lst = dal.Query2();
            return View(model);
        }
        public ActionResult Query3_A()
        {
            AddEmpVM model = new AddEmpVM();
            model.DLst = GetDepts();
            return View(model);
        }
        [HttpPost]
        public ActionResult Query3_B(AddEmpVM model)
        {
            DataAccessLayer dal = new DataAccessLayer();

            model.AElst = dal.Query_3(model);
            return View(model);
        }
        public ActionResult Query4_A()
        {
            AddEmpVM model = new AddEmpVM();
            model.DLst = GetDepts();
            return View(model);
        }
        [HttpPost]
        public ActionResult Query4_B(AddEmpVM model)
        {
            DataAccessLayer dal = new DataAccessLayer();

            model.AElst = dal.Query_4(model);
            return View(model);
        }
    }
}