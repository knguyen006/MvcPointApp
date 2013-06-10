using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayerService;
using DataLayer;

namespace PointSiteTest.Controllers
{
    public class FeeRequestMgr
    {
        PointAppFactory factory = PointAppFactory.GetInstance();

        public void Create(feerequest request)
        {

            try
            {
                IFeeRequestSvc requestSvc = (IFeeRequestSvc)factory.GetFeeRequest("IFeeRequestSvc");
                requestSvc.AddRequest(request);
            }
            catch
            {
                throw new ArgumentException("Cannot add record!");
            }
        }

        /*
        public feerequest Find(int newid)
        {

        }
         */

        public void Update(feerequest request)
        {
            try
            {
                IFeeRequestSvc requestSvc = (IFeeRequestSvc)factory.GetFeeRequest("IFeeRequestSvc");
                requestSvc.UpdateRequest(request);
            }
            catch
            {
                throw new ArgumentException("Cannot update record");
            }
        }

        public void Delete(feerequest request)
        {
            try
            {
                IFeeRequestSvc requestSvc = (IFeeRequestSvc)factory.GetFeeRequest("IFeeRequestSvc");
                requestSvc.DeleteRequest(request);
            }
            catch
            {
                throw new ArgumentException("Cannot delete record");
            }
        }
    }
}