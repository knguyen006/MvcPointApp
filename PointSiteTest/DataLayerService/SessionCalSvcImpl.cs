using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class SessioncalSvcImpl: Repository<sessioncal>, ISessioncalSvc
    {
        public SessioncalSvcImpl(PointAppDBContext context)
            : base(context)
        {
        }
    }
}
