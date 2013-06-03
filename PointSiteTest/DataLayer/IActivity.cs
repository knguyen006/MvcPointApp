using System;
namespace DataLayer
{
    interface IActivity
    {
        int activityid { get; set; }
        string actname { get; set; }
        System.Collections.Generic.ICollection<member> members { get; set; }
    }
}
