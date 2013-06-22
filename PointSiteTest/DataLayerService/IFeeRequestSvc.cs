using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface IFeerequestSvc : IService
    {
        void addRequest(feerequest request);
        feerequest GetAll(int id);
        void editRequest(feerequest request);
        void deleteRequest(feerequest request);
    }
}
