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

        public feerequest GetAll(int id)
        {
            feerequest request = (from d in db.feerequests
                            where d.feerequestid == id
                            select d).Single();

            return request;
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
