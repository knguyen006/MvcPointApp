using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class MemberSvcImpl: Repository<member>, IMemberSvc
    {
        public MemberSvcImpl(PointAppDBContext context)
            : base(context)
        {
        }
    }
}
