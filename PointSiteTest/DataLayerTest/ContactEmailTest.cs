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
    public class ContactEmailTest
    {
        PointAppDBContext db = new PointAppDBContext();
        contactemail obj = new contactemail();

        [TestMethod]
        public void DisplayData()
        {
            contactemail t = (from d in db.contactemails select d).First();
            contactemail saveObj = (from d in db.contactemails
                                    where d.contactemailid == t.contactemailid
                                    select d).Single();

            Assert.AreEqual(saveObj.contactemailid, t.contactemailid);
        }

        [TestMethod]
        public void AddNewRecord()
        {
            //call fk object
            contact c = (from d in db.contacts
                         select d).First();

            //set data
            obj.emailaddress = "Add new contactemail";
            obj.contactid = c.contactid;
            db.contactemails.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            contactemail savedObj = (from d in db.contactemails
                                     where d.contactemailid == obj.contactemailid
                                     select d).Single();

            //Assert statement
            Assert.AreEqual(savedObj.emailaddress, obj.emailaddress);
            Assert.AreEqual(savedObj.contactid, obj.contactid);

            //cleanup
            db.contactemails.Remove(savedObj);
            db.SaveChanges();
        }

        [TestMethod]
        public void UpdateRecord()
        {
            //call fk object
            contact c = (from d in db.contacts
                         select d).First();

            //set data
            obj.emailaddress = "Update contactemail";
            obj.contactid = c.contactid;
            db.contactemails.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            contactemail savedObj = (from d in db.contactemails
                                     where d.contactemailid == obj.contactemailid
                                     select d).Single();
            savedObj.emailaddress = "Test updated contactemail";
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

        [TestMethod]
        public void DeleteRecord()
        {
            //call fk object
            contact c = (from d in db.contacts
                         select d).First();

            obj.emailaddress = "Delete contactemail";
            obj.contactid = c.contactid;

            db.contactemails.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            contactemail saveObj = (from d in db.contactemails
                                    where d.contactemailid == obj.contactemailid
                                    select d).Single();
            db.contactemails.Remove(saveObj);
            db.SaveChanges();

            //Check to see if the record is existed in database
            contactemail removedObj = (from d in db.contactemails
                                       where d.contactemailid == saveObj.contactemailid
                                       select d).FirstOrDefault();

            //Assert statement
            Assert.IsNull(removedObj);
        }

        [TestMethod]
        public void GetListData()
        {
            //call fk object
            contact c = (from d in db.contacts
                         select d).First();

            obj.emailaddress = "Get contactemail List";
            obj.contactid = c.contactid;

            db.contactemails.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<contactemail> saveObjs = (from d in db.contactemails
                                           select d).ToList();

            //ensure records number is greater than 0
            Assert.IsTrue(saveObjs.Count > 0);
        }
    }
}
