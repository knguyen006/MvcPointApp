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
        feerequest GetById(int id);
        List<feerequest> GetAll();
        void editRequest(feerequest request);
        void deleteRequest(feerequest request);
    }
}
