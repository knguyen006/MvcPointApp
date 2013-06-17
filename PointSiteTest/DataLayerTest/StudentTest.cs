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
    public class StudentTest
    {
        PointAppDBContext db = new PointAppDBContext();
        student obj = new student();

        [TestMethod]
        public void DisplayData()
        {
            student t = (from d in db.students select d).First();
            student saveObj = (from d in db.students
                               where d.studentid == t.studentid
                               select d).Single();

            Assert.AreEqual(saveObj.studentid, t.studentid);
        }

        [TestMethod]
        public void AddNewRecord()
        {
            //set data
            obj.firstname = "Add first";
            obj.lastname = "Add last";
            obj.middlename = "Add middle";
            obj.grade = 9;
            db.students.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            student savedObj = (from d in db.students
                                where d.studentid == obj.studentid
                                select d).Single();

            //Assert statement
            Assert.AreEqual(savedObj.firstname, obj.firstname);
            Assert.AreEqual(savedObj.lastname, obj.lastname);
            Assert.AreEqual(savedObj.middlename, obj.middlename);
            Assert.AreEqual(savedObj.grade, obj.grade);

            //cleanup
            db.students.Remove(savedObj);
            db.SaveChanges();
        }

        [TestMethod]
        public void UpdateRecord()
        {
            obj.firstname = "Update first";
            obj.lastname = "Update last";
            obj.middlename = "Update middle";
            obj.grade = 9;

            db.students.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            student savedObj = (from d in db.students
                                where d.studentid == obj.studentid
                                select d).Single();

            savedObj.firstname = "Update student first";
            savedObj.lastname = "Update student last";
            savedObj.middlename = "Update student middle";
            savedObj.grade = 9;

            db.SaveChanges();

            //check to see if there is existing record
            student updatedObj = (from d in db.students
                                  where d.studentid == obj.studentid
                                  select d).Single();

            //Assert statement
            Assert.AreEqual(updatedObj.firstname, savedObj.firstname);
            Assert.AreEqual(updatedObj.lastname, savedObj.lastname);
            Assert.AreEqual(updatedObj.middlename, savedObj.middlename);
            Assert.AreEqual(updatedObj.grade, savedObj.grade);

            //cleanup
            db.students.Remove(updatedObj);
            db.SaveChanges();

        }

        [TestMethod]
        public void DeleteRecord()
        {
            obj.firstname = "Delete first";
            obj.lastname = "Delete last";
            obj.middlename = "Delete middle";
            obj.grade = 9;

            db.students.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            student saveObj = (from d in db.students
                               where d.studentid == obj.studentid
                               select d).Single();
            db.students.Remove(saveObj);
            db.SaveChanges();

            //Check to see if the record is existed in database
            student removedObj = (from d in db.students
                                  where d.studentid == saveObj.studentid
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
            obj.grade = 9;

            db.students.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<student> saveObjs = (from d in db.students
                                      select d).ToList();

            //ensure records number is greater than 0
            Assert.IsTrue(saveObjs.Count > 0);
        }
    }
}
