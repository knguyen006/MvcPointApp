using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class MemberMgr
    {
        public PointAppDBContext context;

        Factory factory = Factory.GetInstance();

        public MemberMgr()
        {
            this.context = new PointAppDBContext();
        }

        public MemberMgr(PointAppDBContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(member member)
        {
            IMemberSvc memberSvc = (IMemberSvc)factory.GetService("IMemberSvc", context);

            memberSvc.Insert(member);
            memberSvc.Save();
        }

        public void Update(member member)
        {
            IMemberSvc memberSvc = (IMemberSvc)factory.GetService("IMemberSvc", context);

            memberSvc.Update(member);
            memberSvc.Save();
        }

        public void Delete(member member)
        {
            IMemberSvc memberSvc = (IMemberSvc)factory.GetService("IMemberSvc", context);

            memberSvc.Delete(member);
            memberSvc.Save();
        }

        public member Find(int id)
        {
            IMemberSvc memberSvc = (IMemberSvc)factory.GetService("IMemberSvc", context);

            return memberSvc.GetById(id);
        }

        public IEnumerable<member> GetMember()
        {
            IMemberSvc memberSvc = (IMemberSvc)factory.GetService("IMemberSvc", context);

            return memberSvc.GetAll();
        }

    }
}
