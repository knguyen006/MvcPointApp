using System;
namespace DataLayer
{
    interface ISignup
    {
        string isshow { get; set; }
        member member { get; set; }
        int? memberid { get; set; }
        int? pointearn { get; set; }
        sessioncal sessioncal { get; set; }
        int? sessioncalid { get; set; }
        int signupid { get; set; }
    }
}
