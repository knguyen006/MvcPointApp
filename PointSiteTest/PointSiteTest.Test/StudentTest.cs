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
    public class StudentTest
    {
        /// <summary>
        /// Create database if the database is not existed.
        /// </summary>
        [ClassInitialize]
        public static void DataLayerSetup(TestContext testContext)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<PointAppDBContainer>());

            var context = new PointAppDBContainer();
            context.Database.Create();
        }

        /// <summary>
        /// Test Method to Connect to the repository and see if there are any records.
        /// This should fail if you have an empty table
        /// </summary>
        [TestMethod]
        public void DisplayData()
        {
            PointAppDBContainer db = new PointAppDBContainer();

            student savedObj = (from d in db.students
                                where d.studentid == 1
                                select d).Single();

            Assert.AreEqual(savedObj.studentid, 1);
        }

        /// <summary>
        /// Test Method to Connect to the repository and add a record
        /// </summary>
        [TestMethod]
        public void AddNewRecord()
        {
            // call database object
            PointAppDBContainer db = new PointAppDBContainer();
            student obj = new student();
            
            //set data
            obj.firstname = "Don";
            obj.lastname = "Joe";
            obj.middlename = "T.";
            obj.grade = 9;
            obj.active = "Y";
            db.students.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            student savedObj = (from d in db.students 
                                where d.studentid == obj.studentid 
                                select d).Single();

            // Assert statement
            Assert.AreEqual(savedObj.firstname, obj.firstname);
            Assert.AreEqual(savedObj.lastname, obj.lastname);
            Assert.AreEqual(savedObj.middlename, obj.middlename);
            Assert.AreEqual(savedObj.grade, obj.grade);
            Assert.AreEqual(savedObj.active, obj.active);

            //cleanup
            db.students.Remove(savedObj);
            db.SaveChanges();

        }

        /// <summary>
        /// Test Method to Connect to the repository and update a record
        /// </summary>
        [TestMethod]
        public void UpdateRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            student obj = new student();
            obj.firstname = "Jon";
            obj.lastname = "Doe";
            obj.middlename = "T.";
            obj.grade = 10;
            obj.active = "Y";
            db.students.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            student savedObj = (from d in db.students
                                where d.studentid == obj.studentid
                                select d).Single();
            savedObj.firstname = "Jon 2";
            savedObj.lastname = "Doe 2";
            savedObj.middlename = "T.";
            savedObj.grade = 10;
            savedObj.active = "Y";
            db.SaveChanges();

            //check to see if there is existing record
            student updatedObj = (from d in db.students
                                  where d.studentid == obj.studentid
                                  select d).Single();

            Assert.AreEqual(updatedObj.firstname, savedObj.firstname);
            Assert.AreEqual(updatedObj.lastname, savedObj.lastname);
            Assert.AreEqual(updatedObj.grade, savedObj.grade);
            Assert.AreEqual(updatedObj.active, savedObj.active);

            //cleanup
            db.students.Remove(updatedObj);
            db.SaveChanges();
        }

        /// <summary>
        /// Test Method to Connect to the repository and delete a record
        /// </summary>
        [TestMethod]
        public void DeleteRecord()
        {
            PointAppDBContainer db = new PointAppDBContainer();
            student obj = new student();
            obj.firstname = "Don";
            obj.lastname = "Joe";
            obj.middlename = "T.";
            obj.grade = 9;
            obj.active = "Y";
            db.students.Add(obj);
            db.SaveChanges();

            //retrieved the recrod and remove it
            student savedObj = (from d in db.students
                                where d.studentid == obj.studentid
                                select d).Single();
            db.students.Remove(savedObj);
            db.SaveChanges();

            //ensure the record is deleted from database
            student removedObj = (from d in db.students
                                  where d.studentid == savedObj.studentid
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
            student obj = new student();
            obj.firstname = "Don";
            obj.lastname = "Joe";
            obj.middlename = "T.";
            obj.grade = 9;
            obj.active = "Y";
            db.students.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<student> savedObjs = (from d in db.students 
                                       select d).ToList();

            //ensure record number is greater than 0
            Assert.IsTrue(savedObjs.Count > 0);
        }

    }
}
