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
    
    public partial class student
    {
        public student()
        {
            this.members = new HashSet<member>();
        }
        
        [Required]
        public int studentid { get; set; }

        [Required]
        [StringLength(30, ErrorMessage="The {0} must be at least {2} characters long.", MinimumLength=1)]
        public string firstname { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength=1)]
        public string lastname { get; set; }
        public string middlename { get; set; }
        public Nullable<int> grade { get; set; }
        public string active { get; set; }
    
        public virtual ICollection<member> members { get; set; }
    }
}
