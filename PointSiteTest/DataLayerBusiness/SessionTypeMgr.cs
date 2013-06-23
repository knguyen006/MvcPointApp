using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class SessiontypeMgr : Manager
    {
        public ISessiontypeSvc svc;

        public SessiontypeMgr()
        {
            svc = (ISessiontypeSvc)GetService(typeof(ISessiontypeSvc).Name);
        }


        public void Create(sessiontype type)
        {
            svc.addSessiontype(type);
        }

        public void Update(sessiontype type)
        {
            svc.editSessiontype(type);
        }

        public void Delete(sessiontype type)
        {
            svc.deleteSessiontype(type);
        }


        public sessiontype Retrieved(int id)
        {
            return svc.GetById(id);
        }

        public List<sessiontype> GetList()
        {
            return svc.GetAll();
        }
    }
}
