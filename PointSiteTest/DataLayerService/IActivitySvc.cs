using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;

/// <summary>
/// Summary description for IActivity
/// </summary>
namespace DataLayerService
{
    public interface IActivitySvc
    {
        activity Find(int activityid);
        IEnumerable<activity> GetAll();
        void AddAct(activity newact);
        void UpdateAct(activity newact);
        void DeleteAct(activity newact);
        void Dispose();

    }


}
