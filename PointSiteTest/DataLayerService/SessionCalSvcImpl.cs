using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class SessioncalSvcImpl: ISessioncalSvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addSessioncal(sessioncal cal)
        {
            db.sessioncals.Add(cal);
            db.SaveChanges();
        }

        public sessioncal GetAll(int id)
        {
            sessioncal cal = (from d in db.sessioncals
                                where d.sessioncalid == id
                                select d).Single();

            return cal;
        }

        public void editSessioncal(sessioncal cal)
        {
            var dbList = db.sessioncals.Single(p => p.sessioncalid == cal.sessioncalid);

            dbList.sessiondate = cal.sessiondate;
            dbList.sessiontypeid = cal.sessiontypeid;
            dbList.sessionnum = cal.sessionnum;
            dbList.sessionamt = cal.sessionamt;
            dbList.sessionpoint = cal.sessionpoint;

            db.SaveChanges();
        }

        public void deleteSessioncal(sessioncal cal)
        {
            db.sessioncals.Remove(cal);
            db.SaveChanges();
        }
    }
}
