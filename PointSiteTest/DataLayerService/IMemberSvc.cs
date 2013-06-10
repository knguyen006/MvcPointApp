using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;

/// <summary>
/// Summary description for IMember
/// </summary>
namespace DataLayerService
{
    public interface IMemberSvc
    {
        member Find(int memberid);
        IEnumerable<member> GetAll();
        void AddMember(member newmember);
        void UpdateMember(member newmember);
        void DeleteMember(member newmember);
        void Dispose();
    }
}
