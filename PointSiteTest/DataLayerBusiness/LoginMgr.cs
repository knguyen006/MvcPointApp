using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayerService;

namespace DataLayerBusiness
{
    public class LoginMgr: Manager
    {
        public ILoginSvc svc;

        public LoginMgr()
        {
            svc = (ILoginSvc)GetService(typeof(ILoginSvc).Name);
        }

        public List<member> GetAccount(member mem)
        {
            return svc.GetAccount(mem);
        }

        public member authenticateLogin(member mem)
        {
            member result = null;
            List<member> loginList = svc.GetAccount(mem);

            foreach (member templogin in loginList)
            {
                if(templogin.userpass == mem.userpass)
                    result = templogin;
            }

            return result;
        }

        /*
        public bool UserIsValid(string nuser, string npass)
        {
            return svc.UserIsValid(nuser, npass);
        }
         */
    }
}
