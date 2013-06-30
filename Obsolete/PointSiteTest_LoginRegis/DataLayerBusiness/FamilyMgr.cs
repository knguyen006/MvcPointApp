using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class FamilyMgr : Manager
    {
        public IFamilySvc svc;

        public FamilyMgr()
        {
            svc = (IFamilySvc)GetService(typeof(IFamilySvc).Name);
        }


        public void Create(family fam)
        {
            svc.addName(fam);
        }

        public void Update(family fam)
        {
            svc.editName(fam);
        }

        public void Delete(family fam)
        {
            svc.deleteName(fam);
        }


        public family Retrieved(int id)
        {
            return svc.GetById(id);
        }

        public List<family> GetList()
        {
            return svc.GetAll();
        }
    }
}
