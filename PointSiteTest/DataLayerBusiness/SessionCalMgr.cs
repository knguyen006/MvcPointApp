using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class SessioncalMgr
    {
        public PointAppDBContext context;

        Factory factory = Factory.GetInstance();

        public SessioncalMgr()
        {
            this.context = new PointAppDBContext();
        }

        public SessioncalMgr(PointAppDBContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(sessioncal newcal)
        {
            ISessioncalSvc calSvc = (ISessioncalSvc)factory.GetService("ISessioncalSvc", context);

            calSvc.Insert(newcal);
            calSvc.Save();
        }

        public void Update(sessioncal newcal)
        {
            ISessioncalSvc calSvc = (ISessioncalSvc)factory.GetService("ISessioncalSvc", context);

            calSvc.Update(newcal);
            calSvc.Save();
        }

        public void Delete(sessioncal newcal)
        {
            ISessioncalSvc calSvc = (ISessioncalSvc)factory.GetService("ISessioncalSvc", context);

            calSvc.Delete(newcal);
            calSvc.Save();
        }

        public sessioncal Find(int id)
        {
            ISessioncalSvc calSvc = (ISessioncalSvc)factory.GetService("ISessioncalSvc", context);

            return calSvc.GetById(id);
        }

        public IEnumerable<sessioncal> GetSessioncal()
        {
            ISessioncalSvc calSvc = (ISessioncalSvc)factory.GetService("ISessioncalSvc", context);

            return calSvc.GetAll();
        }


    }
}
