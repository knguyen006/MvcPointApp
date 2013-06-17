using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class SignupMgr
    {
        public PointAppDBContext context;

        Factory factory = Factory.GetInstance();

        public SignupMgr()
        {
            this.context = new PointAppDBContext();
        }

        public SignupMgr(PointAppDBContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(signup newsign)
        {
            ISignupSvc newsignSvc = (ISignupSvc)factory.GetService("ISignupSvc", context);

            newsignSvc.Insert(newsign);
            newsignSvc.Save();
        }

        public void Update(signup newsign)
        {
            ISignupSvc newsignSvc = (ISignupSvc)factory.GetService("ISignupSvc", context);

            newsignSvc.Update(newsign);
            newsignSvc.Save();
        }

        public void Delete(signup newsign)
        {
            ISignupSvc newsignSvc = (ISignupSvc)factory.GetService("ISignupSvc", context);

            newsignSvc.Delete(newsign);
            newsignSvc.Save();
        }

        public signup Find(int id)
        {
            ISignupSvc newsignSvc = (ISignupSvc)factory.GetService("ISignupSvc", context);

            return newsignSvc.GetById(id);
        }

        public IEnumerable<signup> GetSignup()
        {
            ISignupSvc newsignSvc = (ISignupSvc)factory.GetService("ISignupSvc", context);

            return newsignSvc.GetAll();
        }


    }
}
