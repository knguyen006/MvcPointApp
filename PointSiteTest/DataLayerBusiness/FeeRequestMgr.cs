using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class FeerequestMgr
    {
        public PointAppDBContext context;

        Factory factory = Factory.GetInstance();

        public FeerequestMgr()
        {
            this.context = new PointAppDBContext();
        }

        public FeerequestMgr(PointAppDBContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(feerequest request)
        {
            IFeerequestSvc requestSvc = (IFeerequestSvc)factory.GetService("IFeerequestSvc", context);

            requestSvc.Insert(request);
            requestSvc.Save();
        }

        public void Update(feerequest request)
        {
            IFeerequestSvc requestSvc = (IFeerequestSvc)factory.GetService("IFeerequestSvc", context);

            requestSvc.Update(request);
            requestSvc.Save();
        }

        public void Delete(feerequest request)
        {
            IFeerequestSvc requestSvc = (IFeerequestSvc)factory.GetService("IFeerequestSvc", context);

            requestSvc.Delete(request);
            requestSvc.Save();
        }

        public feerequest Find(int id)
        {
            IFeerequestSvc requestSvc = (IFeerequestSvc)factory.GetService("IFeerequestSvc", context);

            return requestSvc.GetById(id);
        }

        public IEnumerable<feerequest> GetFeerequest()
        {
            IFeerequestSvc requestSvc = (IFeerequestSvc)factory.GetService("IFeerequestSvc", context);

            return requestSvc.GetAll();
        }


    }
}
