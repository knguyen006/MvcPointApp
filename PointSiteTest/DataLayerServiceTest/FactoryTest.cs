using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using DataLayerService;

namespace DataLayerServiceTest
{
    [TestClass]
    public class FactoryTest
    {
        Factory factory = Factory.GetInstance();

        [TestMethod]
        public void GetActivityTest()
        {
            IActivitySvc svc;

            svc = (IActivitySvc)factory.GetService(typeof(IActivitySvc).Name);

            Assert.IsTrue(svc is IActivitySvc);

        }

        [TestMethod]
        public void GetStudentTest()
        {
            IStudentSvc svc;

            svc = (IStudentSvc)factory.GetService(typeof(IStudentSvc).Name);

            Assert.IsTrue(svc is IStudentSvc);

        }

        [TestMethod]
        public void GetContactemailTest()
        {
            IContactemailSvc svc;

            svc = (IContactemailSvc)factory.GetService(typeof(IContactemailSvc).Name);

            Assert.IsTrue(svc is IContactemailSvc);

        }

        [TestMethod]
        public void GetContactTest()
        {
            IContactSvc svc;

            svc = (IContactSvc)factory.GetService(typeof(IContactSvc).Name);

            Assert.IsTrue(svc is IContactSvc);

        }

        [TestMethod]
        public void GetFeerequestTest()
        {
            IFeerequestSvc svc;

            svc = (IFeerequestSvc)factory.GetService(typeof(IFeerequestSvc).Name);

            Assert.IsTrue(svc is IFeerequestSvc);

        }

        [TestMethod]
        public void GetApproleTest()
        {
            IApproleSvc svc;

            svc = (IApproleSvc)factory.GetService(typeof(IApproleSvc).Name);

            Assert.IsTrue(svc is IApproleSvc);

        }

        [TestMethod]
        public void GetSessiontypeTest()
        {
            ISessiontypeSvc svc;

            svc = (ISessiontypeSvc)factory.GetService(typeof(ISessiontypeSvc).Name);

            Assert.IsTrue(svc is ISessiontypeSvc);

        }

        [TestMethod]
        public void GetSessioncalTest()
        {
            ISessioncalSvc svc;

            svc = (ISessioncalSvc)factory.GetService(typeof(ISessioncalSvc).Name);

            Assert.IsTrue(svc is ISessioncalSvc);

        }

        [TestMethod]
        public void GetSignupTest()
        {
            ISignupSvc svc;

            svc = (ISignupSvc)factory.GetService(typeof(ISignupSvc).Name);

            Assert.IsTrue(svc is ISignupSvc);

        }

        [TestMethod]
        public void GetMemberTest()
        {
            IMemberSvc svc;

            svc = (IMemberSvc)factory.GetService(typeof(IMemberSvc).Name);

            Assert.IsTrue(svc is IMemberSvc);

        }



    }
}
