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
    public class MemberSvcImpl : IMemberSvc
    {
        private PointAppDBContainer db;

        public MemberSvcImpl(PointAppDBContainer db)
        {
            this.db = db;
        }

        public member Find(int memberid)
        {
            return db.members.Find(memberid);
        }

        public IEnumerable<member> GetAll()
        {
            return db.members.ToList();
        }

        public void AddMember(member newmember)
        {
            db.members.Add(newmember);
            db.SaveChanges();
        }

        public void UpdateMember(member newmember)
        {
            db.Entry(newmember).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteMember(member newmember)
        {
            db.members.Remove(newmember);
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
