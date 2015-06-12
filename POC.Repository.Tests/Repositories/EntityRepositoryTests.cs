using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC.Repository.Repositories;
using ServiceStack.OrmLite;
using Trintech.Cadency.DataAccess.Core;


namespace POC.Repository.Tests.Repositories
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EntityRepositoryTests
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
            var repo = new EntityRepository();
            var parameters = new Dictionary<string, object>
            {
                {"@userName", String.Empty},
                {"@closePeriodId", -1},
                {"@closeDayMapId", -1},
                {"@periodEndDate", null}
            };

            var list = repo.GetList(parameters);
            Assert.IsNotNull(list);
        }
    }
}
