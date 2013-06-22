using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class FeerequestMgr : Manager
    {
        public IFeerequestSvc svc;

        public FeerequestMgr()
        {
            svc = (IFeerequestSvc)GetService(typeof(IFeerequestSvc).Name);
        }


        public void Create(feerequest request)
        {
            svc.addRequest(request);
        }

        public void Update(feerequest request)
        {
            svc.editRequest(request);
        }

        public void Delete(feerequest request)
        {
            svc.deleteRequest(request);
        }


        public feerequest Retrieved(int id)
        {
            feerequest db = svc.GetAll(id);

            return db;
        }



    }
}
