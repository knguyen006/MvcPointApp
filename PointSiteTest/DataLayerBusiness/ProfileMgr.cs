using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class ProfileMgr : Manager
    {
        public IProfileSvc svc;

        public ProfileMgr()
        {
            svc = (IProfileSvc)GetService(typeof(IProfileSvc).Name);
        }


        public void Create(profile pro)
        {
            svc.addProfile(pro);
        }

        public void Update(profile pro)
        {
            svc.editProfile(pro);
        }

        public void Delete(profile pro)
        {
            svc.deleteProfile(pro);
        }


        public profile Retrieved(int id)
        {
            return svc.GetById(id);
        }

        public List<profile> GetList()
        {
            return svc.GetAll();
        }
    }
}
