using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using DataLayerService;
using System.Data;
using System.Data.Entity;


namespace DataLayerSeviceTest
{
    [TestClass]
    public class ActivitySvcTest
    {
        [TestMethod]
        public void ActivitySvcRepositoryContainsData()
        {
            // arrange 
            PointAppDBContext db = new PointAppDBContext();
            Factory factory = Factory.GetInstance();
            IActivitySvc svc = (IActivitySvc)factory.GetService("IActivitySvc", db);


            // act -- go get the first record
            activity savedObj = svc.GetById(1);

            // assert
            Assert.AreEqual(savedObj.activityid, 1);
        }

        [TestMethod]
        public void SaveNewRewardSvc()
        {
            // arrange
            PointAppDBContext db = new PointAppDBContext();
            Factory factory = Factory.GetInstance();
            IActivitySvc svc = (IActivitySvc)factory.GetService("IActivitySvc", db);

            activity obj = new activity();
            obj.actname = "New Reward 1";
            svc.Insert(obj);

            // act
            svc.Save();

            // Assert -- see if the record retreived from the database matches the one i just added
            activity savedObj = svc.GetById(obj.activityid);

            Assert.AreEqual(savedObj.actname, obj.actname);

            // cleanup
            svc.Delete(savedObj);
            svc.Save();
        }
    }
}
