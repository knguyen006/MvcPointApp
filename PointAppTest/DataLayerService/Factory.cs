using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayerService.Exceptions;

namespace DataLayerService
{
    public class Factory
    {
        private Factory() { }
        private static Factory factory = new Factory();
        public static Factory GetInstance() { return factory; }

        public IService GetService(string serviceName)
        {
            
            Type type;
            Object obj = null;
            try
            {
                type = Type.GetType(GetImplName(serviceName));
                obj = Activator.CreateInstance(type, args);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: {0}", e);
                throw e;
            }
            return (IService)obj;

            /*
            Object c = Activator.CreateInstance(Type.GetType(GetImplName(serviceName), true));
            return (IService)c;
             */
        }

        private string GetImplName(string servicename)
        {
            NameValueCollection settings = ConfigurationManager.AppSettings;
            /*
            try
            {
                String implementname = settings.Get(servicename);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw new ServiceNotFoundException("Unable to find implement for service name " + servicename);
            }
            */
            return settings.Get(servicename);
        }
    }
}
