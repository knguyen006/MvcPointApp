using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class MemberMgr : Manager
    {
        public IMemberSvc svc;

        public MemberMgr()
        {
            svc = (IMemberSvc)GetService(typeof(IMemberSvc).Name);
        }


        public void Create(member mem)
        {
            svc.addMember(mem);
        }

        public void Update(member mem)
        {
            svc.editMember(mem);
        }

        public void Delete(member mem)
        {
            svc.deleteMember(mem);
        }

        public member Retrieved(int id)
        {
            return svc.GetById(id);
        }

        public List<member> GetList()
        {
            return svc.GetAll();
        }

        public List<member> GetAccount(member mem)
        {
            return svc.GetAccount(mem).ToList();
        }

        public bool UserIsValid(string nuser, string npass)
        {
            return svc.UserIsValid(nuser, npass);
        }

        public member GetAdminUser()
        {
            return svc.GetAdminUser();
        }
    }
}
