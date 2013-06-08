using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;
using System.Linq;
using System.Data.Entity;
using System.Data;

/// <summary>
/// Summary description for ContactivityRepositoryImpl
/// </summary>
namespace DataLayerService
{
    public class ContactSvcImpl : IContactSvc
    {
        private PointAppDBContainer db = new PointAppDBContainer();

        public contact Find(int contactid)
        {
            return db.contacts.Find(contactid);
        }

        public List<contact> GetAll()
        {
            return db.contacts.ToList();
        }

        public void AddContact(contact newcontact)
        {
            db.contacts.Add(newcontact);
            db.SaveChanges();
        }

        public void UpdateContact(contact newcontact)
        {
            db.Entry(newcontact).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteContact(contact newcontact)
        {
            db.contacts.Remove(newcontact);
            db.SaveChanges();
        }
    }
}
