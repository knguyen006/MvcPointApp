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
    public class ContactTest
    {

        /// <summary>
        /// Test Method to Connect to the repository and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void DisplayData()
        {
            PointAppDBContainer db = new PointAppDBContainer();

            contact savedObj = (from d in db.contacts
                                where d.contactid == 4
                                select d).Single();

            Assert.AreEqual(savedObj.contactid, 4);
        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void AddNewRecord()
        {
            // call database object
            PointAppDBContainer db = new PointAppDBContainer();
            contact obj = new contact();
            
            //set data
            obj.firstname = "Jon";
            obj.lastname = "Doe";
            obj.middlename = "T.";
            obj.address = "123 Testing";
            obj.altaddress = "Nothing";
            obj.city = "Denver";
            obj.state = "CO";
            obj.zip = "800001";
            obj.homephone = "123-456-7890";
            obj.workphone = "098-765-4321";
            obj.mobilephone = "111-222-3333";
            db.contacts.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            contact savedObj = (from d in db.contacts 
                                where d.contactid == obj.contactid 
                                select d).Single();

            // Assert statement
            Assert.AreEqual(savedObj.firstname, obj.firstname);
            Assert.AreEqual(savedObj.lastname, obj.lastname);
            Assert.AreEqual(savedObj.middlename, obj.middlename);
            Assert.AreEqual(savedObj.address, obj.address);
            Assert.AreEqual(savedObj.altaddress, obj.altaddress);
            Assert.AreEqual(savedObj.city, obj.city);
            Assert.AreEqual(savedObj.state, obj.state);
            Assert.AreEqual(savedObj.homephone, obj.homephone);
            Assert.AreEqual(savedObj.workphone, obj.workphone);
            Assert.AreEqual(savedObj.mobilephone, obj.mobilephone);

            //cleanup
            db.contacts.Remove(savedObj);
            db.SaveChanges();

        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            contact obj = new contact();
            obj.firstname = "Jon";
            obj.lastname = "Doe";
            obj.middlename = "T.";
            obj.address = "123 Testing";
            obj.altaddress = "Nothing";
            obj.city = "Denver";
            obj.state = "CO";
            obj.zip = "800001";
            obj.homephone = "123-456-7890";
            obj.workphone = "098-765-4321";
            obj.mobilephone = "111-222-3333";
            db.contacts.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            contact savedObj = (from d in db.contacts
                                where d.contactid == obj.contactid
                                select d).Single();
            savedObj.firstname = "Jon Update";
            savedObj.lastname = "Doe";
            savedObj.middlename = "T.";
            savedObj.address = "123 Testing";
            savedObj.altaddress = "Nothing";
            savedObj.city = "Denver";
            savedObj.state = "CO";
            savedObj.zip = "800001";
            savedObj.homephone = "123-456-7890";
            savedObj.workphone = "098-765-4321";
            savedObj.mobilephone = "111-222-3333";

            db.SaveChanges();

            //check to see if there is existing record
            contact updatedObj = (from d in db.contacts
                                  where d.contactid == obj.contactid
                                  select d).Single();

            Assert.AreEqual(updatedObj.firstname, savedObj.firstname);
            Assert.AreEqual(updatedObj.lastname, savedObj.lastname);
            Assert.AreEqual(updatedObj.middlename, savedObj.middlename);
            Assert.AreEqual(updatedObj.address, savedObj.address);
            Assert.AreEqual(updatedObj.altaddress, savedObj.altaddress);
            Assert.AreEqual(updatedObj.city, savedObj.city);
            Assert.AreEqual(updatedObj.state, savedObj.state);
            Assert.AreEqual(updatedObj.homephone, savedObj.homephone);
            Assert.AreEqual(updatedObj.workphone, savedObj.workphone);
            Assert.AreEqual(updatedObj.mobilephone, savedObj.mobilephone);

            //cleanup
            db.contacts.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            contact obj = new contact();
            obj.firstname = "Jon Delete";
            obj.lastname = "Doe";
            obj.middlename = "T.";
            obj.address = "123 Testing";
            obj.altaddress = "Nothing";
            obj.city = "Denver";
            obj.state = "CO";
            obj.zip = "800001";
            obj.homephone = "123-456-7890";
            obj.workphone = "098-765-4321";
            obj.mobilephone = "111-222-3333";
            db.contacts.Add(obj);
            db.SaveChanges();

            //retrieved the recrod and remove it
            contact savedObj = (from d in db.contacts
                                where d.contactid == obj.contactid
                                select d).Single();
            db.contacts.Remove(savedObj);
            db.SaveChanges();

            //ensure the record is deleted from database
            contact removedObj = (from d in db.contacts
                                  where d.contactid == savedObj.contactid
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
            contact obj = new contact();
            obj.firstname = "Jon List";
            obj.lastname = "Doe";
            obj.middlename = "T.";
            obj.address = "123 Testing";
            obj.altaddress = "Nothing";
            obj.city = "Denver";
            obj.state = "CO";
            obj.zip = "800001";
            obj.homephone = "123-456-7890";
            obj.workphone = "098-765-4321";
            obj.mobilephone = "111-222-3333";
            db.contacts.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<contact> savedObjs = (from d in db.contacts 
                                       select d).ToList();

            //ensure record number is greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }

    }
}
