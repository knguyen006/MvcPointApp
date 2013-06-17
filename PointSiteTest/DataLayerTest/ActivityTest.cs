using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using System.Data.Entity;
using System.Data;
using System.Linq;

namespace DataLayerTest
{
    /// <summary>
    /// Summary description for ActivityTest
    /// </summary>
    [TestClass]
    public class ActivityTest
    {
        PointAppDBContext db = new PointAppDBContext();
        activity obj = new activity();

        [TestMethod]
        public void DisplayData()
        {
            activity t = (from d in db.activities select d).First();
            activity saveObj = (from d in db.activities
                                where d.activityid == t.activityid
                                select d).Single();

            Assert.AreEqual(saveObj.activityid, t.activityid);
        }

        [TestMethod]
        public void AddNewRecord()
        { 
            //set data
            obj.actname = "Add new activity";
            db.activities.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            activity savedObj = (from d in db.activities
                                 where d.activityid == obj.activityid
                                 select d).Single();

            //Assert statement
            Assert.AreEqual(savedObj.actname, obj.actname);

            //cleanup
            db.activities.Remove(savedObj);
            db.SaveChanges();
        }

        [TestMethod]
        public void UpdateRecord()
        {
            obj.actname = "Update Activity";
            db.activities.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            activity savedObj = (from d in db.activities
                                 where d.activityid == obj.activityid
                                 select d).Single();
            savedObj.actname = "Test updated activity";
            db.SaveChanges();

            //check to see if there is existing record
            activity updatedObj = (from d in db.activities
                                   where d.activityid == obj.activityid
                                   select d).Single();

            Assert.AreEqual(updatedObj.actname, savedObj.actname);

            //cleanup
            db.activities.Remove(updatedObj);
            db.SaveChanges();

        }

        [TestMethod]
        public void DeleteRecord()
        {
            obj.actname = "Delete activity";
            db.activities.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            activity saveObj = (from d in db.activities
                                where d.activityid == obj.activityid
                                select d).Single();
            db.activities.Remove(saveObj);
            db.SaveChanges();

            //Check to see if the record is existed in database
            activity removedObj = (from d in db.activities
                                   where d.activityid == saveObj.activityid
                                   select d).FirstOrDefault();

            //Assert statement
            Assert.IsNull(removedObj);
        }

        [TestMethod]
        public void GetListData()
        {
            obj.actname = "Get Activity List";
            db.activities.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<activity> saveObjs = (from d in db.activities
                                       select d).ToList();

            //ensure records number is greater than 0
            Assert.IsTrue(saveObjs.Count > 0);
        }
    }
}
