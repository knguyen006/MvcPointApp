using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class SessioncalMgr : Manager
    {
        public ISessioncalSvc svc;

        public SessioncalMgr()
        {
            svc = (ISessioncalSvc)GetService(typeof(ISessioncalSvc).Name);
        }


        public void Create(sessioncal cal)
        {
            svc.addSessioncal(cal);
        }

        public void Update(sessioncal cal)
        {
            svc.editSessioncal(cal);
        }

        public void Delete(sessioncal cal)
        {
            svc.deleteSessioncal(cal);
        }


        public sessioncal Retrieved(int id)
        {
            return svc.GetById(id);
        }

        public List<sessioncal> GetAll()
        {
            return svc.GetAll();
        }


    }
}
