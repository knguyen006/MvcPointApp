using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class StudentSvcImpl: Repository<student>, IStudentSvc
    {
        public StudentSvcImpl(PointAppDBContext context)
            : base(context)
        {
        }
    }
}
