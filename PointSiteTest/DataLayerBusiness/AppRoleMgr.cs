using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class ApproleMgr : Manager
    {
        public IApproleSvc svc;

        public ApproleMgr()
        {
            svc = (IApproleSvc)GetService(typeof(IApproleSvc).Name);
        }


        public void Create(approle act)
        {
            svc.addRole(act);
        }

        public void Update(approle act)
        {
            svc.editRole(act);
        }

        public void Delete(approle act)
        {
            svc.deleteRole(act);
        }

        public approle Retrieved(int id)
        {
            return svc.GetById(id);
        }

        public List<approle> GetList()
        {
            return svc.GetAll();
        }

    }
}
