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

    public partial class sessioncal
    {
        public sessioncal()
        {
            this.signups = new HashSet<signup>();
        }
    
        [Required]
        public int sessioncalid { get; set; }

        [Required]
        [Display(Name="Session Date: ")]
        public System.DateTime sessiondate { get; set; }

        [Required]
        public int sessiontypeid { get; set; }

        [Required]
        [Display(Name="Session number: ")]
        public int sessionnum { get; set; }

        [Required]
        [Display(Name="Session total amount: ")]
        public decimal sessionamt { get; set; }

        [Required]
        [Display(Name="Session total point: ")]
        public int sessionpoint { get; set; }
    
        public virtual sessiontype sessiontype { get; set; }
        public virtual ICollection<signup> signups { get; set; }
    }
}