using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;

/// <summary>
/// Summary description for IContactEmail
/// </summary>
namespace DataLayerService
{
    public interface IContactEmailSvc
    {
        contactemail Find(int contactemailid);
        IEnumerable<contactemail> GetAll();
        void AddEmail(contactemail newemail);
        void UpdateEmail(contactemail newemail);
        void DeleteEmail(contactemail newemail);
        void Dispose();
    }
}
