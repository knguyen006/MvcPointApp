using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;
using System.Data.Entity;
using DataLayer;
using DataLayerService;

namespace DataLayerServiceTest
{
    [TestClass]
    public class ActivitySvcTest
    {
        
        [TestMethod]
        public void GetActivityData()
        {
            PointAppDBContext db = new PointAppDBContext();
            Factory factory = Factory.GetInstance();
            IActivitySvc svc = (IActivitySvc)factory.GetService("IActivitySvc", db);

            activity saveObj = svc.GetById(1);

            //assert
            Assert.AreEqual(saveObj.activityid, 1);
        }
    }
}
