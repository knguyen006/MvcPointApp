using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayerService;
using DataLayer;

namespace PointSiteTest.Controllers
{
    public class ContactEmailMgr
    {
        PointAppFactory factory = PointAppFactory.GetInstance();

        public void Create(contactemail email)
        {

            try
            {
                IContactEmailSvc emailSvc = (IContactEmailSvc)factory.GetContactEmail("IContactEmailSvc");
                emailSvc.AddEmail(email);
            }
            catch
            {
                throw new ArgumentException("Cannot add record!");
            }
        }

        /*
        public ContactEmail Find(int newid)
        {
            I don't know how to write this code.
        }
         */

        public void Update(contactemail email)
        {
            try
            {
                IContactEmailSvc emailSvc = (IContactEmailSvc)factory.GetContactEmail("IContactEmailSvc");
                emailSvc.UpdateEmail(email);
            }
            catch
            {
                throw new ArgumentException("Cannot update record");
            }
        }

        public void Delete(contactemail email)
        {
            try
            {
                IContactEmailSvc emailSvc = (IContactEmailSvc)factory.GetContactEmail("IContactEmailSvc");
                emailSvc.DeleteEmail(email);
            }
            catch
            {
                throw new ArgumentException("Cannot delete record");
            }
        }
    }
}