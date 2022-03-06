using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Final_Case_Study.Models;

namespace Final_Case_Study
{
    public class DataAccessLayer
    {
        HRdeptEntities EDMObj = new HRdeptEntities();
        public bool CheckLogin(LoginVM obj)
        {
            bool success = false;
            var res = (from o in EDMObj.LoginDetails
                       where o.Username == obj.UserName && o.Password == obj.Password
                       select o).FirstOrDefault();
            if (res != null)
            {
                success = true;
            }
            return success;
        }

       

        public List<DepartmentVM> ViewDept()
        {
            var res = (from o in EDMObj.Departments
                       select new DepartmentVM { DeptId = o.Deptid, DeptName = o.Deptname }).ToList();
            return res;
        }
        public bool AddDept(DepartmentVM obj)
        {
            bool success = false;
            try
            {
                Department dt = new Department();
                dt.Deptname = obj.DeptName;
                EDMObj.Departments.Add(dt);
                EDMObj.SaveChanges();
                success = true;
            }
            catch
            {

            }
            return success;
        }
        public void DeleteDept(long id)
        {
            var res = (from o in EDMObj.Departments
                       where o.Deptid == id
                       select o).FirstOrDefault();
            if (res != null)
            {
                EDMObj.Departments.Remove(res);
                EDMObj.SaveChanges();
            }
        }
        public List<EmployeeVM> DispalyEmployee()
        {
            var res = (from o1 in EDMObj.Employees
                       join o2 in EDMObj.Departments
                       on o1.Deptid equals o2.Deptid
                       select new EmployeeVM
                       {
                           Eid = o1.Empid,
                           Ename = o1.Empname,
                           Egrade = o1.Empgrade,
                           Esal = o1.Empsalary,
                           Mname = o1.Managername,
                           Deptname = o2.Deptname
                       }).ToList();
            return res;
        }
        public List<DepartmentVM> GetDept()
        {
            var res = (from o in EDMObj.Departments
                       select new DepartmentVM
                       {
                           DeptId = o.Deptid,
                           DeptName = o.Deptname
                       }).ToList();
            return res;
        }
        public List<EmployeeVM> GetEmp()
        {
            var res = (from o in EDMObj.Employees
                       select new EmployeeVM
                       {
                           Eid = o.Empid,
                           Ename = o.Empname
                       }).ToList();
            return res;
        }
        public bool AddEmp(EmployeeVM model)
        {
            bool success = false;
            try
            {
                Employee e = new Employee();
                e.Empname = model.Ename;
                e.Deptid = model.Deptid;
                e.Empgrade = model.Egrade;
                e.Empsalary = model.Esal;
                e.Managername = model.Mname;
                EDMObj.Employees.Add(e);
                EDMObj.SaveChanges();
                success = true;
            }
            catch (Exception)
            {

            }
            return success;
        }
        public EmployeeVM ShowEmp(long id)
        {
            EmployeeVM obj = new EmployeeVM();
            var res = (from o in EDMObj.Employees
                       where o.Empid == id
                       select o).FirstOrDefault();
            if(res!=null)
            {
                obj.Eid = res.Empid;
                obj.Ename = res.Empname;
                obj.Egrade = res.Empgrade;
                obj.Esal = res.Empsalary;
                obj.Deptid = res.Deptid;
                obj.Mname = res.Managername;
            }
            return obj;
        }
        public bool UpdateEmp(EmployeeVM e)
        {
            bool success = false;
            try
            {
                Employee obj = (from o in EDMObj.Employees
                                where o.Empid == e.Eid
                                select o).FirstOrDefault();
                if(obj!=null)
                {
                    obj.Empname = e.Ename;
                    obj.Empsalary = e.Esal;
                    obj.Empgrade = e.Egrade;
                    obj.Deptid = e.Deptid;
                    obj.Managername = e.Mname;

                    EDMObj.SaveChanges();
                    success = true;
                }
            }
            catch
            {

            }
            return success;
        }
        public void DeleteEmp(long id)
        {
            var res = (from o in EDMObj.Employees
                       where o.Empid == id
                       select o).FirstOrDefault();
            if(res!=null)
            {
                EDMObj.Employees.Remove(res);
                EDMObj.SaveChanges();
            }
        }
        public List<BonusVM> DisplayBon()
        {
            var res = (from o1 in EDMObj.Bonus
                       join o2 in EDMObj.Employees on o1.Empid equals o2.Empid
                       select new BonusVM
                       {
                           Bonid = o1.Bonid,
                           BonDate = o1.Bondate,
                           Bonamt = o1.Bonamount,
                           Ename = o2.Empname
                       }).ToList();
            return res;
        }

