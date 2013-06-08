﻿using System;
using System.Collections.Generic;
using System.Web;
using DataLayer;
using System.Linq;
using System.Data;
using System.Data.Entity;

/// <summary>
/// Summary description for ActivityRepositoryImpl
/// </summary>
namespace DataLayerService
{
    public class AppRoleSvcImpl : IAppRoleSvc
    {
        private PointAppDBContainer db = new PointAppDBContainer();

        public approle Find(int approleid)
        {
            return db.approles.Find(approleid);
        }

        public List<approle> GetAll()
        {
            return db.approles.ToList();
        }

        public void AddRole(approle newrole)
        {
            db.approles.Add(newrole);
            db.SaveChanges();
        }

        public void UpdateRole(approle newrole)
        {
            db.Entry(newrole).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteRole(approle newrole)
        {
            db.approles.Remove(newrole);
            db.SaveChanges();
        }
    }
}