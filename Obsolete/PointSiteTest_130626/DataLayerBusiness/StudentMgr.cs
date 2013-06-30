using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;
using DataLayer;

namespace DataLayerBusiness
{
    public class StudentMgr : Manager
    {
        public IStudentSvc svc;

        public StudentMgr()
        {
            svc = (IStudentSvc)GetService(typeof(IStudentSvc).Name);
        }


        public void Create(student stu)
        {
            svc.addStudent(stu);
        }

        public void Update(student stu)
        {
            svc.editStudent(stu);
        }

        public void Delete(student stu)
        {
            svc.deleteStudent(stu);
        }


        public student Retrieved(int id)
        {
            return svc.GetById(id);
        }

        public List<student> GetList()
        {
            return svc.GetAll();
        }
    }
}
