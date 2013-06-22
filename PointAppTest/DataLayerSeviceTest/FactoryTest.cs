using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayerService;
using DataLayer;
using System.Data;
using System.Data.Entity;
using System.Collections.Generic;

namespace DataLayerSeviceTest
{
    [TestClass]
    public class FactoryTest
    {
        [TestMethod]
        public void GetActivitySvcTest()
        {
            IActivitySvc actSvc;
            Factory factory = Factory.GetInstance();

            actSvc = (IActivitySvc)factory.GetService(typeof(IActivitySvc).Name);
            Assert.IsTrue(actSvc is IActivitySvc);
        }
    }
}
