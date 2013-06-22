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

        public approle GetAll(int id)
        {
            approle role = (from d in db.approles
                            where d.approleid == id
                            select d).Single();

            return role;
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
    }
}
