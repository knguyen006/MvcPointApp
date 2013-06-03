using System;
namespace DataLayer
{
    interface IFeerequest
    {
        int feerequestid { get; set; }
        member member { get; set; }
        int? memberid { get; set; }
        int? pointbal { get; set; }
        decimal? requestamt { get; set; }
        DateTime? requestdate { get; set; }

    }
}
