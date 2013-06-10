using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;
using System.Data.Entity;
using System.Data;
using System.Linq;

/// <summary>
/// Summary description
/// </summary>
namespace DataLayerService
{
    public class FeeRequestSvcImpl : IFeeRequestSvc
    {
        private PointAppDBContainer db;

        public FeeRequestSvcImpl(PointAppDBContainer db)
        {
            this.db = db;
        }

        public feerequest Find(int feerequestid)
        {
            return db.feerequests.Find(feerequestid);
        }

        public IEnumerable<feerequest> GetAll()
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

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
