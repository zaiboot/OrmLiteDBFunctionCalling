using System;
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
            
        }
        [TestMethod]
        public void GetListTest()
        {
            IDbConnectionFactory dbConnectionFactory = new OrmLiteConnectionFactory(ConfigurationManager.ConnectionStrings["constr"].ConnectionString);
            ICadencyOrm cadencyOrm = new CadencyOrmLite(dbConnectionFactory);
            CadencyOrm.Initialize(cadencyOrm);
            var repo = new EntityRepository();
            var list = repo.GetList();
            Assert.IsNotNull(list);
        }
    }
}
