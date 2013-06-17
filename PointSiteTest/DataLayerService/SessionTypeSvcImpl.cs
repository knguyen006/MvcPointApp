using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class SessiontypeSvcImpl: Repository<sessiontype>, ISessiontypeSvc
    {
        public SessiontypeSvcImpl(PointAppDBContext context)
            : base(context)
        {
        }
    }
}
