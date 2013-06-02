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
    public class SignUpTest
    {

        /// <summary>
        /// Test Method to Connect to the repository and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void DisplayData()
        {
            PointAppDBContainer db = new PointAppDBContainer();

            signup savedObj = (from d in db.signups
                                where d.signupid == 1
                                select d).Single();

            Assert.AreEqual(savedObj.signupid, 1);
        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void AddNewRecord()
        {
            // call database object
            PointAppDBContainer db = new PointAppDBContainer();
            member m = (from d in db.members select d).First();
            sessioncal c = (from d in db.sessioncals select d).First();
            signup obj = new signup();
            
            //set data
            obj.memberid = 3;
            obj.sessioncalid = 4;
            obj.pointearn = 10;
            obj.isshow = "Y";

            db.signups.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            signup savedObj = (from d in db.signups 
                                where d.signupid == obj.signupid 
                                select d).Single();

            // Assert statement
            Assert.AreEqual(savedObj.memberid, obj.memberid);
            Assert.AreEqual(savedObj.sessioncalid, obj.sessioncalid);
            Assert.AreEqual(savedObj.pointearn, obj.pointearn);
            Assert.AreEqual(savedObj.isshow, obj.isshow);

            //cleanup
            db.signups.Remove(savedObj);
            db.SaveChanges();

        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            member m = (from d in db.members select d).First();
            sessioncal c = (from d in db.sessioncals select d).First();
            signup obj = new signup();

            //set data
            obj.memberid = 3;
            obj.sessioncalid = 4;
            obj.pointearn = 10;
            obj.isshow = "Y";

            db.signups.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            signup savedObj = (from d in db.signups
                                where d.signupid == obj.signupid
                                select d).Single();
            savedObj.memberid = 3;
            savedObj.sessioncalid = 4;
            savedObj.pointearn = 20;
            savedObj.isshow = "Y";
            db.SaveChanges();

            //check to see if there is existing record
            signup updatedObj = (from d in db.signups
                                  where d.signupid == obj.signupid
                                  select d).Single();

            Assert.AreEqual(updatedObj.memberid, savedObj.memberid);
            Assert.AreEqual(updatedObj.sessioncalid, savedObj.sessioncalid);
            Assert.AreEqual(updatedObj.pointearn, savedObj.pointearn);
            Assert.AreEqual(updatedObj.isshow, savedObj.isshow);

            //cleanup
            db.signups.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            member m = (from d in db.members select d).First();
            sessioncal c = (from d in db.sessioncals select d).First();
            signup obj = new signup();

            //set data
            obj.memberid = 4;
            obj.sessioncalid = 4;
            obj.pointearn = 10;
            obj.isshow = "Y";

            db.signups.Add(obj);
            db.SaveChanges();

            //retrieved the recrod and remove it
            signup savedObj = (from d in db.signups
                                where d.signupid == obj.signupid
                                select d).Single();
            db.signups.Remove(savedObj);
            db.SaveChanges();

            //ensure the record is deleted from database
            signup removedObj = (from d in db.signups
                                  where d.signupid == savedObj.signupid
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
            member m = (from d in db.members select d).First();
            sessioncal c = (from d in db.sessioncals select d).First();
            signup obj = new signup();

            //set data
            obj.memberid = m.memberid;
            obj.sessioncalid = c.sessioncalid;
            obj.pointearn = 10;
            obj.isshow = "Y";

            db.signups.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<signup> savedObjs = (from d in db.signups 
                                       select d).ToList();

            //ensure record number is greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }

    }
}
