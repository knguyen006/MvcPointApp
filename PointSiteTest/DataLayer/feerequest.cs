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
    
    public partial class feerequest
    {
        [Required]
        public int feerequestid { get; set; }

        public int memberid { get; set; }
        public System.DateTime requestdate { get; set; }
        public Nullable<decimal> requestamt { get; set; }
        public Nullable<int> pointbal { get; set; }
    
        public virtual member member { get; set; }
    }
}
