using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class SessiontypeMgr
    {
        public PointAppDBContext context;

        Factory factory = Factory.GetInstance();

        public SessiontypeMgr()
        {
            this.context = new PointAppDBContext();
        }

        public SessiontypeMgr(PointAppDBContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(sessiontype type)
        {
            ISessiontypeSvc typeSvc = (ISessiontypeSvc)factory.GetService("ISessiontypeSvc", context);

            typeSvc.Insert(type);
            typeSvc.Save();
        }

        public void Update(sessiontype type)
        {
            ISessiontypeSvc typeSvc = (ISessiontypeSvc)factory.GetService("ISessiontypeSvc", context);

            typeSvc.Update(type);
            typeSvc.Save();
        }

        public void Delete(sessiontype type)
        {
            ISessiontypeSvc typeSvc = (ISessiontypeSvc)factory.GetService("ISessiontypeSvc", context);

            typeSvc.Delete(type);
            typeSvc.Save();
        }

        public sessiontype Find(int id)
        {
            ISessiontypeSvc typeSvc = (ISessiontypeSvc)factory.GetService("ISessiontypeSvc", context);

            return typeSvc.GetById(id);
        }

        public IEnumerable<sessiontype> GetSessiontype()
        {
            ISessiontypeSvc typeSvc = (ISessiontypeSvc)factory.GetService("ISessiontypeSvc", context);

            return typeSvc.GetAll();
        }


    }
}
