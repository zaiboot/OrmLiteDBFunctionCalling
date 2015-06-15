using System.Collections.Generic;
using System.Data;
using System.Text;
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
            var sqlText = new StringBuilder();
            sqlText.AppendFormat(" SELECT  *  FROM {0}( ", functionName );
            if (parameters.Keys.Count > 0)
            {
                foreach (var parameterName in parameters.Keys)
                {
                    sqlText.AppendFormat("{0} ,", parameterName);
                }

                sqlText.Remove(sqlText.Length - 1, 1);
            }
            
            sqlText.Append(")");
            var results = database.SqlList<TEntity>(sqlText.ToString(), parameters);
            return results;
        }

        public IReadOnlyList<Entity> GetList(Dictionary<string, object> parameters)
        {
            const string FUNCTION_NAME = "dbo.fnGetEntityList";
            return CadencyOrm.GetByFunction<Entity>(FUNCTION_NAME, parameters);
        }
    }
}
