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
    public class ApproleTest
    {

        /// <summary>
        /// Test Method to Connect to the repository and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void DisplayData()
        {
            PointAppDBContainer db = new PointAppDBContainer();

            approle savedObj = (from d in db.approles
                                where d.approleid == 1
                                select d).Single();

            Assert.AreEqual(savedObj.approleid, 1);
        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void AddNewRecord()
        {
            // call database object
            PointAppDBContainer db = new PointAppDBContainer();
            approle obj = new approle();
            
            //set data
            obj.rolename = "app_admin_data";
            obj.note = "This role can only maintenance database including insert/update/delete member or event.";
            db.approles.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            approle savedObj = (from d in db.approles 
                                where d.approleid == obj.approleid 
                                select d).Single();

            // Assert statement
            Assert.AreEqual(savedObj.rolename, obj.rolename);
            Assert.AreEqual(savedObj.note, obj.note);

            //cleanup
            db.approles.Remove(savedObj);
            db.SaveChanges();

        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            approle obj = new approle();
            obj.rolename = "app_test";
            obj.note = "Test role for testing purpose.";
            db.approles.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            approle savedObj = (from d in db.approles
                                where d.approleid == obj.approleid
                                select d).Single();
            savedObj.rolename = "app_test";
            savedObj.note = "This is update statement for testing app_test role.";
            db.SaveChanges();

            //check to see if there is existing record
            approle updatedObj = (from d in db.approles
                                  where d.approleid == obj.approleid
                                  select d).Single();

            Assert.AreEqual(updatedObj.rolename, savedObj.rolename);
            Assert.AreEqual(updatedObj.note, savedObj.note);

            //cleanup
            db.approles.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            approle obj = new approle();
            obj.rolename = "app_delete";
            obj.note = "This is test for delete.";
            db.approles.Add(obj);
            db.SaveChanges();

            //retrieved the recrod and remove it
            approle savedObj = (from d in db.approles
                                where d.approleid == obj.approleid
                                select d).Single();
            db.approles.Remove(savedObj);
            db.SaveChanges();

            //ensure the record is deleted from database
            approle removedObj = (from d in db.approles
                                  where d.approleid == savedObj.approleid
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
            approle obj = new approle();
            obj.rolename = "app_test";
            obj.note = "This is test role.";
            db.approles.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<approle> savedObjs = (from d in db.approles 
                                       select d).ToList();

            //ensure record number is greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }

    }
}
