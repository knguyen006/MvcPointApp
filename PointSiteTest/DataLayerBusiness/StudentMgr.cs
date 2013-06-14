using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataLayerService;
using DataLayer;

namespace DaLayerBusiness
{
    public class StudentMgr
    {
        PointAppFactory factory = PointAppFactory.GetInstance();

        public void Create(student student)
        {

            try
            {
                IStudentSvc studentSvc = (IStudentSvc)factory.GetStudent("IStudentSvc");
                studentSvc.AddStudent(student);
            }
            catch
            {
                throw new ArgumentException("Cannot add record!");
            }
        }

        /*
        public student Find(int newid)
        {

        }
         */

        public void Update(student student)
        {
            try
            {
                IStudentSvc studentSvc = (IStudentSvc)factory.GetStudent("IStudentSvc");
                studentSvc.UpdateStudent(student);
            }
            catch
            {
                throw new ArgumentException("Cannot update record");
            }
        }

        public void Delete(student student)
        {
            try
            {
                IStudentSvc studentSvc = (IStudentSvc)factory.GetStudent("IStudentSvc");
                studentSvc.DeleteStudent(student);
            }
            catch
            {
                throw new ArgumentException("Cannot delete record");
            }
        }
    }
}