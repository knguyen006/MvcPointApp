using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class ContactemailMgr : Manager
    {
        public IContactemailSvc svc;

        public ContactemailMgr()
        {
            svc = (IContactemailSvc)GetService(typeof(IContactemailSvc).Name);
        }


        public void Create(contactemail email)
        {
            svc.addEmail(email);
        }

        public void Update(contactemail email)
        {
            svc.editEmail(email);
        }

        public void Delete(contactemail email)
        {
            svc.deleteEmail(email);
        }


        public contactemail Retrieved(int id)
        {
            return svc.GetById(id);
        }

        public List<contactemail> GetList()
        {
            return svc.GetAll();
        }
    }
}
