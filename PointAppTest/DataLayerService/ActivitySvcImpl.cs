using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class ActivitySvcImpl : Repository<activity>, IActivitySvc
    {
        public ActivitySvcImpl(PointAppDBContext context)
            : base(context)
        { }

    } 
}
