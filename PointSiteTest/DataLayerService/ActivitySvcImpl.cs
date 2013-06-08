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
    public class ActivitySvcImpl : IActivitySvc
    {
        private PointAppDBContainer db = new PointAppDBContainer();

        public activity Find(int activityid)
        {
            return db.activities.Find(activityid);
        }

        public List<activity> GetAll()
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
    }
}
