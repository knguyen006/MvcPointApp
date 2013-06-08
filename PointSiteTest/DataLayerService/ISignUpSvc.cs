using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;

/// <summary>
/// Summary description for ISignUp
/// </summary>
namespace DataLayerService
{
    public interface ISignUpSvc
    {
        signup Find(int signupid);
        List<signup> GetAll();
        void AddSignUp(signup newsignup);
        void UpdateSignUp(signup newsignup);
        void DeleteSignUp(signup newsignup);
    }
}
