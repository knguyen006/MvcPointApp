using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;

/// <summary>
/// Summary description for IActivity
/// </summary>
namespace DataLayerService
{
    public interface ISessionTypeSvc
    {
        sessiontype Find(int sessiontypeid);
        IEnumerable<sessiontype> GetAll();
        void AddSessionType(sessiontype newsessiontype);
        void UpdateSessionType(sessiontype newsessiontype);
        void DeleteSessionType(sessiontype newsessiontype);
        void Dispose();
    }
}
