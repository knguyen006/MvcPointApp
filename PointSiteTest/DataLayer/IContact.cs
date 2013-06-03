using System;
namespace DataLayer
{
    interface IContact
    {
        string address { get; set; }
        string altaddress { get; set; }
        string city { get; set; }
        System.Collections.Generic.ICollection<contactemail> contactemails { get; set; }
        int contactid { get; set; }
        string firstname { get; set; }
        string homephone { get; set; }
        string lastname { get; set; }
        System.Collections.Generic.ICollection<member> members { get; set; }
        string middlename { get; set; }
        string mobilephone { get; set; }
        string state { get; set; }
        string workphone { get; set; }
        string zip { get; set; }
    }
}
