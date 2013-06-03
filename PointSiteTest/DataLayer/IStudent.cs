using System;
namespace DataLayer
{
    interface IStudent
    {
        string active { get; set; }
        string firstname { get; set; }
        int? grade { get; set; }
        string lastname { get; set; }
        System.Collections.Generic.ICollection<member> members { get; set; }
        string middlename { get; set; }
        int studentid { get; set; }
    }
}
