//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class approle
    {
        public approle()
        {
            this.members = new HashSet<member>();
        }
    
        public int approleid { get; set; }
        public string rolename { get; set; }
        public string note { get; set; }
    
        public virtual ICollection<member> members { get; set; }
    }
}
