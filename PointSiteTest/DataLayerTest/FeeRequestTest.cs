using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
using System.Data.Entity;
using System.Data;
using System.Linq;
using System.Collections.Generic;

namespace DataLayerTest
{
    [TestClass]
    public class FeeRequestTest
    {
        PointAppDBContext db = new PointAppDBContext();
        feerequest obj = new feerequest();

        [TestMethod]
        public void DisplayData()
        {
            feerequest t = (from d in db.feerequests select d).First();
            feerequest saveObj = (from d in db.feerequests
                                  where d.feerequestid == t.feerequestid
                                  select d).Single();

            Assert.AreEqual(saveObj.feerequestid, t.feerequestid);
        }

        [TestMethod]
        public void AddNewRecord()
        {
            //call fk object
            member m = (from d in db.members
                        select d).First();

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

        [TestMethod]
        public void UpdateRecord()
        {
            //call fk object
            member m = (from d in db.members
                        select d).First();

            //set data
            obj.requestdate = new DateTime(2013, 5, 2);
            obj.requestamt = 25;
            obj.pointbal = 50;
            obj.memberid = m.memberid;

            db.feerequests.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            feerequest savedObj = (from d in db.feerequests
                                   where d.feerequestid == obj.feerequestid
                                   select d).Single();

            savedObj.requestdate = new DateTime(2013, 5, 2);
            savedObj.requestamt = 30;
            savedObj.pointbal = 20;
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

        [TestMethod]
        public void DeleteRecord()
        {
            //call fk object
            member m = (from d in db.members
                        select d).First();

            //set data
            obj.requestdate = new DateTime(2013, 5, 3);
            obj.requestamt = 20;
            obj.pointbal = 40;
            obj.memberid = m.memberid;

            db.feerequests.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            feerequest saveObj = (from d in db.feerequests
                                  where d.feerequestid == obj.feerequestid
                                  select d).Single();
            db.feerequests.Remove(saveObj);
            db.SaveChanges();

            //Check to see if the record is existed in database
            feerequest removedObj = (from d in db.feerequests
                                     where d.feerequestid == saveObj.feerequestid
                                     select d).FirstOrDefault();

            //Assert statement
            Assert.IsNull(removedObj);
        }

        [TestMethod]
        public void GetListData()
        {
            //call fk object
            member m = (from d in db.members
                        select d).First();

            //set data
            obj.requestdate = new DateTime(2013, 5, 4);
            obj.requestamt = 10;
            obj.pointbal = 20;
            obj.memberid = m.memberid;

            db.feerequests.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<feerequest> saveObjs = (from d in db.feerequests
                                         select d).ToList();

            //ensure records number is greater than 0
            Assert.IsTrue(saveObjs.Count > 0);
        }
    }
}
