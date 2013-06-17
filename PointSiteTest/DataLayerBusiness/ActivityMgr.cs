using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class ActivityMgr
    {
        public PointAppDBContext context;

        Factory factory = Factory.GetInstance();

        public ActivityMgr()
        {
            this.context = new PointAppDBContext();
        }

        public ActivityMgr(PointAppDBContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(activity act)
        {
            IActivitySvc actSvc = (IActivitySvc)factory.GetService("IActivitySvc", context);

            actSvc.Insert(act);
            actSvc.Save();
        }

        public void Update(activity act)
        {
            IActivitySvc actSvc = (IActivitySvc)factory.GetService("IActivitySvc", context);

            actSvc.Update(act);
            actSvc.Save();
        }

        public void Delete(activity act)
        {
            IActivitySvc actSvc = (IActivitySvc)factory.GetService("IActivitySvc", context);

            actSvc.Delete(act);
            actSvc.Save();
        }

        public activity Find(int id)
        {
            IActivitySvc actSvc = (IActivitySvc)factory.GetService("IActivitySvc", context);

            return actSvc.GetById(id);
        }

        public IEnumerable<activity> GetActivity()
        {
            IActivitySvc actSvc = (IActivitySvc)factory.GetService("IActivitySvc", context);

            return actSvc.GetAll();
        }


    }
}
