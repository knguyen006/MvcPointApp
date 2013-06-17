using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class ContactMgr
    {
        public PointAppDBContext context;

        Factory factory = Factory.GetInstance();

        public ContactMgr()
        {
            this.context = new PointAppDBContext();
        }

        public ContactMgr(PointAppDBContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(contact newcontact)
        {
            IContactSvc contactSvc = (IContactSvc)factory.GetService("IContactSvc", context);

            contactSvc.Insert(newcontact);
            contactSvc.Save();
        }

        public void Update(contact newcontact)
        {
            IContactSvc contactSvc = (IContactSvc)factory.GetService("IContactSvc", context);

            contactSvc.Update(newcontact);
            contactSvc.Save();
        }

        public void Delete(contact newcontact)
        {
            IContactSvc contactSvc = (IContactSvc)factory.GetService("IContactSvc", context);

            contactSvc.Delete(newcontact);
            contactSvc.Save();
        }

        public contact Find(int id)
        {
            IContactSvc contactSvc = (IContactSvc)factory.GetService("IContactSvc", context);

            return contactSvc.GetById(id);
        }

        public IEnumerable<contact> GetContact()
        {
            IContactSvc contactSvc = (IContactSvc)factory.GetService("IContactSvc", context);

            return contactSvc.GetAll();
        }


    }
}
