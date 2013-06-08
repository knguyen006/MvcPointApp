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
        private PointAppDBContainer db = new PointAppDBContainer();

        public sessioncal Find(int sessioncalid)
        {
            return db.sessioncals.Find(sessioncalid);
        }

        public List<sessioncal> GetAll()
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
    }
}
