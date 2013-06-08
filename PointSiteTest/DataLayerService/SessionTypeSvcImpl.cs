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
    public class SessionTypeSvcImpl : ISessionTypeSvc
    {
        private PointAppDBContainer db = new PointAppDBContainer();

        public sessiontype Find(int sessiontypeid)
        {
            return db.sessiontypes.Find(sessiontypeid);
        }

        public List<sessiontype> GetAll()
        {
            return db.sessiontypes.ToList();
        }

        public void AddSessionType(sessiontype newsessiontype)
        {
            db.sessiontypes.Add(newsessiontype);
            db.SaveChanges();
        }

        public void UpdateSessionType(sessiontype newsessiontype)
        {
            db.Entry(newsessiontype).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteSessionType(sessiontype newsessiontype)
        {
            db.sessiontypes.Remove(newsessiontype);
            db.SaveChanges();
        }
    }
}

