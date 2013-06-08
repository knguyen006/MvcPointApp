using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity;

namespace DataLayerTest
{
    [TestClass]
    public class ActivityTest
    {
        /// <summary>
        /// Test Method to Connect to the repository and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void DisplayData()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            activity t = (from d in db.activities select d).First();
            activity savedObj = (from d in db.activities
                                 where d.activityid == t.activityid
                                 select d).Single();

            Assert.AreEqual(savedObj.activityid, t.activityid);
        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void AddNewRecord()
        {
            // call database object
            PointAppDBContainer db = new PointAppDBContainer();
            activity obj = new activity();

            //set data
            obj.actname = "Marching Band";
            db.activities.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            activity savedObj = (from d in db.activities
                                 where d.activityid == obj.activityid
                                 select d).Single();

            // Assert statement
            Assert.AreEqual(savedObj.actname, obj.actname);

            //cleanup
            db.activities.Remove(savedObj);
            db.SaveChanges();

        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            activity obj = new activity();
            obj.actname = "Marching Band 2";
            db.activities.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            activity savedObj = (from d in db.activities
                                 where d.activityid == obj.activityid
                                 select d).Single();
            savedObj.actname = "Updated Marching Band 2";
            db.SaveChanges();
            // Assert statement
            Assert.AreEqual(savedObj.actname, obj.actname);


            //check to see if there is existing record
            activity updatedObj = (from d in db.activities
                                   where d.activityid == obj.activityid
                                   select d).Single();

            Assert.AreEqual(updatedObj.actname, savedObj.actname);

            //cleanup
            db.activities.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            activity obj = new activity();
            obj.actname = "Test Delete Activity";
            db.activities.Add(obj);
            db.SaveChanges();

            //retrieved the recrod and remove it
            activity savedObj = (from d in db.activities
                                 where d.activityid == obj.activityid
                                 select d).Single();
            db.activities.Remove(savedObj);
            db.SaveChanges();

            //ensure the record is deleted from database
            activity removedObj = (from d in db.activities
                                   where d.activityid == savedObj.activityid
                                   select d).FirstOrDefault();
            Assert.IsNull(removedObj);
        }

        /// <summary>
        /// Test Method to List the records in the repository.
        /// </summary>
        [TestMethod]
        public void GetListData()
        {
            //add record to the list
            PointAppDBContainer db = new PointAppDBContainer();
            activity obj = new activity();
            obj.actname = "Test get activity list";
            db.activities.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<activity> savedObjs = (from d in db.activities
                                        select d).ToList();

            //ensure record number is greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }

    }
}
