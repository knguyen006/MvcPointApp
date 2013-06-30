using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class FamilySvcImpl: IFamilySvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addName(family name)
        {
            db.families.Add(name);
            db.SaveChanges();
        }

        public family GetById(int id)
        {
            return db.families.Find(id);
        }

        public List<family> GetAll()
        {
            return db.families.ToList();
        }

        public void editName(family name)
        {
            var dbList = db.families.Single(p => p.familyid == name.familyid);

            dbList.familyname = name.familyname;

            db.SaveChanges();
        }

        public void deleteName(family name)
        {
            db.families.Remove(name);
            db.SaveChanges();
        }
    }
}
