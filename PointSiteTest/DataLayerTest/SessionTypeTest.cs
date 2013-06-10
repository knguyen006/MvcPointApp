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
    public class SessionTypeTest
    {

        /// <summary>
        /// Test Method to Connect to the repository and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void DisplayData()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            sessiontype t = (from d in db.sessiontypes select d).First();
            sessiontype savedObj = (from d in db.sessiontypes
                                    where d.sessiontypeid == t.sessiontypeid
                                    select d).Single();

            Assert.AreEqual(savedObj.sessiontypeid, t.sessiontypeid);
        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void AddNewRecord()
        {
            // call database object
            PointAppDBContainer db = new PointAppDBContainer();
            sessiontype obj = new sessiontype();

            //set data
            obj.typename = "Pizza Bowl";
            obj.note = "This fundraising is selling pizza.";
            db.sessiontypes.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            sessiontype savedObj = (from d in db.sessiontypes
                                    where d.sessiontypeid == obj.sessiontypeid
                                    select d).Single();

            // Assert statement
            Assert.AreEqual(savedObj.typename, obj.typename);
            Assert.AreEqual(savedObj.note, obj.note);

            //cleanup
            db.sessiontypes.Remove(savedObj);
            db.SaveChanges();

        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            sessiontype obj = new sessiontype();
            obj.typename = "test_test";
            obj.note = "Test role is for testing purpose.";
            db.sessiontypes.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            sessiontype savedObj = (from d in db.sessiontypes
                                    where d.sessiontypeid == obj.sessiontypeid
                                    select d).Single();
            savedObj.typename = "test_test";
            savedObj.note = "This is update statement for testing test_test testing.";
            db.SaveChanges();

            //check to see if there is existing record
            sessiontype updatedObj = (from d in db.sessiontypes
                                      where d.sessiontypeid == obj.sessiontypeid
                                      select d).Single();

            Assert.AreEqual(updatedObj.typename, savedObj.typename);
            Assert.AreEqual(updatedObj.note, savedObj.note);

            //cleanup
            db.sessiontypes.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            sessiontype obj = new sessiontype();
            obj.typename = "test_delete";
            obj.note = "This is test for delete.";
            db.sessiontypes.Add(obj);
            db.SaveChanges();

            //retrieved the recrod and remove it
            sessiontype savedObj = (from d in db.sessiontypes
                                    where d.sessiontypeid == obj.sessiontypeid
                                    select d).Single();
            db.sessiontypes.Remove(savedObj);
            db.SaveChanges();

            //ensure the record is deleted from database
            sessiontype removedObj = (from d in db.sessiontypes
                                      where d.sessiontypeid == savedObj.sessiontypeid
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
            sessiontype obj = new sessiontype();

            //retrieved data
            IEnumerable<sessiontype> savedObjs = (from d in db.sessiontypes
                                           select d).ToList();

            //ensure record number is greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }

    }
}
