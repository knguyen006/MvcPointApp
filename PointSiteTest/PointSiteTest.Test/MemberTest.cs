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
    public class MemberTest
    {

        /// <summary>
        /// Test Method to Connect to the repository and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void DisplayData()
        {
            PointAppDBContainer db = new PointAppDBContainer();

            member savedObj = (from d in db.members
                                where d.memberid == 2
                                select d).Single();

            Assert.AreEqual(savedObj.memberid, 2);
        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void AddNewRecord()
        {
            // call database object
            PointAppDBContainer db = new PointAppDBContainer();
            //thinking to take the member fk out
            //but later
            //member m = (from d in db.members select d).First();
            approle r = (from d in db.approles select d).First();
            member obj = new member();
            
            //set data
            obj.username = "testuser";
            obj.userpass = "newpass";
            obj.passphrase = "what's your name?";
            obj.membertype = "Parent";
            obj.approleid = r.approleid;
            db.members.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            member savedObj = (from d in db.members 
                                where d.memberid == obj.memberid 
                                select d).Single();

            // Assert statement
            Assert.AreEqual(savedObj.username, obj.username);
            Assert.AreEqual(savedObj.userpass, obj.userpass);
            Assert.AreEqual(savedObj.passphrase, obj.passphrase);
            Assert.AreEqual(savedObj.membertype, obj.membertype);
            Assert.AreEqual(savedObj.approleid, obj.approleid);

            //cleanup
            db.members.Remove(savedObj);
            db.SaveChanges();

        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            //thinking to take the member fk out
            //but later
            //member m = (from d in db.members select d).First();
            approle r = (from d in db.approles select d).First();
            member obj = new member();

            //set data
            obj.username = "testuser";
            obj.userpass = "newpass";
            obj.passphrase = "what's your name?";
            obj.membertype = "Parent";
            obj.approleid = r.approleid;

            db.members.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            member savedObj = (from d in db.members
                                where d.memberid == obj.memberid
                                select d).Single();
            savedObj.username = "testupdated";
            savedObj.userpass = "newpass";
            savedObj.passphrase = "this is updated test.";
            savedObj.membertype = "Parent";
            savedObj.approleid = r.approleid;
            db.SaveChanges();

            //check to see if there is existing record
            member updatedObj = (from d in db.members
                                  where d.memberid == obj.memberid
                                  select d).Single();

            Assert.AreEqual(updatedObj.username, savedObj.username);
            Assert.AreEqual(updatedObj.userpass, savedObj.userpass);
            Assert.AreEqual(updatedObj.passphrase, savedObj.passphrase);
            Assert.AreEqual(updatedObj.membertype, savedObj.membertype);
            Assert.AreEqual(updatedObj.approleid, savedObj.approleid);

            //cleanup
            db.members.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            //thinking to take the member fk out
            //but later
            //member m = (from d in db.members select d).First();
            approle r = (from d in db.approles select d).First();
            member obj = new member();

            //set data
            obj.username = "deleteuser";
            obj.userpass = "newpass";
            obj.passphrase = "what's your name?";
            obj.membertype = "Parent";
            obj.approleid = r.approleid;

            db.members.Add(obj);
            db.SaveChanges();

            //retrieved the recrod and remove it
            member savedObj = (from d in db.members
                                where d.memberid == obj.memberid
                                select d).Single();
            db.members.Remove(savedObj);
            db.SaveChanges();

            //ensure the record is deleted from database
            member removedObj = (from d in db.members
                                  where d.memberid == savedObj.memberid
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
            //thinking to take the member fk out
            //but later
            //member m = (from d in db.members select d).First();
            approle r = (from d in db.approles select d).First();
            member obj = new member();

            //set data
            obj.username = "listuser";
            obj.userpass = "newpass";
            obj.passphrase = "what's your name?";
            obj.membertype = "Parent";
            obj.approleid = r.approleid;

            db.members.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<member> savedObjs = (from d in db.members 
                                       select d).ToList();

            //ensure record number is greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }

    }
}
