using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Case_Study.Models
{
    public class LoginVM
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
    public class DepartmentVM
    {
        public long DeptId { get; set; }
        public string DeptName { get; set; }
    }
    public class DeptLVM
    {
        public List<DepartmentVM> Dlst { get; set; } = new List<DepartmentVM>();
    }
    public class EmployeeVM
    {
        public long Eid { get; set; }
        public string Ename { get; set; }
        public string Egrade { get; set; }
        public long Esal { get; set; }
        public long Deptid { get; set; }
        public string Deptname { set; get; }
        public string Mname { set; get; }
    }
    public class EmpLVM
    {
        public List<EmployeeVM> Elst { get; set; } = new List<EmployeeVM>();
    }
    public class AddEmpVM
    {
        public long Eid { get; set; }
        public string Ename { get; set; }
        public string Egrade { get; set; }
        public long Esal { get; set; }
        public string Mname { set; get; }
        public long Deptid { get; set; }
        public List<EmployeeVM> AElst { get; set; } = new List<EmployeeVM>();
        public List<SelectListItem> DLst { get; set; } = new List<SelectListItem>();
    }
    public class BonusVM
    {
        public long Bonid { get; set; }
        public System.DateTime BonDate { get; set; }
        public long Bonamt { get; set; }
        public long Eid { get; set; }
        public string Ename { get; set; }
    }
    public class BonLVM
    {
        public List<BonusVM> Blst { get; set; } = new List<BonusVM>();  
    }
    public class AddBonusVM
    {
        public long Bonid { get; set; }
        public System.DateTime BonDate { get; set; }
        public long Bonamt { get; set; }
        public long Eid { get; set; }
        public List<BonusVM> B2lst { get; set; } = new List<BonusVM>();
        public List<SelectListItem> BSLst { get; set; } = new List<SelectListItem>();
    }
    public class EmpHisVM
    {
        public long Emphid { get; set; }
        public System.DateTime SDate { get; set; }
        public System.DateTime TDate { get; set; }
        public string Cname { get; set; }
        public long Eid { get; set; }
        public string Ename { get; set; }
    }
    public class EmpHLVM
    {
        public List<EmpHisVM> Blst { get; set; } = new List<EmpHisVM>();
    }
    public class AddEmpHisVM
    {
        public long Emphid { get; set; }
        public System.DateTime SDate { get; set; }
        public System.DateTime TDate { get; set; }
        public string Cname { get; set; }
        public long Eid { get; set; }
        public List<EmpHisVM> E2lst { get; set; } = new List<EmpHisVM>();
        public List<SelectListItem> ESLst { get; set; } = new List<SelectListItem>();
    }
    public class Query2VM
    {
        public string Deptname { get; set; }
        public int cnt { get; set; }
    }
    public class Query2LVM
    {
        public List<Query2VM> q2lst { get; set; } = new List<Query2VM>();
    }
}