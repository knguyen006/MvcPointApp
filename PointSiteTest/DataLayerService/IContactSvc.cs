using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;

/// <summary>
/// Summary description for IActivity
/// </summary>
namespace DataLayerService
{
    public interface IContactSvc
    {
        contact Find(int contactid);
        List<contact> GetAll();
        void AddContact(contact newcontact);
        void UpdateContact(contact newcontact);
        void DeleteContact(contact newcontact);
    }
}
