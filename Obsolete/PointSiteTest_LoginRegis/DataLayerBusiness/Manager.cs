using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService;

namespace DataLayerBusiness
{
    public abstract class Manager
    {
        private Factory factory = Factory.GetInstance();

        protected IService GetService(String name)
        {
            return factory.GetService(name);
        }
    }
}
