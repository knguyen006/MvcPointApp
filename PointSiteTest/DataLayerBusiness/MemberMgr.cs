using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayerService;
using DataLayer;

namespace DaLayerBusiness
{
    public class MemberMgr
    {
        PointAppFactory factory = PointAppFactory.GetInstance();

        public void Create(member act)
        {

            try
            {
                IMemberSvc memberSvc = (IMemberSvc)factory.GetMember("IMemberSvc");
                memberSvc.AddMember(act);
            }
            catch
            {
                throw new ArgumentException("Cannot add record!");
            }
        }

        /*
        public member Find(int newid)
        {

        }
         */

        public void Update(member act)
        {
            try
            {
                IMemberSvc memberSvc = (IMemberSvc)factory.GetMember("IMemberSvc");
                memberSvc.UpdateMember(act);
            }
            catch
            {
                throw new ArgumentException("Cannot update record");
            }
        }

        public void Delete(member act)
        {
            try
            {
                IMemberSvc memberSvc = (IMemberSvc)factory.GetMember("IMemberSvc");
                memberSvc.DeleteMember(act);
            }
            catch
            {
                throw new ArgumentException("Cannot delete record");
            }
        }
    }
}