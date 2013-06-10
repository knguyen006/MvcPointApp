using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Configuration;

/// <summary>
/// Summary description
/// </summary>
namespace DataLayerService
{
    public class StudentSvcImpl : IStudentSvc
    {
        private PointAppDBContainer db = new PointAppDBContainer();

        public StudentSvcImpl(PointAppDBContainer db)
        {
            this.db = db;
        }

        public student Find(int studentid)
        {
            return db.students.Find(studentid);
        }

        public IEnumerable<student> GetAll()
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
            student studentToUpdate = db.students.Attach(newstudent);
            db.Entry(newstudent).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteStudent(student newstudent)
        {
            db.students.Attach(newstudent);
            db.students.Remove(newstudent);
            db.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
