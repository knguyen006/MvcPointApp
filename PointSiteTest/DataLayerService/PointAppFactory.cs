using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using System.Configuration;
using System.Collections.Specialized;

namespace DataLayerService
{
    public class PointAppFactory
    {

        Type type;
        Object obj = null;

        private static PointAppFactory factory = new PointAppFactory();

        public static PointAppFactory GetInstance()
        {
            return factory;
        }

        private String GetImplName(String svcName)
        {
            NameValueCollection settings = ConfigurationManager.AppSettings;
            return settings.Get(svcName);
        }
        public IActivitySvc GetActivity(String svcName)
        {
            try
            {
                type = Type.GetType(GetImplName(svcName));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid service.", e);
            }

            return (IActivitySvc)obj;
        }

        public IStudentSvc GetStudent(String svcName)
        {
            try
            {
                type = Type.GetType(GetImplName(svcName));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid service.", e);
            }

            return (IStudentSvc)obj;
        }

        public IMemberSvc GetMember(String svcName)
        {
            try
            {
                type = Type.GetType(GetImplName(svcName));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid service.", e);
            }

            return (IMemberSvc)obj;
        }

        public IContactSvc GetContact(String svcName)
        {
            try
            {
                type = Type.GetType(GetImplName(svcName));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid service.", e);
            }

            return (IContactSvc)obj;
        }

        public IContactEmailSvc GetContactEmail(String svcName)
        {
            try
            {
                type = Type.GetType(GetImplName(svcName));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid service.", e);
            }

            return (IContactEmailSvc)obj;
        }

        public ISignUpSvc GetSignUp(String svcName)
        {
            try
            {
                type = Type.GetType(GetImplName(svcName));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid service.", e);
            }

            return (ISignUpSvc)obj;
        }

        public IFeeRequestSvc GetFeeRequest(String svcName)
        {
            try
            {
                type = Type.GetType(GetImplName(svcName));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid service.", e);
            }

            return (IFeeRequestSvc)obj;
        }

        public ISessionCalSvc GetSessionCal(String svcName)
        {
            try
            {
                type = Type.GetType(GetImplName(svcName));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid service.", e);
            }

            return (ISessionCalSvc)obj;
        }

        public ISessionTypeSvc GetSessionType(String svcName)
        {
            try
            {
                type = Type.GetType(GetImplName(svcName));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid service.", e);
            }

            return (ISessionTypeSvc)obj;
        }

        public IAppRoleSvc GetAppRole(String svcName)
        {
            try
            {
                type = Type.GetType(GetImplName(svcName));
                obj = Activator.CreateInstance(type);
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid service.", e);
            }

            return (IAppRoleSvc)obj;
        }
    }
}
