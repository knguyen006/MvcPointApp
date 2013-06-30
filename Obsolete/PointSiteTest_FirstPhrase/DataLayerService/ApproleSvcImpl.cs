using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class ApproleSvcImpl: IApproleSvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addRole(approle role)
        {
            db.approles.Add(role);
            db.SaveChanges();
        }

        public approle GetById(int id)
        {
            return db.approles.Find(id);
        }

        public List<approle> GetAll()
        {
            return db.approles.ToList();
        }

        public void editRole(approle role)
        {
            var dbList = db.approles.Single(p => p.approleid == role.approleid);

            dbList.rolename = role.rolename;

            db.SaveChanges();
        }

        public void deleteRole(approle role)
        {
            db.approles.Remove(role);
            db.SaveChanges();
        }

        public approle GetRole(int id)
        {
            return db.approles.SingleOrDefault(role => role.approleid == id);
        }

        public approle GetRole(string name)
        {
            return db.approles.SingleOrDefault(role => role.rolename == name);
        }
    }
}
