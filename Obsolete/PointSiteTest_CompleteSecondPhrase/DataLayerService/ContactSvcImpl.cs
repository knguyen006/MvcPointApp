using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class ContactSvcImpl: IContactSvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addContact(contact con)
        {
            db.contacts.Add(con);
            db.SaveChanges();
        }

        public contact GetById(int id)
        {
            return db.contacts.Find(id);
        }

        public List<contact> GetAll()
        {
            return db.contacts.ToList();
        }

        public void editContact(contact con)
        {
            var dbList = db.contacts.Single(p => p.contactid == con.contactid);

            dbList.firstname = con.firstname;
            dbList.lastname = con.firstname;
            dbList.middlename = con.middlename;
            dbList.address = con.address;
            dbList.altaddress = con.altaddress;
            dbList.city = con.city;
            dbList.state = con.state;
            dbList.zip = con.zip;
            dbList.homephone = con.homephone;
            dbList.workphone = con.workphone;
            dbList.mobilephone = con.mobilephone;
             
            db.SaveChanges();
        }

        public void deleteContact(contact con)
        {
            db.contacts.Remove(con);
            db.SaveChanges();
        }
    }
}
