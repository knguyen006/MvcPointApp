using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class StudentMgr
    {
        public PointAppDBContext context;

        Factory factory = Factory.GetInstance();

        public StudentMgr()
        {
            this.context = new PointAppDBContext();
        }

        public StudentMgr(PointAppDBContext dbContext)
        {
            this.context = dbContext;
        }

        public void Create(student newstudent)
        {
            IStudentSvc studentSvc = (IStudentSvc)factory.GetService("IStudentSvc", context);

            studentSvc.Insert(newstudent);
            studentSvc.Save();
        }

        public void Update(student newstudent)
        {
            IStudentSvc studentSvc = (IStudentSvc)factory.GetService("IStudentSvc", context);

            studentSvc.Update(newstudent);
            studentSvc.Save();
        }

        public void Delete(student newstudent)
        {
            IStudentSvc studentSvc = (IStudentSvc)factory.GetService("IStudentSvc", context);

            studentSvc.Delete(newstudent);
            studentSvc.Save();
        }

        public student Find(int id)
        {
            IStudentSvc studentSvc = (IStudentSvc)factory.GetService("IStudentSvc", context);

            return studentSvc.GetById(id);
        }

        public IEnumerable<student> GetStudent()
        {
            IStudentSvc studentSvc = (IStudentSvc)factory.GetService("IStudentSvc", context);

            return studentSvc.GetAll();
        }


    }
}
