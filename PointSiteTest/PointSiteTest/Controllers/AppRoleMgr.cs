using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayerService;
using DataLayer;

namespace PointSiteTest.Controllers
{
    public class AppRoleMgr
    {
        PointAppFactory factory = PointAppFactory.GetInstance();

        public void Create(approle role)
        {

            try
            {
                IAppRoleSvc roleSvc = (IAppRoleSvc)factory.GetAppRole("IAppRoleSvc");
                roleSvc.AddRole(role);
            }
            catch
            {
                throw new ArgumentException("Cannot add record!");
            }
        }

        /*
        public approle Find(int newid)
        {

        }
         */

        public void Update(approle role)
        {
            try
            {
                IAppRoleSvc roleSvc = (IAppRoleSvc)factory.GetAppRole("IAppRoleSvc");
                roleSvc.UpdateRole(role);
            }
            catch
            {
                throw new ArgumentException("Cannot update record");
            }
        }

        public void Delete(approle role)
        {
            try
            {
                IAppRoleSvc roleSvc = (IAppRoleSvc)factory.GetAppRole("IAppRoleSvc");
                roleSvc.DeleteRole(role);
            }
            catch
            {
                throw new ArgumentException("Cannot delete record");
            }
        }
    }
}