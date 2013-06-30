using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class ProfileSvcImpl: IProfileSvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addProfile(profile pro)
        {
            db.profiles.Add(pro);
            db.SaveChanges();
        }

        public profile GetById(int id)
        {
            return db.profiles.Find(id);
        }

        public List<profile> GetAll()
        {
            return db.profiles.ToList();
        }

        public void editProfile(profile pro)
        {
            var dbList = db.profiles.Single(p => p.profileid == pro.profileid);

            dbList.studentid = pro.studentid;
            dbList.dependentid = pro.dependentid;
            dbList.memberid = pro.memberid;
            dbList.familyid = pro.familyid;
            dbList.memberstatus = pro.memberstatus;

            db.SaveChanges();
        }

        public void deleteProfile(profile pro)
        {
            db.profiles.Remove(pro);
            db.SaveChanges();
        }
    }
}
