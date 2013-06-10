using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayerService;
using DataLayer;

namespace PointSiteTest.Controllers
{
    public class SessionTypeMgr
    {
        PointAppFactory factory = PointAppFactory.GetInstance();

        public void Create(sessiontype type)
        {

            try
            {
                ISessionTypeSvc typeSvc = (ISessionTypeSvc)factory.GetSessionType("ISessionTypeSvc");
                typeSvc.AddSessionType(type);
            }
            catch
            {
                throw new ArgumentException("Cannot add record!");
            }
        }

        /*
        public sessiontype Find(int newid)
        {

        }
         */

        public void Update(sessiontype type)
        {
            try
            {
                ISessionTypeSvc typeSvc = (ISessionTypeSvc)factory.GetSessionType("ISessionTypeSvc");
                typeSvc.UpdateSessionType(type);
            }
            catch
            {
                throw new ArgumentException("Cannot update record");
            }
        }

        public void Delete(sessiontype type)
        {
            try
            {
                ISessionTypeSvc typeSvc = (ISessionTypeSvc)factory.GetSessionType("ISessionTypeSvc");
                typeSvc.DeleteSessionType(type);
            }
            catch
            {
                throw new ArgumentException("Cannot delete record");
            }
        }
    }
}