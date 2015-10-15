using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AccountService;
using SchoolEntities;

namespace SchoolTestProject
{
    [TestClass]
    public class SchoolLogin
    {
        [TestMethod]
        public void TestMethod1()
        {
            var db = new ApplicationDbContext();
            db.Database.CreateIfNotExists();
        }

        [TestMethod]
        public void CraeteSchoolDb()
        {
            var db = new SchoolDb();
            db.Database.CreateIfNotExists();
        }
    }
}
