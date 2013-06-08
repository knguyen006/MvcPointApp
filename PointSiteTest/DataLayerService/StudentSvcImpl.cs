using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;
using System.Data.Entity;
using System.Data;
using System.Linq;

/// <summary>
/// Summary description
/// </summary>
namespace DataLayerService
{
    public class StudentSvcImpl : IStudentSvc
    {
        private PointAppDBContainer db = new PointAppDBContainer();

        public student Find(int studentid)
        {
            return db.students.Find(studentid);
        }

        public List<student> GetAll()
        {
            return db.students.ToList();
        }

        public void AddStudent(student newstudent)
        {
            db.students.Add(newstudent);
            db.SaveChanges();
        }

        public void UpdateStudent(student newstudent)
        {
            db.Entry(newstudent).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteStudent(student newstudent)
        {
            db.students.Remove(newstudent);
            db.SaveChanges();
        }
    }
}
