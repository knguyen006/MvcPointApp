using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class SignupMgr : Manager
    {
        public ISignupSvc svc;

        public SignupMgr()
        {
            svc = (ISignupSvc)GetService(typeof(ISignupSvc).Name);
        }


        public void Create(signup sign)
        {
            svc.addSignup(sign);
        }

        public void Update(signup sign)
        {
            svc.editSignup(sign);
        }

        public void Delete(signup sign)
        {
            svc.deleteSignup(sign);
        }


        public signup Retrieved(int id)
        {
            signup db = svc.GetAll(id);

            return db;
        }


    }
}
