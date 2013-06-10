using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;

/// <summary>
/// Summary description
/// </summary>
namespace DataLayerService
{
    public interface IFeeRequestSvc
    {
        feerequest Find(int feerequestid);
        IEnumerable<feerequest> GetAll();
        void AddRequest(feerequest newrequest);
        void UpdateRequest(feerequest newrequest);
        void DeleteRequest(feerequest newrequest);
        void Dispose();
    }
}
