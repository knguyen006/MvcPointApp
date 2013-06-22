using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using DataLayerBusiness;
using System.Data;
using System.Data.Entity;
using System.Linq;

namespace DataLayerBusinessTest
{
    [TestClass]
    public class ActivityMgrTest
    {
        PointAppDBContext db = new PointAppDBContext();

        [TestMethod]
        public void TestAdd()
        {
            activity dbList = new activity();
            dbList.actname = "Test Activity Manager";

            ActivityMgr mgr = new ActivityMgr();
            mgr.Create(dbList);

            activity savedb = mgr.Retrieved(dbList.activityid);
            Assert.AreEqual(savedb, dbList);

            mgr.Delete(dbList);
            db.SaveChanges();
        }

        [TestMethod]
        public void TestEdit()
        {
            activity dbList = new activity();
            dbList.actname = "Test Activity Manager";

            ActivityMgr mgr = new ActivityMgr();
            mgr.Create(dbList);

            activity savedb = mgr.Retrieved(dbList.activityid);
            Assert.AreEqual(savedb, dbList);

            mgr.Delete(dbList);
            db.SaveChanges();
        }

        [TestMethod]
        public void TestDelete()
        {
            activity dbList = new activity();
            dbList.actname = "Test Delete Manager";

            ActivityMgr mgr = new ActivityMgr();
            mgr.Create(dbList);

            activity savedb = mgr.Retrieved(dbList.activityid);
            Assert.AreEqual(savedb, dbList);

            mgr.Delete(dbList);
            db.SaveChanges();

            Assert.IsTrue(!db.activities.Any());
        }

        [TestMethod]
        public void TestRetrive()
        {
            activity dbList = new activity();
            dbList.actname = "Test Retrieve Manager";

            ActivityMgr mgr = new ActivityMgr();
            mgr.Create(dbList);

            activity savedb = mgr.Retrieved(dbList.activityid);
            Assert.AreEqual(savedb, dbList);

            mgr.Delete(dbList);
            db.SaveChanges();
        }

    }
}
