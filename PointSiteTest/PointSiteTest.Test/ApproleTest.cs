using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DataLayer;
//using NUnit.Framework;

namespace PointSiteTest.Test
{
    [TestClass]
    public class ApproleTest
    {
        [TestMethod]
        public void add_test()
        {
            var test_role = new ApproleHelp();
            string newrole = test_role.addName("Test");
            string newnote = test_role.addNote("This role has only testing permission");
            Assert.AreEqual<string>(newrole, newnote, "Add new role");
        }

    }
}
