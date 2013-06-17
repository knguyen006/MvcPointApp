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
    public class SessionCalTest
    {
        PointAppDBContext db = new PointAppDBContext();
        sessioncal obj = new sessioncal();

        [TestMethod]
        public void DisplayData()
        {
            sessioncal t = (from d in db.sessioncals select d).First();
            sessioncal saveObj = (from d in db.sessioncals
                                  where d.sessioncalid == t.sessioncalid
                                  select d).Single();

            Assert.AreEqual(saveObj.sessioncalid, t.sessioncalid);
        }

        [TestMethod]
        public void AddNewRecord()
        {
            //call fk object
            sessiontype s = (from d in db.sessiontypes
                             select d).First();

            //set data
            obj.sessiondate = new DateTime(2013, 5, 1);
            obj.sessionnum = 1;
            obj.sessionamt = 5000;
            obj.sessionpoint = 2500;
            obj.sessiontypeid = s.sessiontypeid;
            db.sessioncals.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            sessioncal savedObj = (from d in db.sessioncals
                                   where d.sessioncalid == obj.sessioncalid
                                   select d).Single();

            //Assert statement
            Assert.AreEqual(savedObj.sessiondate, obj.sessiondate);
            Assert.AreEqual(savedObj.sessionnum, obj.sessionnum);
            Assert.AreEqual(savedObj.sessionamt, obj.sessionamt);
            Assert.AreEqual(savedObj.sessionpoint, obj.sessionpoint);
            Assert.AreEqual(savedObj.sessiontypeid, obj.sessiontypeid);

            //cleanup
            db.sessioncals.Remove(savedObj);
            db.SaveChanges();
        }

        [TestMethod]
        public void UpdateRecord()
        {
            //call fk object
            sessiontype s = (from d in db.sessiontypes
                             select d).First();

            //set data
            obj.sessiondate = new DateTime(2013, 5, 2);
            obj.sessionnum = 1;
            obj.sessionamt = 5000;
            obj.sessionpoint = 2500;
            obj.sessiontypeid = s.sessiontypeid;

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
            savedObj.sessiontypeid = s.sessiontypeid;
            db.SaveChanges();

            //check to see if there is existing record
            sessioncal updatedObj = (from d in db.sessioncals
                                     where d.sessioncalid == obj.sessioncalid
                                     select d).Single();

            Assert.AreEqual(updatedObj.sessiondate, savedObj.sessiondate);
            Assert.AreEqual(updatedObj.sessionnum, savedObj.sessionnum);
            Assert.AreEqual(updatedObj.sessionamt, savedObj.sessionamt);
            Assert.AreEqual(updatedObj.sessionpoint, savedObj.sessionpoint);
            Assert.AreEqual(updatedObj.sessiontypeid, savedObj.sessiontypeid);

            //cleanup
            db.sessioncals.Remove(updatedObj);
            db.SaveChanges();

        }

        [TestMethod]
        public void DeleteRecord()
        {
            //call fk object
            sessiontype s = (from d in db.sessiontypes
                             select d).First();

            //set data
            obj.sessiondate = new DateTime(2013, 5, 3);
            obj.sessionnum = 1;
            obj.sessionamt = 5000;
            obj.sessionpoint = 2500;
            obj.sessiontypeid = s.sessiontypeid;

            db.sessioncals.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            sessioncal saveObj = (from d in db.sessioncals
                                  where d.sessioncalid == obj.sessioncalid
                                  select d).Single();
            db.sessioncals.Remove(saveObj);
            db.SaveChanges();

            //Check to see if the record is existed in database
            sessioncal removedObj = (from d in db.sessioncals
                                     where d.sessioncalid == saveObj.sessioncalid
                                     select d).FirstOrDefault();

            //Assert statement
            Assert.IsNull(removedObj);
        }

        [TestMethod]
        public void GetListData()
        {
            //call fk object
            sessiontype s = (from d in db.sessiontypes
                             select d).First();

            //set data
            obj.sessiondate = new DateTime(2013, 5, 4);
            obj.sessionnum = 1;
            obj.sessionamt = 5000;
            obj.sessionpoint = 2500;
            obj.sessiontypeid = s.sessiontypeid;

            db.sessioncals.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<sessioncal> saveObjs = (from d in db.sessioncals
                                         select d).ToList();

            //ensure records number is greater than 0
            Assert.IsTrue(saveObjs.Count > 0);
        }
    }
}
