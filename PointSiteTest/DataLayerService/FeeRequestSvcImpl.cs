using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;
using System.Data.Entity;
using System.Data;
using System.Linq;

/// <summary>
/// Summary description for RequestivityRepositoryImpl
/// </summary>
namespace DataLayerService
{
    public class FeeRequestSvcImpl : IFeeRequestSvc
    {
        private PointAppDBContainer db = new PointAppDBContainer();

        public feerequest Find(int feerequestid)
        {
            return db.feerequests.Find(feerequestid);
        }

        public List<feerequest> GetAll()
        {
            return db.feerequests.ToList();
        }

        public void AddRequest(feerequest newrequest)
        {
            db.feerequests.Add(newrequest);
            db.SaveChanges();
        }

        public void UpdateRequest(feerequest newrequest)
        {
            db.Entry(newrequest).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteRequest(feerequest newrequest)
        {
            db.feerequests.Remove(newrequest);
            db.SaveChanges();
        }
    }
}
