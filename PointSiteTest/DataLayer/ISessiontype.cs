using System;
namespace DataLayer
{
    interface ISessiontype
    {
        string note { get; set; }
        System.Collections.Generic.ICollection<sessioncal> sessioncals { get; set; }
        int sessiontypeid { get; set; }
        string typename { get; set; }
    }
}
