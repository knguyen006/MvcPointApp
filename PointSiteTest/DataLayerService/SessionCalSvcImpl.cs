using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;
using System.Data.Entity;
using System.Data;
using System.Linq;

/// <summary>
/// Summary description for ActivityRepositoryImpl
/// </summary>
namespace DataLayerService
{
    public class SessionCalSvcImpl : ISessionCalSvc
    {
        private PointAppDBContainer db;

        public SessionCalSvcImpl(PointAppDBContainer db)
        {
            this.db = db;
        }

        public sessioncal Find(int sessioncalid)
        {
            return db.sessioncals.Find(sessioncalid);
        }

        public IEnumerable<sessioncal> GetAll()
        {
            return db.sessioncals.ToList();
        }

        public void AddSessionCal(sessioncal newsessioncal)
        {
            db.sessioncals.Add(newsessioncal);
            db.SaveChanges();
        }

        public void UpdateSessionCal(sessioncal newsessioncal)
        {
            db.Entry(newsessioncal).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteSessionCal(sessioncal newsessioncal)
        {
            db.sessioncals.Remove(newsessioncal);
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
