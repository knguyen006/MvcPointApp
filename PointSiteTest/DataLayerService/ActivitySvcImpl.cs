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
    public class ActivitySvcImpl : IActivitySvc
    {
        private PointAppDBContainer db = new PointAppDBContainer();

        public ActivitySvcImpl(PointAppDBContainer newdb)
        {
            this.db = newdb;
        }

        public activity Find(int activityid)
        {
            return db.activities.Find(activityid);
        }

        public IEnumerable<activity> GetAll()
        {
            return db.activities.ToList();
        }

        public void AddAct(activity newact)
        {
            db.activities.Add(newact);
            db.SaveChanges();
        }

        public void UpdateAct(activity newact)
        {
            db.Entry(newact).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteAct(activity newact)
        {
            db.activities.Remove(newact);
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
