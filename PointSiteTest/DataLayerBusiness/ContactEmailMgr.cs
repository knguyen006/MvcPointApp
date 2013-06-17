using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class ContactemailMgr
    {
        public PointAppDBContext context;

        Factory factory = Factory.GetInstance();

        public ContactemailMgr()
        {
            this.context = new PointAppDBContext();
        }

        public ContactemailMgr(PointAppDBContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(contactemail act)
        {
            IContactemailSvc emailSvc = (IContactemailSvc)factory.GetService("IContactemailSvc", context);

            emailSvc.Insert(act);
            emailSvc.Save();
        }

        public void Update(contactemail act)
        {
            IContactemailSvc emailSvc = (IContactemailSvc)factory.GetService("IContactemailSvc", context);

            emailSvc.Update(act);
            emailSvc.Save();
        }

        public void Delete(contactemail act)
        {
            IContactemailSvc emailSvc = (IContactemailSvc)factory.GetService("IContactemailSvc", context);

            emailSvc.Delete(act);
            emailSvc.Save();
        }

        public contactemail Find(int id)
        {
            IContactemailSvc emailSvc = (IContactemailSvc)factory.GetService("IContactemailSvc", context);

            return emailSvc.GetById(id);
        }

        public IEnumerable<contactemail> GetContactemail()
        {
            IContactemailSvc emailSvc = (IContactemailSvc)factory.GetService("IContactemailSvc", context);

            return emailSvc.GetAll();
        }


    }
}
