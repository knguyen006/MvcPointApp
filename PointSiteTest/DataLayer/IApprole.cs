using System;
namespace DataLayer
{
    interface IApprole
    {
        int approleid { get; set; }
        System.Collections.Generic.ICollection<member> members { get; set; }
        string note { get; set; }
        string rolename { get; set; }
    }
}
