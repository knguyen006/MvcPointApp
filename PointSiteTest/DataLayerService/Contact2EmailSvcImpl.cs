using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;
using System.Data;
using System.Data.Entity;
using System.Linq;

/// <summary>
/// Summary description
/// </summary>
namespace DataLayerService
{
    public class ContactEmailSvcImpl : IContactEmailSvc
    {
        private PointAppDBContainer db;

        public ContactEmailSvcImpl(PointAppDBContainer db)
        {
            this.db = db;
        }

        public contactemail Find(int contactemailid)
        {
            return db.contactemails.Find(contactemailid);
        }

        public IEnumerable<contactemail> GetAll()
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

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
