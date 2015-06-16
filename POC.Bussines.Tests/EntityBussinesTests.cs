using System;
using System.Collections.Generic;
using System.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceStack.OrmLite;
using ServiceStack.Text;
using Trintech.Cadency.DataAccess.Core;

namespace POC.Bussines.Tests
{
    [TestClass]
    public class EntityBussinesTests
    {
        [TestInitialize]
        public void TestInitialize()
        {
            OrmLiteConfig.DialectProvider = SqlServerDialect.Provider;
            IDbConnectionFactory dbConnectionFactory = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            ICadencyOrm cadencyOrm = new CadencyOrmLite(dbConnectionFactory);
            CadencyOrm.Initialize(cadencyOrm);
        }

        [TestMethod]
        public void GetListTest()
        {
            var bussines = new EntityBussines();
            var parameters = new Dictionary<string, object>
            {
                {"@userName", String.Empty},
                {"@closePeriodId", -1},
                {"@closeDayMapId", -1},
                {"@periodEndDate", null}
            };
            var result = bussines.GetList(parameters);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Count > 0);
        }
    }
}
