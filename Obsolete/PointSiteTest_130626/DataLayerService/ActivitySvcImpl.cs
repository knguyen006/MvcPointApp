using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class ActivitySvcImpl : IActivitySvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addActivity(activity act)
        {
            db.activities.Add(act);
            db.SaveChanges();
        }

        public activity GetById(int id)
        {
            return db.activities.Find(id);
        }

        public List<activity> GetAll()
        {
            return db.activities.ToList();
        }

        public void editActivity(activity act)
        {
            var dbList = db.activities.Single(p => p.activityid == act.activityid);

            dbList.actname = act.actname;
            
            db.SaveChanges();
        }

        public void deleteActivity(activity act)
        {
            db.activities.Remove(act);
            db.SaveChanges();
        }
    } 
}
