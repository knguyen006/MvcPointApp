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

    public partial class contact
    {
        public contact()
        {
            this.contactemails = new HashSet<contactemail>();
        }
    
        [Required]
        public int contactid { get; set; }

        [Required]
        public int memberid { get; set; }

        [Required(ErrorMessage="First name is required.")]
        [Display(Name="First name ")]
        public string firstname { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last name ")]
        public string lastname { get; set; }

        [Display(Name = "Middle")]
        public string middlename { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [Display(Name = "Address ")]
        public string address { get; set; }

        [Display(Name = "Alt address ")]
        public string altaddress { get; set; }

        [Display(Name = "City ")]
        public string city { get; set; }

        [Display(Name = "State ")]
        public string state { get; set; }

        [Display(Name = "Zip ")]
        public string zip { get; set; }

        [Display(Name = "Home phone ")]
        public string homephone { get; set; }

        [Display(Name = "Work phone ")]
        public string workphone { get; set; }

        [Display(Name="Mobile phone ")]
        public string mobilephone { get; set; }
    
        public virtual member member { get; set; }
        public virtual ICollection<contactemail> contactemails { get; set; }
    }
}
