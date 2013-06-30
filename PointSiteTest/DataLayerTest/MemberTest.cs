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
    public class MemberTest
    {
        PointAppDBContext db = new PointAppDBContext();
        member obj = new member();

        [TestMethod]
        public void DisplayData()
        {
            member t = (from d in db.members select d).First();
            member saveObj = (from d in db.members
                              where d.memberid == t.memberid
                              select d).Single();

            Assert.AreEqual(saveObj.memberid, t.memberid);
        }

        [TestMethod]
        public void AddNewRecord()
        {
            //call fk object
            contact c = (from d in db.contacts
                         select d).First();
            student s = (from d in db.students
                         select d).First();

            //set data
            obj.username = "Addnewmember";
            obj.userpass = "Addnewpass";
            obj.passsalt = "addphrase";
            db.members.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            member savedObj = (from d in db.members
                               where d.memberid == obj.memberid
                               select d).Single();

            //Assert statement
            Assert.AreEqual(savedObj.username, obj.username);
            Assert.AreEqual(savedObj.userpass, obj.userpass);
            Assert.AreEqual(savedObj.passsalt, obj.passsalt);

            //cleanup
            db.members.Remove(savedObj);
            db.SaveChanges();
        }

        [TestMethod]
        public void UpdateRecord()
        {
            //call fk object
            contact c = (from d in db.contacts
                         select d).First();
            student s = (from d in db.students
                         select d).First();

            //set data
            obj.username = "Updatemember";
            obj.userpass = "Updatepass";
            obj.passsalt = "updatephrase";
            db.members.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            member savedObj = (from d in db.members
                               where d.memberid == obj.memberid
                               select d).Single();

            //set data
            savedObj.username = "Updatemember";
            savedObj.userpass = "Updatepass";
            savedObj.passsalt = "updatephrase";
            db.SaveChanges();

            //check to see if there is existing record
            member updatedObj = (from d in db.members
                                 where d.memberid == obj.memberid
                                 select d).Single();

            //Assert statement
            Assert.AreEqual(updatedObj.username, savedObj.username);
            Assert.AreEqual(updatedObj.userpass, savedObj.userpass);
            Assert.AreEqual(updatedObj.passsalt, savedObj.passsalt);

            //cleanup
            db.members.Remove(updatedObj);
            db.SaveChanges();

        }

        [TestMethod]
        public void DeleteRecord()
        {
            //call fk object
            contact c = (from d in db.contacts
                         select d).First();
            student s = (from d in db.students
                         select d).First();

            //set data
            obj.username = "Deletemember";
            obj.userpass = "Deletepass";
            obj.passsalt = "deletephrase";
            db.members.Add(obj);

            db.members.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            member saveObj = (from d in db.members
                              where d.memberid == obj.memberid
                              select d).Single();
            db.members.Remove(saveObj);
            db.SaveChanges();

            //Check to see if the record is existed in database
            member removedObj = (from d in db.members
                                 where d.memberid == saveObj.memberid
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
            student s = (from d in db.students
                         select d).First();

            //set data
            obj.username = "Listmember";
            obj.userpass = "listpass";
            obj.passsalt = "listpass";
            db.members.Add(obj);

            db.members.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<member> saveObjs = (from d in db.members
                                     select d).ToList();

            //ensure records number is greater than 0
            Assert.IsTrue(saveObjs.Count > 0);
        }
    }
}