        public bool AddBonus(BonusVM model)
        {
            bool success = false;
            try
            {
                Bonu b = new Bonu();
                b.Bondate = model.BonDate;
                b.Bonamount = model.Bonamt;
                b.Empid = model.Eid;
                EDMObj.Bonus.Add(b);
                EDMObj.SaveChanges();
                success = true;
            }
            catch (Exception)
            {

            }
            return success;
        }
        public List<BonusVM> GetBonData(AddBonusVM model)
        {
            var res = (from o1 in EDMObj.Employees
                       join o2 in EDMObj.Bonus 
                       on o1.Empid equals o2.Empid where o1.Empid==model.Eid
                       select new BonusVM { 
                           Bonid = o2.Bonid, 
                           BonDate = o2.Bondate, 
                           Bonamt = o2.Bonamount, 
                           Ename = o1.Empname
                       }).ToList();
            return res;
        }
        public bool DeleteBon(long id)
        {
            bool success = false;
            var res = (from o in EDMObj.Bonus
                       where o.Bonid == id
                       select o).FirstOrDefault();
            if(res!=null)
            {
                EDMObj.Bonus.Remove(res);
                EDMObj.SaveChanges();
                success = true;
            }
            return success;
        }
        public BonusVM EditBon(long id)
        {
            BonusVM b = new BonusVM();
            var res = (from o in EDMObj.Bonus
                       where id == o.Bonid
                       select o).FirstOrDefault();
            if(res!=null)
            {
                
                b.Bonid = res.Bonid;
                b.BonDate = res.Bondate;
                b.Bonamt = res.Bonamount;
                b.Eid = res.Empid;
            }
            return b;
        }
        public bool UpdateBon(BonusVM model)
        {
            bool success = false;
            try
            {
                Bonu obj = (from o in EDMObj.Bonus
                                where o.Bonid == model.Bonid
                                select o).FirstOrDefault();
                if (obj != null)
                {
                    obj.Bondate = model.BonDate;
                    obj.Bonamount = model.Bonamt;
                    obj.Empid = model.Eid;

                    EDMObj.SaveChanges();
                    success = true;
                }
            }
            catch
            {

            }
            return success;
        }
        public List<EmpHisVM> GetHisData(AddEmpHisVM model)
        {
            var res = (from o1 in EDMObj.Employees
                       join o2 in EDMObj.EmpHistories
                       on o1.Empid equals o2.Empid
                       where o1.Empid == model.Eid
                       select new EmpHisVM
                       {
                           Emphid = o2.Emphisid,
                           SDate=o2.Startdate,
                           TDate=o2.Todate,
                           Cname=o2.NameOfCompany,
                           Ename=o1.Empname
                       }).ToList();
            return res;
        }
        public bool DeleteHis(long id)
        {
            bool success = false;
            var res = (from o in EDMObj.EmpHistories
                       where o.Emphisid == id
                       select o).FirstOrDefault();
            if (res != null)
            {
                EDMObj.EmpHistories.Remove(res);
                EDMObj.SaveChanges();
                success = true;
            }
            return success;
        }
        public EmpHisVM EditHis(long id)
        {
            EmpHisVM b = new EmpHisVM();
            var res = (from o in EDMObj.EmpHistories
                       where id == o.Emphisid
                       select o).FirstOrDefault();
            if (res != null)
            {

                b.Emphid = res.Emphisid;
                b.SDate = res.Startdate;
                b.TDate = res.Todate;
                b.Cname = res.NameOfCompany;
                b.Eid = res.Empid;
            }
            return b;
        }
        public bool UpdateHis(EmpHisVM model)
        {
            bool success = false;
            try
            {
                EmpHistory obj = (from o in EDMObj.EmpHistories
                            where o.Emphisid == model.Emphid
                            select o).FirstOrDefault();
                if (obj != null)
                {
                    obj.Startdate = model.SDate;
                    obj.Todate = model.TDate;
                    obj.NameOfCompany = model.Cname;
                    obj.Empid = model.Eid;

                    EDMObj.SaveChanges();
                    success = true;
                }
            }
            catch
            {

            }
            return success;
        }
        public bool AddHis(EmpHisVM model)
        {
            bool success = false;
            try
            {
                EmpHistory b = new EmpHistory();
                b.Startdate = model.SDate;
                b.Todate = model.TDate;
                b.Empid = model.Eid;
                b.NameOfCompany = model.Cname;
                EDMObj.EmpHistories.Add(b);
                EDMObj.SaveChanges();
                success = true;
            }
            catch (Exception)
            {

            }
            return success;
        }
        public List<Query2VM> Query2()
        {
            var result = (from o1 in EDMObj.Employees
                          group o1.Empid by o1.Deptid
                         into g
                          join o2 in EDMObj.Departments
                   on g.Key equals o2.Deptid
                          select new Query2VM
                          {
                              Deptname = o2.Deptname,
                              cnt = g.Count()
                          }).ToList();
            return result;
        }
        public List<EmployeeVM> Query_3(AddEmpVM model)
        {
            var res = (from o1 in EDMObj.Departments
                       join o2 in EDMObj.Employees
                       on o1.Deptid equals o2.Deptid
                       where o1.Deptid == model.Deptid
                       select new EmployeeVM
                       {
                           Eid = o2.Empid,
                           Ename=o2.Empname,
                           Egrade=o2.Empgrade,
                           Esal=o2.Empsalary,
                           Mname=o2.Managername,
                           Deptname=o1.Deptname
                       }).ToList();
            return res;
        }
        public List<EmployeeVM> Query_4(AddEmpVM model)
        {
            var res = (from o1 in EDMObj.Departments
                       join o2 in EDMObj.Employees
                       on o1.Deptid equals o2.Deptid
                       where o1.Deptid == model.Deptid
                       select new EmployeeVM
                       {
                           Eid = o2.Empid,
                           Ename = o2.Empname,
                           Egrade = o2.Empgrade,
                           Esal = o2.Empsalary,
                           Mname = o2.Managername,
                           Deptname = o1.Deptname
                       }).ToList();
            var res2 = (from o in res
                       where o.Esal<res.Average(e=>e.Esal)
                        select new EmployeeVM
                        {
                            Eid = o.Eid,
                            Ename = o.Ename,
                            Egrade = o.Egrade,
                            Esal = o.Esal,
                            Mname = o.Mname,
                            Deptname = o.Deptname
                        }).ToList();
            return res2;
        }
    }
}