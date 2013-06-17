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
    public class ContactTest
    {
        PointAppDBContext db = new PointAppDBContext();
        contact obj = new contact();

        [TestMethod]
        public void DisplayData()
        {
            contact t = (from d in db.contacts select d).First();
            contact saveObj = (from d in db.contacts
                               where d.contactid == t.contactid
                               select d).Single();

            Assert.AreEqual(saveObj.contactid, t.contactid);
        }

        [TestMethod]
        public void AddNewRecord()
        {
            //set data
            obj.firstname = "Add first";
            obj.lastname = "Add last";
            obj.middlename = "Add middle";
            obj.address = "Add Address";
            obj.altaddress = "Add Alt address";
            obj.city = "Add city";
            obj.state = "CO";
            obj.zip = "00000";
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

            //Assert statement
            Assert.AreEqual(savedObj.firstname, obj.firstname);
            Assert.AreEqual(savedObj.lastname, obj.lastname);
            Assert.AreEqual(savedObj.middlename, obj.middlename);
            Assert.AreEqual(savedObj.address, obj.address);
            Assert.AreEqual(savedObj.altaddress, obj.altaddress);
            Assert.AreEqual(savedObj.city, obj.city);
            Assert.AreEqual(savedObj.state, obj.state);
            Assert.AreEqual(savedObj.zip, obj.zip);
            Assert.AreEqual(savedObj.homephone, obj.homephone);
            Assert.AreEqual(savedObj.workphone, obj.workphone);
            Assert.AreEqual(savedObj.mobilephone, obj.mobilephone);

            //cleanup
            db.contacts.Remove(savedObj);
            db.SaveChanges();
        }

        [TestMethod]
        public void UpdateRecord()
        {
            obj.firstname = "Update first";
            obj.lastname = "Update last";
            obj.middlename = "Update middle";
            obj.address = "Update Address";
            obj.altaddress = "Update Alt address";
            obj.city = "Update city";
            obj.state = "CO";
            obj.zip = "00000";
            obj.homephone = "123-456-7890";
            obj.workphone = "098-765-4321";
            obj.mobilephone = "111-222-3333";

            db.contacts.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            contact savedObj = (from d in db.contacts
                                where d.contactid == obj.contactid
                                select d).Single();

            savedObj.firstname = "Update update first";
            savedObj.lastname = "Update update last";
            savedObj.middlename = "Update middle";
            savedObj.address = "Update Address";
            savedObj.altaddress = "Update Alt address";
            savedObj.city = "Update city";
            savedObj.state = "CO";
            savedObj.zip = "00000";
            savedObj.homephone = "123-456-7890";
            savedObj.workphone = "098-765-4321";
            savedObj.mobilephone = "111-222-3333";

            db.SaveChanges();

            //check to see if there is existing record
            contact updatedObj = (from d in db.contacts
                                  where d.contactid == obj.contactid
                                  select d).Single();

            //Assert statement
            Assert.AreEqual(updatedObj.firstname, savedObj.firstname);
            Assert.AreEqual(updatedObj.lastname, savedObj.lastname);
            Assert.AreEqual(updatedObj.middlename, savedObj.middlename);
            Assert.AreEqual(updatedObj.address, savedObj.address);
            Assert.AreEqual(updatedObj.altaddress, savedObj.altaddress);
            Assert.AreEqual(updatedObj.city, savedObj.city);
            Assert.AreEqual(updatedObj.state, savedObj.state);
            Assert.AreEqual(updatedObj.zip, savedObj.zip);
            Assert.AreEqual(updatedObj.homephone, savedObj.homephone);
            Assert.AreEqual(updatedObj.workphone, savedObj.workphone);
            Assert.AreEqual(updatedObj.mobilephone, savedObj.mobilephone);

            //cleanup
            db.contacts.Remove(updatedObj);
            db.SaveChanges();

        }

        [TestMethod]
        public void DeleteRecord()
        {
            obj.firstname = "Delete first";
            obj.lastname = "Delete last";
            obj.middlename = "Delete middle";
            obj.address = "Delete Address";
            obj.altaddress = "Delete Alt address";
            obj.city = "Delete city";
            obj.state = "CO";
            obj.zip = "00000";
            obj.homephone = "123-456-7890";
            obj.workphone = "098-765-4321";
            obj.mobilephone = "111-222-3333";

            db.contacts.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            contact saveObj = (from d in db.contacts
                               where d.contactid == obj.contactid
                               select d).Single();
            db.contacts.Remove(saveObj);
            db.SaveChanges();

            //Check to see if the record is existed in database
            contact removedObj = (from d in db.contacts
                                  where d.contactid == saveObj.contactid
                                  select d).FirstOrDefault();

            //Assert statement
            Assert.IsNull(removedObj);
        }

        [TestMethod]
        public void GetListData()
        {
            obj.firstname = "List first";
            obj.lastname = "List last";
            obj.middlename = "List middle";
            obj.address = "List Address";
            obj.altaddress = "List Alt address";
            obj.city = "List city";
            obj.state = "CO";
            obj.zip = "00000";
            obj.homephone = "123-456-7890";
            obj.workphone = "098-765-4321";
            obj.mobilephone = "111-222-3333";

            db.contacts.Add(obj);
            db.SaveChanges();

            //retrieved data
           List<contact> saveObjs = (from d in db.contacts
                                      select d).ToList();

            //ensure records number is greater than 0
            Assert.IsTrue(saveObjs.Count > 0);
        }
    }
}
