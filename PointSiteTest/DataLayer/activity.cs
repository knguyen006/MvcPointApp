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
    
    public partial class activity
    {
        public activity()
        {
            this.members = new HashSet<member>();
        }
    
        public int activityid { get; set; }
        public string actname { get; set; }
    
        public virtual ICollection<member> members { get; set; }
    }
}
