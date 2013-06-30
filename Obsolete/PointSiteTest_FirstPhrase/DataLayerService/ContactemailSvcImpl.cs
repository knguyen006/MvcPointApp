using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class ContactemailSvcImpl: IContactemailSvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addEmail(contactemail email)
        {
            db.contactemails.Add(email);
            db.SaveChanges();
        }

        public contactemail GetById(int id)
        {
            return db.contactemails.Find(id);
        }

        public List<contactemail> GetAll()
        {
            return db.contactemails.ToList();
        }

        public void editEmail(contactemail email)
        {
            var dbList = db.contactemails.Single(p => p.contactemailid == email.contactemailid);

            dbList.contactid = email.contactid;
            dbList.emailaddress = email.emailaddress;

            db.SaveChanges();
        }

        public void deleteEmail(contactemail email)
        {
            db.contactemails.Remove(email);
            db.SaveChanges();
        }
    }
}
