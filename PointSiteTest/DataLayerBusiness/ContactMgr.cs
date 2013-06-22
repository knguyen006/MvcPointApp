using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class ContactMgr : Manager
    {
        public IContactSvc svc;

        public ContactMgr()
        {
            svc = (IContactSvc)GetService(typeof(IContactSvc).Name);
        }


        public void Create(contact act)
        {
            svc.addContact(act);
        }

        public void Update(contact act)
        {
            svc.editContact(act);
        }

        public void Delete(contact act)
        {
            svc.deleteContact(act);
        }


        public contact Retrieved(int id)
        {
            contact db = svc.GetAll(id);

            return db;
        }



    }
}
