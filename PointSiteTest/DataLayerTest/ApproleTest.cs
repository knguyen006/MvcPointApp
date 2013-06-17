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
    public class ApproleTest
    {
        PointAppDBContext db = new PointAppDBContext();
        approle obj = new approle();

        [TestMethod]
        public void DisplayData()
        {
            approle t = (from d in db.approles select d).First();
            approle saveObj = (from d in db.approles
                               where d.approleid == t.approleid
                               select d).Single();

            Assert.AreEqual(saveObj.approleid, t.approleid);
        }

        [TestMethod]
        public void AddNewRecord()
        {
            //set data
            obj.rolename = "Add new approle";
            db.approles.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            approle savedObj = (from d in db.approles
                                where d.approleid == obj.approleid
                                select d).Single();

            //Assert statement
            Assert.AreEqual(savedObj.rolename, obj.rolename);

            //cleanup
            db.approles.Remove(savedObj);
            db.SaveChanges();
        }

        [TestMethod]
        public void UpdateRecord()
        {
            obj.rolename = "Update approle";
            db.approles.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            approle savedObj = (from d in db.approles
                                where d.approleid == obj.approleid
                                select d).Single();
            savedObj.rolename = "Test updated approle";
            db.SaveChanges();

            //check to see if there is existing record
            approle updatedObj = (from d in db.approles
                                  where d.approleid == obj.approleid
                                  select d).Single();

            Assert.AreEqual(updatedObj.rolename, savedObj.rolename);

            //cleanup
            db.approles.Remove(updatedObj);
            db.SaveChanges();

        }

        [TestMethod]
        public void DeleteRecord()
        {
            obj.rolename = "Delete approle";
            db.approles.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            approle saveObj = (from d in db.approles
                               where d.approleid == obj.approleid
                               select d).Single();
            db.approles.Remove(saveObj);
            db.SaveChanges();

            //Check to see if the record is existed in database
            approle removedObj = (from d in db.approles
                                  where d.approleid == saveObj.approleid
                                  select d).FirstOrDefault();

            //Assert statement
            Assert.IsNull(removedObj);
        }

        [TestMethod]
        public void GetListData()
        {
            obj.rolename = "Get approle List";
            db.approles.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<approle> saveObjs = (from d in db.approles
                                      select d).ToList();

            //ensure records number is greater than 0
            Assert.IsTrue(saveObjs.Count > 0);
        }
    }
}
