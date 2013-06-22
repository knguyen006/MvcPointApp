using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public interface IStudentSvc : IService
    {
        void addStudent(student stu);
        student GetAll(int id);
        void editStudent(student stu);
        void deleteStudent(student stu);
    }
}
