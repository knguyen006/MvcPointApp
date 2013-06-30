using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class FeerequestSvcImpl: IFeerequestSvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addRequest(feerequest request)
        {
            db.feerequests.Add(request);
            db.SaveChanges();
        }

        public feerequest GetById(int id)
        {
            return db.feerequests.Find(id);
        }

        public List<feerequest> GetAll()
        {
            return db.feerequests.ToList();
        }

        public void editRequest(feerequest request)
        {
            var dbList = db.feerequests.Single(p => p.feerequestid == request.feerequestid);

            dbList.memberid = request.memberid;


            db.SaveChanges();
        }

        public void deleteRequest(feerequest request)
        {
            db.feerequests.Remove(request);
            db.SaveChanges();
        }

    }
}
