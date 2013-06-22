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

        public activity GetAll(int id)
        {
            activity act = (from d in db.activities
                            where d.activityid == id
                            select d).Single();
            
            return act;
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
