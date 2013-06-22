using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class MemberSvcImpl: IMemberSvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addMember(member mem)
        {
            db.members.Add(mem);
            db.SaveChanges();
        }

        public member GetById(int id)
        {
            return db.members.Find(id);
        }

        public List<member> GetAll()
        {
            return db.members.ToList();
        }

        public void editMember(member mem)
        {
            var dbList = db.members.Single(p => p.memberid == mem.memberid);

            dbList.username = mem.username;
            dbList.userpass = mem.userpass;
            dbList.passphrase = mem.passphrase;
            dbList.memberstatus = mem.memberstatus;
            dbList.approleid = mem.approleid;
            dbList.studentid = mem.studentid;
            dbList.contactid = mem.contactid;

            db.SaveChanges();
        }

        public void deleteMember(member mem)
        {
            db.members.Remove(mem);
            db.SaveChanges();
        }

        public member GetAccount(member mem)
        {
            return db.members.Where(m => m.username==m.username & m.userpass == m.userpass).FirstOrDefault();
        }
    }
}
