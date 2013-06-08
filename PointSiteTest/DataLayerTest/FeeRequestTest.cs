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
    public class FeeRequestTest
    {

        /// <summary>
        /// Test Method to Connect to the repository and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void DisplayData()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            feerequest t = (from d in db.feerequests select d).First();
            feerequest savedObj = (from d in db.feerequests
                                   where d.feerequestid == t.feerequestid
                                   select d).Single();

            Assert.AreEqual(savedObj.feerequestid, t.feerequestid);
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
            feerequest obj = new feerequest();

            //set data
            obj.requestdate = new DateTime(2013, 5, 1);
            obj.requestamt = 50;
            obj.pointbal = 100;
            obj.memberid = m.memberid;
            db.feerequests.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            feerequest savedObj = (from d in db.feerequests
                                   where d.feerequestid == obj.feerequestid
                                   select d).Single();

            // Assert statement
            Assert.AreEqual(savedObj.requestdate, obj.requestdate);
            Assert.AreEqual(savedObj.requestamt, obj.requestamt);
            Assert.AreEqual(savedObj.pointbal, obj.pointbal);
            Assert.AreEqual(savedObj.memberid, obj.memberid);

            //cleanup
            db.feerequests.Remove(savedObj);
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
            feerequest obj = new feerequest();

            //set data
            obj.requestdate = new DateTime(2013, 5, 1);
            obj.requestamt = 50;
            obj.pointbal = 100;
            obj.memberid = m.memberid;

            db.feerequests.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            feerequest savedObj = (from d in db.feerequests
                                   where d.feerequestid == obj.feerequestid
                                   select d).Single();
            savedObj.requestdate = new DateTime(2013, 5, 2);
            savedObj.requestamt = 50;
            savedObj.pointbal = 100;
            savedObj.memberid = m.memberid;

            db.SaveChanges();

            //check to see if there is existing record
            feerequest updatedObj = (from d in db.feerequests
                                     where d.feerequestid == obj.feerequestid
                                     select d).Single();

            Assert.AreEqual(updatedObj.requestdate, savedObj.requestdate);
            Assert.AreEqual(updatedObj.requestamt, savedObj.requestamt);
            Assert.AreEqual(updatedObj.pointbal, savedObj.pointbal);
            Assert.AreEqual(updatedObj.memberid, savedObj.memberid);

            //cleanup
            db.feerequests.Remove(updatedObj);
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
            feerequest obj = new feerequest();

            //set data
            obj.requestdate = new DateTime(2013, 5, 1);
            obj.requestamt = 50;
            obj.pointbal = 100;
            obj.memberid = m.memberid;

            db.feerequests.Add(obj);
            db.SaveChanges();

            //retrieved the recrod and remove it
            feerequest savedObj = (from d in db.feerequests
                                   where d.feerequestid == obj.feerequestid
                                   select d).Single();
            db.feerequests.Remove(savedObj);
            db.SaveChanges();

            //ensure the record is deleted from database
            feerequest removedObj = (from d in db.feerequests
                                     where d.feerequestid == savedObj.feerequestid
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
            feerequest obj = new feerequest();


            //retrieved data
            List<feerequest> savedObjs = (from d in db.feerequests
                                          select d).ToList();

            //ensure record number is greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }

    }
}
