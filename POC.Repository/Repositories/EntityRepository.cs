using System.Collections.Generic;
using POC.Repository.Model;
using ServiceStack.OrmLite;
using Trintech.Cadency.DataAccess.Core;

namespace POC.Repository.Repositories
{
    public class EntityRepository
    {
        public IReadOnlyList<Entity> GetList()
        {
            var database = CadencyOrm.Instance.DbConnection;
            var results = database.SqlList<Entity>(" SELECT  *  FROM dbo.fnGetEntityList ('', -1, -1, null)");
            return results; 
        }
    }
}
