using System;
namespace DataLayer
{
    interface IMember
    {
        System.Collections.Generic.ICollection<activity> activities { get; set; }
        approle approle { get; set; }
        int? approleid { get; set; }
        System.Collections.Generic.ICollection<contact> contacts { get; set; }
        System.Collections.Generic.ICollection<feerequest> feerequests { get; set; }
        System.Collections.Generic.ICollection<member> member1 { get; set; }
        int memberid { get; set; }
        System.Collections.Generic.ICollection<member> members { get; set; }
        string membertype { get; set; }
        string passphrase { get; set; }
        System.Collections.Generic.ICollection<signup> signups { get; set; }
        System.Collections.Generic.ICollection<student> students { get; set; }
        string username { get; set; }
        string userpass { get; set; }

    }
}
