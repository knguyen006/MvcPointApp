using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class ContactSvcImpl: Repository<contact>, IContactSvc
    {
        public ContactSvcImpl(PointAppDBContext context)
            : base(context)
        {
        }
    }
}
