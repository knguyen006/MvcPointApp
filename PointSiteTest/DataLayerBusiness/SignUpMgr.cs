using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayerService;
using DataLayer;

namespace DaLayerBusiness
{
    public class SignUpMgr
    {
        PointAppFactory factory = PointAppFactory.GetInstance();

        public void Create(signup signup)
        {

            try
            {
                ISignUpSvc signupSvc = (ISignUpSvc)factory.GetSignUp("ISignUpSvc");
                signupSvc.AddSignUp(signup);
            }
            catch
            {
                throw new ArgumentException("Cannot add record!");
            }
        }

        /*
        public signup Find(int newid)
        {

        }
         */

        public void Update(signup signup)
        {
            try
            {
                ISignUpSvc signupSvc = (ISignUpSvc)factory.GetSignUp("ISignUpSvc");
                signupSvc.UpdateSignUp(signup);
            }
            catch
            {
                throw new ArgumentException("Cannot update record");
            }
        }

        public void Delete(signup signup)
        {
            try
            {
                ISignUpSvc signupSvc = (ISignUpSvc)factory.GetSignUp("ISignUpSvc");
                signupSvc.DeleteSignUp(signup);
            }
            catch
            {
                throw new ArgumentException("Cannot delete record");
            }
        }
    }
}