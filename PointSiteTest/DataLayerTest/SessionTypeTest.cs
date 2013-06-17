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
    public class SessionTypeTest
    {
        PointAppDBContext db = new PointAppDBContext();
        sessiontype obj = new sessiontype();

        [TestMethod]
        public void DisplayData()
        {
            sessiontype t = (from d in db.sessiontypes select d).First();
            sessiontype saveObj = (from d in db.sessiontypes
                                   where d.sessiontypeid == t.sessiontypeid
                                   select d).Single();

            Assert.AreEqual(saveObj.sessiontypeid, t.sessiontypeid);
        }

        [TestMethod]
        public void AddNewRecord()
        {
            //set data
            obj.typename = "Add new sessiontype";
            db.sessiontypes.Add(obj);

            //save changes
            db.SaveChanges();

            //Check to see if the record is existed in database
            sessiontype savedObj = (from d in db.sessiontypes
                                    where d.sessiontypeid == obj.sessiontypeid
                                    select d).Single();

            //Assert statement
            Assert.AreEqual(savedObj.typename, obj.typename);

            //cleanup
            db.sessiontypes.Remove(savedObj);
            db.SaveChanges();
        }

        [TestMethod]
        public void UpdateRecord()
        {
            obj.typename = "Update sessiontype";
            db.sessiontypes.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            sessiontype savedObj = (from d in db.sessiontypes
                                    where d.sessiontypeid == obj.sessiontypeid
                                    select d).Single();
            savedObj.typename = "Test updated sessiontype";
            db.SaveChanges();

            //check to see if there is existing record
            sessiontype updatedObj = (from d in db.sessiontypes
                                      where d.sessiontypeid == obj.sessiontypeid
                                      select d).Single();

            Assert.AreEqual(updatedObj.typename, savedObj.typename);

            //cleanup
            db.sessiontypes.Remove(updatedObj);
            db.SaveChanges();

        }

        [TestMethod]
        public void DeleteRecord()
        {
            obj.typename = "Delete sessiontype";
            db.sessiontypes.Add(obj);
            db.SaveChanges();

            //retrieve and update the record
            sessiontype saveObj = (from d in db.sessiontypes
                                   where d.sessiontypeid == obj.sessiontypeid
                                   select d).Single();
            db.sessiontypes.Remove(saveObj);
            db.SaveChanges();

            //Check to see if the record is existed in database
            sessiontype removedObj = (from d in db.sessiontypes
                                      where d.sessiontypeid == saveObj.sessiontypeid
                                      select d).FirstOrDefault();

            //Assert statement
            Assert.IsNull(removedObj);
        }

        [TestMethod]
        public void GetListData()
        {
            obj.typename = "Get sessiontype List";
            db.sessiontypes.Add(obj);
            db.SaveChanges();

            //retrieved data
            List<sessiontype> saveObjs = (from d in db.sessiontypes
                                          select d).ToList();

            //ensure records number is greater than 0
            Assert.IsTrue(saveObjs.Count > 0);
        }
    }
}
