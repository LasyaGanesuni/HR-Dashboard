//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Login_Role_MVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class LoginInfo
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public long RoleId { get; set; }
    
        public virtual RoleInfo RoleInfo { get; set; }
    }
}