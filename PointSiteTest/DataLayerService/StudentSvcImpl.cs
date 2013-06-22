using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class StudentSvcImpl: IStudentSvc
    {
        PointAppDBContext db = new PointAppDBContext();

        public void addStudent(student act)
        {
            db.students.Add(act);
            db.SaveChanges();
        }

        public student GetAll(int id)
        {
            student act = (from d in db.students
                            where d.studentid == id
                            select d).Single();

            return act;
        }

        public void editStudent(student act)
        {
            var dbList = db.students.Single(p => p.studentid == act.studentid);

            dbList.firstname = act.firstname;
            dbList.lastname = act.lastname;
            dbList.middlename = act.middlename;
            dbList.grade = act.grade;
            dbList.active = act.active;

            db.SaveChanges();
        }

        public void deleteStudent(student act)
        {
            db.students.Remove(act);
            db.SaveChanges();
        }
    }
}
