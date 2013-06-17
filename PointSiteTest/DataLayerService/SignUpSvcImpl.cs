using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace DataLayerService
{
    public class SignupSvcImpl: Repository<signup>, ISignupSvc
    {
        public SignupSvcImpl(PointAppDBContext context)
            : base(context)
        {
        }
    }
}
