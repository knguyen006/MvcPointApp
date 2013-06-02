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
    public class SessionCalTest
    {
        /// <summary>
        /// Create database if the database is not existed.
        /// </summary>
        [ClassInitialize]
        public static void DataLayerSetup(TestContext testContext)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PointAppDBContainer>());

            var context = new PointAppDBContainer();
            context.Database.Create();
        }

        /// <summary>
        /// Test Method to Connect to the repository and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void DisplayData()
        {
            PointAppDBContainer db = new PointAppDBContainer();

            sessioncal savedObj = (from d in db.sessioncals
                                where d.sessioncalid == 1
                                select d).Single();

            Assert.AreEqual(savedObj.sessioncalid, 1);
        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void AddNewRecord()
        {
            // call database object
            PointAppDBContainer db = new PointAppDBContainer();
            sessiontype t = (from d in db.sessiontypes select d).First();
            sessioncal obj = new sessioncal();
            
            //set data
            obj.sessiondate = new DateTime(2013, 5, 1);
            obj.sessionnum = 1;
            obj.sessionamt = 5000;
            obj.sessionpoint = 2500;
            obj.sessiontypeid = t.sessiontypeid;
            db.sessioncals.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            sessioncal savedObj = (from d in db.sessioncals 
                                where d.sessioncalid == obj.sessioncalid 
                                select d).Single();

            // Assert statement
            Assert.AreEqual(savedObj.sessiondate, obj.sessiondate);
            Assert.AreEqual(savedObj.sessionnum, obj.sessionnum);
            Assert.AreEqual(savedObj.sessionamt, obj.sessionamt);
            Assert.AreEqual(savedObj.sessionpoint, obj.sessionpoint);
            Assert.AreEqual(savedObj.sessiontypeid, obj.sessiontypeid);
            
            //cleanup
            db.sessioncals.Remove(savedObj);
            db.SaveChanges();

        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            sessiontype t = (from d in db.sessiontypes select d).First();
            sessioncal obj = new sessioncal();

            //set data
            obj.sessiondate = new DateTime(2013, 5, 1);
            obj.sessionnum = 1;
            obj.sessionamt = 5000;
            obj.sessionpoint = 2500;
            obj.sessiontypeid = t.sessiontypeid;

            db.sessioncals.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            sessioncal savedObj = (from d in db.sessioncals
                                where d.sessioncalid == obj.sessioncalid
                                select d).Single();
            //set data
            savedObj.sessiondate = new DateTime(2013, 5, 2);
            savedObj.sessionnum = 1;
            savedObj.sessionamt = 5000;
            savedObj.sessionpoint = 2500;
            savedObj.sessiontypeid = t.sessiontypeid;
            db.SaveChanges();

            //check to see if there is existing record
            sessioncal updatedObj = (from d in db.sessioncals
                                  where d.sessioncalid == obj.sessioncalid
                                  select d).Single();

            // Assert statement
            Assert.AreEqual(updatedObj.sessiondate, savedObj.sessiondate);
            Assert.AreEqual(updatedObj.sessionnum, savedObj.sessionnum);
            Assert.AreEqual(updatedObj.sessionamt, savedObj.sessionamt);
            Assert.AreEqual(updatedObj.sessionpoint, savedObj.sessionpoint);
            Assert.AreEqual(updatedObj.sessiontypeid, savedObj.sessiontypeid);

            //cleanup
            db.sessioncals.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            sessiontype t = (from d in db.sessiontypes select d).First();
            sessioncal obj = new sessioncal();

            //set data
            obj.sessiondate = new DateTime(2013, 5, 1);
            obj.sessionnum = 1;
            obj.sessionamt = 5000;
            obj.sessionpoint = 2500;
            obj.sessiontypeid = t.sessiontypeid;

            db.sessioncals.Add(obj);
            db.SaveChanges();

            //retrieved the recrod and remove it
            sessioncal savedObj = (from d in db.sessioncals
                                where d.sessioncalid == obj.sessioncalid
                                select d).Single();
            db.sessioncals.Remove(savedObj);
            db.SaveChanges();

            //ensure the record is deleted from database
            sessioncal removedObj = (from d in db.sessioncals
                                  where d.sessioncalid == savedObj.sessioncalid
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
            sessiontype t = (from d in db.sessiontypes select d).First();
            sessioncal obj = new sessioncal();

            //set data
            obj.sessiondate = new DateTime(2013, 5, 1);
            obj.sessionnum = 1;
            obj.sessionamt = 5000;
            obj.sessionpoint = 2500;
            obj.sessiontypeid = t.sessiontypeid;

            db.sessioncals.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<sessioncal> savedObjs = (from d in db.sessioncals 
                                       select d).ToList();

            //ensure record number is greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }

    }
}
