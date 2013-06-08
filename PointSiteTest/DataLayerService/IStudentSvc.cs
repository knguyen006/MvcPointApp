using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;

/// <summary>
/// Summary description for IStudent
/// </summary>
namespace DataLayerService
{
    public interface IStudentSvc
    {
        student Find(int studentid);
        List<student> GetAll();
        void AddStudent(student newstudent);
        void UpdateStudent(student newstudent);
        void DeleteStudent(student newstudent);
    }
}
