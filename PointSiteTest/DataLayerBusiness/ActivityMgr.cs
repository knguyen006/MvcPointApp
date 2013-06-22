using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class ActivityMgr : Manager
    {
        public IActivitySvc svc;

        public ActivityMgr()
        {
            svc = (IActivitySvc)GetService(typeof(IActivitySvc).Name);
        }


        public void Create(activity act)
        {
            svc.addActivity(act);
        }

        public void Update(activity act)
        {
            svc.editActivity(act);
        }

        public void Delete(activity act)
        {
            svc.deleteActivity(act);
        }


        public activity Retrieved(int id)
        {
            activity db = svc.GetAll(id);

            return db;
        }


    }
}
