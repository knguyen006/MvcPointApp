using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class ApproleMgr
    {
        public PointAppDBContext context;

        Factory factory = Factory.GetInstance();

        public ApproleMgr()
        {
            this.context = new PointAppDBContext();
        }

        public ApproleMgr(PointAppDBContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(approle role)
        {
            IApproleSvc roleSvc = (IApproleSvc)factory.GetService("IApproleSvc", context);

            roleSvc.Insert(role);
            roleSvc.Save();
        }

        public void Update(approle role)
        {
            IApproleSvc roleSvc = (IApproleSvc)factory.GetService("IApproleSvc", context);

            roleSvc.Update(role);
            roleSvc.Save();
        }

        public void Delete(approle role)
        {
            IApproleSvc roleSvc = (IApproleSvc)factory.GetService("IApproleSvc", context);

            roleSvc.Delete(role);
            roleSvc.Save();
        }

        public approle Find(int id)
        {
            IApproleSvc roleSvc = (IApproleSvc)factory.GetService("IApproleSvc", context);

            return roleSvc.GetById(id);
        }

        public IEnumerable<approle> GetApprole()
        {
            IApproleSvc roleSvc = (IApproleSvc)factory.GetService("IApproleSvc", context);

            return roleSvc.GetAll();
        }


    }
}
