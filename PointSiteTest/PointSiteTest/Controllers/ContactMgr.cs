using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayerService;
using DataLayer;

namespace PointSiteTest.Controllers
{
    public class ContactMgr
    {
        PointAppFactory factory = PointAppFactory.GetInstance();

        public void Create(contact contact)
        {

            try
            {
                IContactSvc contactSvc = (IContactSvc)factory.GetContact("IContactSvc");
                contactSvc.AddContact(contact);
            }
            catch
            {
                throw new ArgumentException("Cannot add record!");
            }
        }

        /*
        public contact Find(int newid)
        {
          
        }
         */

        public void Update(contact contact)
        {
            try
            {
                IContactSvc contactSvc = (IContactSvc)factory.GetContact("IContactSvc");
                contactSvc.UpdateContact(contact);
            }
            catch
            {
                throw new ArgumentException("Cannot update record");
            }
        }

        public void Delete(contact contact)
        {
            try
            {
                IContactSvc contactSvc = (IContactSvc)factory.GetContact("IContactSvc");
                contactSvc.DeleteContact(contact);
            }
            catch
            {
                throw new ArgumentException("Cannot delete record");
            }
        }
    }
}