using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;
using System.Data.Entity;
using System.Data;
using System.Linq;

/// <summary>
/// Summary description
/// </summary>
namespace DataLayerService
{
    public class SignUpSvcImpl : ISignUpSvc
    {
        private PointAppDBContainer db;

        public SignUpSvcImpl(PointAppDBContainer db)
        {
            this.db = db;
        }

        public signup Find(int signupid)
        {
            return db.signups.Find(signupid);
        }

        public IEnumerable<signup> GetAll()
        {
            return db.signups.ToList();
        }

        public void AddSignUp(signup newsignup)
        {
            db.signups.Add(newsignup);
            db.SaveChanges();
        }

        public void UpdateSignUp(signup newsignup)
        {
            db.Entry(newsignup).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteSignUp(signup newsignup)
        {
            db.signups.Remove(newsignup);
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

