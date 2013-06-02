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
    public class ContactEmailTest
    {

        /// <summary>
        /// Test Method to Connect to the repository and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void DisplayData()
        {
            PointAppDBContainer db = new PointAppDBContainer();

            contactemail savedObj = (from d in db.contactemails
                                where d.contactemailid == 2
                                select d).Single();

            Assert.AreEqual(savedObj.contactemailid, 2);
        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void AddNewRecord()
        {
            // call database object
            PointAppDBContainer db = new PointAppDBContainer();
            contact c = (from d in db.contacts select d).First();
            contactemail obj = new contactemail();
            
            //set data
            obj.emailaddress = "testabc@nothing.com";
            obj.contactid = c.contactid;
            db.contactemails.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            contactemail savedObj = (from d in db.contactemails 
                                where d.contactemailid == obj.contactemailid 
                                select d).Single();

            // Assert statement
            Assert.AreEqual(savedObj.emailaddress, obj.emailaddress);
            Assert.AreEqual(savedObj.contactid, obj.contactid);

            //cleanup
            db.contactemails.Remove(savedObj);
            db.SaveChanges();

        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            contact c = (from d in db.contacts select d).First();
            contactemail obj = new contactemail();
            obj.emailaddress = "testabc2@nothing.com";
            obj.contactid = c.contactid;
            db.contactemails.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            contactemail savedObj = (from d in db.contactemails
                                where d.contactemailid == obj.contactemailid
                                select d).Single();
            savedObj.emailaddress = "testabc2@nothing.com";
            savedObj.contactid = c.contactid;
            db.SaveChanges();

            //check to see if there is existing record
            contactemail updatedObj = (from d in db.contactemails
                                  where d.contactemailid == obj.contactemailid
                                  select d).Single();

            Assert.AreEqual(updatedObj.emailaddress, savedObj.emailaddress);
            Assert.AreEqual(updatedObj.contactid, savedObj.contactid);

            //cleanup
            db.contactemails.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            contact c = (from d in db.contacts select d).First();
            contactemail obj = new contactemail();
            obj.emailaddress = "testdelete@nothing.com";
            obj.contactid = c.contactid;
            db.contactemails.Add(obj);
            db.SaveChanges();

            //retrieved the recrod and remove it
            contactemail savedObj = (from d in db.contactemails
                                where d.contactemailid == obj.contactemailid
                                select d).Single();
            db.contactemails.Remove(savedObj);
            db.SaveChanges();

            //ensure the record is deleted from database
            contactemail removedObj = (from d in db.contactemails
                                  where d.contactemailid == savedObj.contactemailid
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
            contact c = (from d in db.contacts select d).First();
            contactemail obj = new contactemail();
            obj.emailaddress = "testlist@nothing.com";
            obj.contactid = c.contactid;
            db.contactemails.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<contactemail> savedObjs = (from d in db.contactemails 
                                       select d).ToList();

            //ensure record number is greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }

    }
}
