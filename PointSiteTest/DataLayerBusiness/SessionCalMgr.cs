using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayerService;
using DataLayer;

namespace DaLayerBusiness
{
    public class SessionCalMgr
    {
        PointAppFactory factory = PointAppFactory.GetInstance();

        public void Create(sessioncal sessioncal)
        {

            try
            {
                ISessionCalSvc sessioncalSvc = (ISessionCalSvc)factory.GetSessionCal("ISessionCalSvc");
                sessioncalSvc.AddSessionCal(sessioncal);
            }
            catch
            {
                throw new ArgumentException("Cannot add record!");
            }
        }

        /*
        public sessioncal Find(int newid)
        {

        }
         */

        public void Update(sessioncal sessioncal)
        {
            try
            {
                ISessionCalSvc sessioncalSvc = (ISessionCalSvc)factory.GetSessionCal("ISessionCalSvc");
                sessioncalSvc.UpdateSessionCal(sessioncal);
            }
            catch
            {
                throw new ArgumentException("Cannot update record");
            }
        }

        public void Delete(sessioncal sessioncal)
        {
            try
            {
                ISessionCalSvc sessioncalSvc = (ISessionCalSvc)factory.GetSessionCal("ISessionCalSvc");
                sessioncalSvc.DeleteSessionCal(sessioncal);
            }
            catch
            {
                throw new ArgumentException("Cannot delete record");
            }
        }
    }
}