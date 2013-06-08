using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;
using System.Data;
using System.Data.Entity;
using System.Linq;

/// <summary>
/// Summary description for ActivityRepositoryImpl
/// </summary>
namespace DataLayerService
{
    public class ContactEmailSvcImpl : IContactEmailSvc
    {
        private PointAppDBContainer db = new PointAppDBContainer();

        public contactemail Find(int contactemailid)
        {
            return db.contactemails.Find(contactemailid);
        }

        public List<contactemail> GetAll()
        {
            return db.contactemails.ToList();
        }

        public void AddEmail(contactemail newemail)
        {
            db.contactemails.Add(newemail);
            db.SaveChanges();
        }

        public void UpdateEmail(contactemail newemail)
        {
            db.Entry(newemail).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEmail(contactemail newemail)
        {
            db.contactemails.Remove(newemail);
            db.SaveChanges();
        }
    }
}
