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
    public class SignUpSvcImpl : ISignUpSvc
    {
        private PointAppDBContainer db = new PointAppDBContainer();

        public signup Find(int signupid)
        {
            return db.signups.Find(signupid);
        }

        public List<signup> GetAll()
        {
            return db.signups.ToList();
        }

        public void AddSignUp(signup newsignup)
        {
            db.signups.Add(newsignup);
            db.SaveChanges();
        }

        public void UpdateSignUp(signup newsignup)
        {
            db.Entry(newsignup).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteSignUp(signup newsignup)
        {
            db.signups.Remove(newsignup);
            db.SaveChanges();
        }
    }
}

