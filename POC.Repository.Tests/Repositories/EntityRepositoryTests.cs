using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POC.Repository.Repositories;


namespace POC.Repository.Tests.Repositories
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class EntityRepositoryTests
    {
        [TestMethod]
        public void GetListTest()
        {
            var repo = new EntityRepository();
            var list = repo.GetList();
            Assert.IsNotNull(list);
        }
    }
}
