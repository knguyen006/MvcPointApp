using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;

/// <summary>
/// Summary description for IActivity
/// </summary>
namespace DataLayerService
{
    public interface IAppRoleSvc
    {
        approle Find(int approleid);
        IEnumerable<approle> GetAll();
        void AddRole(approle newrole);
        void UpdateRole(approle newrole);
        void DeleteRole(approle newrole);
        void Dispose();
    }
}
