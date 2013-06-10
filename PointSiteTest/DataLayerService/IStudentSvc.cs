using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;
using System.Configuration;

/// <summary>
/// Summary description for IStudent
/// </summary>
namespace DataLayerService
{
    public interface IStudentSvc
    {
        student Find(int studentid);
        IEnumerable<student> GetAll();
        void AddStudent(student newstudent);
        void UpdateStudent(student newstudent);
        void DeleteStudent(student newstudent);
        void Dispose();
    }
}
