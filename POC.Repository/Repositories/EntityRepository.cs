using System.Collections.Generic;
using System.Data;
using POC.Repository.Model;
using ServiceStack.OrmLite;
using Trintech.Cadency.DataAccess.Core;

namespace POC.Repository.Repositories
{
    public class EntityRepository
    {
        private static IReadOnlyList<TEntity> GetListFromFunction<TEntity>(string functionName, Dictionary<string, object> parameters)
        {
            var database = CadencyOrm.Instance.DbConnection;
            var results = database.SqlList<TEntity>(" SELECT  *  FROM " + functionName + " (@userName, @closePeriodId, @closeDayMapId, @periodEndDate)", parameters);
            return results;
        }

        public IReadOnlyList<Entity> GetList(Dictionary<string, object> parameters)
        {
            const string FUNCTION_NAME = "dbo.fnGetEntityList";

            return GetListFromFunction<Entity>(FUNCTION_NAME, parameters);
        }
    }
}
