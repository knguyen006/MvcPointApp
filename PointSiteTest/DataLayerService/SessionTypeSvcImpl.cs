using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class SessiontypeSvcImpl: ISessiontypeSvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addSessiontype(sessiontype type)
        {
            db.sessiontypes.Add(type);
            db.SaveChanges();
        }

        public sessiontype GetAll(int id)
        {
            sessiontype type = (from d in db.sessiontypes
                            where d.sessiontypeid == id
                            select d).Single();

            return type;
        }

        public void editSessiontype(sessiontype type)
        {
            var dbList = db.sessiontypes.Single(p => p.sessiontypeid == type.sessiontypeid);

            dbList.typename = type.typename;

            db.SaveChanges();
        }

        public void deleteSessiontype(sessiontype type)
        {
            db.sessiontypes.Remove(type);
            db.SaveChanges();
        }
    }
}
