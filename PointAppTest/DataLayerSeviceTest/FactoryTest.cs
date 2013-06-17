using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using DataLayerService;

namespace DataLayerSeviceTest
{
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public void GetActivitySvcTest()
        {
            IActivitySvc custSvc;
            Factory factory = Factory.GetInstance();

            custSvc = (IActivitySvc)factory.GetService(typeof(IActivitySvc).Name);
            Assert.IsTrue(custSvc is IActivitySvc);
        }
    }
}
