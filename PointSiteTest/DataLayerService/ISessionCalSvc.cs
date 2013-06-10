using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;

/// <summary>
/// Summary description for ISessionCal
/// </summary>
namespace DataLayerService
{
    public interface ISessionCalSvc
    {
        sessioncal Find(int sessioncalid);
        IEnumerable<sessioncal> GetAll();
        void AddSessionCal(sessioncal newsessioncal);
        void UpdateSessionCal(sessioncal newsessioncal);
        void DeleteSessionCal(sessioncal newsessioncal);
        void Dispose();
    }
}
