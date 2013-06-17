using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class FeerequestSvcImpl: Repository<feerequest>, IFeerequestSvc
    {
        public FeerequestSvcImpl(PointAppDBContext context)
            : base(context)
        {
        }
    }
}
