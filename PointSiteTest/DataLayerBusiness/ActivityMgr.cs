using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayerService;
using DataLayer;

namespace DaLayerBusiness
{
    public class ActivityMgr
    {
        PointAppFactory factory = PointAppFactory.GetInstance();

        public void Create(activity act)
        {

            try
            {
                IActivitySvc actSvc = (IActivitySvc)factory.GetActivity("IActivitySvc");
                actSvc.AddAct(act);
            }
            catch
            {
                throw new ArgumentException("Cannot add record!");
            }
        }

        /*
        public activity Find(int newid)
        {

        }
         */

        public void Update(activity act)
        {
            try
            {
                IActivitySvc actSvc = (IActivitySvc)factory.GetActivity("IActivitySvc");
                actSvc.UpdateAct(act);
            }
            catch
            {
                throw new ArgumentException("Cannot update record");
            }
        }

        public void Delete(activity act)
        {
            try
            {
                IActivitySvc actSvc = (IActivitySvc)factory.GetActivity("IActivitySvc");
                actSvc.DeleteAct(act);
            }
            catch
            {
                throw new ArgumentException("Cannot delete record");
            }
        }
    }
}