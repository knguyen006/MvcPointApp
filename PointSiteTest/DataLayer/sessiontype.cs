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
    using System.ComponentModel.DataAnnotations;
    
    public partial class sessiontype
    {
        public sessiontype()
        {
            this.sessioncals = new HashSet<sessioncal>();
        }
        
        [Required]
        public int sessiontypeid { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength=1)]
        public string typename { get; set; }
        public string note { get; set; }
    
        public virtual ICollection<sessioncal> sessioncals { get; set; }
    }
}
