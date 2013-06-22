using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerService.Exceptions
{
    public class ServiceNotFoundException : Exception
    {
        public ServiceNotFoundException(String s)
            : base(s)
        {
        }
    }
}
