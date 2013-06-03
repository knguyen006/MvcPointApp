using System;
namespace DataLayer
{
    interface ISessioncal
    {
        decimal? sessionamt { get; set; }
        int sessioncalid { get; set; }
        DateTime? sessiondate { get; set; }
        int? sessionnum { get; set; }
        int? sessionpoint { get; set; }
        sessiontype sessiontype { get; set; }
        int? sessiontypeid { get; set; }
        System.Collections.Generic.ICollection<signup> signups { get; set; }
    }
}
