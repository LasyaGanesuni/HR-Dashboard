//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Final_Case_Study
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmpHistory
    {
        public long Emphisid { get; set; }
        public System.DateTime Startdate { get; set; }
        public System.DateTime Todate { get; set; }
        public string NameOfCompany { get; set; }
        public long Empid { get; set; }
    
        public virtual Employee Employee { get; set; }
    }
}
