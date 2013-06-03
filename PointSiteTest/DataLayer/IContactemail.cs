using System;
namespace DataLayer
{
    interface IContactemail
    {
        contact contact { get; set; }
        int contactemailid { get; set; }
        int? contactid { get; set; }
        string emailaddress { get; set; }
    }
}
