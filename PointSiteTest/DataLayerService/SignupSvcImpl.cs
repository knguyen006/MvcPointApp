using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class SignupSvcImpl: ISignupSvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addSignup(signup sign)
        {
            db.signups.Add(sign);
            db.SaveChanges();
        }

        public signup GetById(int id)
        {
            return db.signups.Find(id);
        }

        public List<signup> GetAll()
        {
            return db.signups.ToList();
        }

        public void editSignup(signup sign)
        {
            var dbList = db.signups.Single(p => p.signupid == sign.signupid);

            dbList.memberid = sign.memberid;
            dbList.sessioncalid = sign.sessioncalid;
            dbList.pointearn = sign.pointearn;
            dbList.isshow = sign.isshow;

            db.SaveChanges();
        }

        public void deleteSignup(signup sign)
        {
            db.signups.Remove(sign);
            db.SaveChanges();
        }
    }
}
