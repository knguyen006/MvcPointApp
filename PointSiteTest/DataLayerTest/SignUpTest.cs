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
    public class SignUpTest
    {
        PointAppDBContext db = new PointAppDBContext();
        signup obj = new signup();

        [TestMethod]
        public void DisplayData()
        {
            signup t = (from d in db.signups select d).First();
            signup saveObj = (from d in db.signups
                              where d.signupid == t.signupid
                              select d).Single();

            Assert.AreEqual(saveObj.signupid, t.signupid);
        }

        [TestMethod]
        public void AddNewRecord()
        {
            //call fk object
            sessioncal c = (from d in db.sessioncals
                            select d).First();
            member m = (from d in db.members
                        select d).First();

            //set data
            obj.memberid = m.memberid;
            obj.sessioncalid = c.sessioncalid;
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

        [TestMethod]
        public void UpdateRecord()
        {
            //call fk object
            sessioncal c = (from d in db.sessioncals
                            select d).First();
            member m = (from d in db.members
                        select d).First();

            //set data
            obj.memberid = m.memberid;
            obj.sessioncalid = c.sessioncalid;
            obj.pointearn = 20;
            obj.isshow = "Y";

            db.signups.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            signup savedObj = (from d in db.signups
                               where d.signupid == obj.signupid
                               select d).Single();

            savedObj.memberid = m.memberid;
            savedObj.sessioncalid = c.sessioncalid;
            savedObj.pointearn = 25;
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

        [TestMethod]
        public void DeleteRecord()
        {
            //call fk object
            sessioncal c = (from d in db.sessioncals
                            select d).First();
            member m = (from d in db.members
                        select d).First();

            //set data
            obj.memberid = m.memberid;
            obj.sessioncalid = c.sessioncalid;
            obj.pointearn = 30;
            obj.isshow = "Y";

            db.signups.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            signup saveObj = (from d in db.signups
                              where d.signupid == obj.signupid
                              select d).Single();
            db.signups.Remove(saveObj);
            db.SaveChanges();

            //Check to see if the record is existed in database
            signup removedObj = (from d in db.signups
                                 where d.signupid == saveObj.signupid
                                 select d).FirstOrDefault();

            //Assert statement
            Assert.IsNull(removedObj);
        }

        [TestMethod]
        public void GetListData()
        {
            //call fk object
            sessioncal c = (from d in db.sessioncals
                            select d).First();
            member m = (from d in db.members
                        select d).First();

            //set data
            obj.memberid = m.memberid;
            obj.sessioncalid = c.sessioncalid;
            obj.pointearn = 40;
            obj.isshow = "Y";

            db.signups.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<signup> saveObjs = (from d in db.signups
                                     select d).ToList();

            //ensure records number is greater than 0
            Assert.IsTrue(saveObjs.Count > 0);
        }
    }
}
