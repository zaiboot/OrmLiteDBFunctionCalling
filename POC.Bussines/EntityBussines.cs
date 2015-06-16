using System.Collections;
using System.Collections.Generic;
using System.Linq;
using POC.Repository.Model;
using POC.Repository.Repositories;

namespace POC.Bussines
{
    public class EntityBussines
    {
        public IReadOnlyCollection<Model.Entity> GetList(Dictionary<string, object> parameters)
        {
            var repo = new EntityRepository();

            //remove duplicates, 
            var list = repo.GetList(parameters).Distinct().ToList();
            var result = new List<Model.Entity>();
            foreach (var entity in list)
            {
                //We really dont need all the list to be copied again, just the parent ones.
                if (entity.ParentId.HasValue && entity.ParentId.Value > 0 )
                {
                    continue;
                }
                var bizModel = new Model.Entity
                {
                    Id = entity.Id
                };
                bizModel.Entities =  FillChildren(bizModel.Id, list);
                result.Add(bizModel);
            }
            result.Sort();
            return result;
        }

        private static IEnumerable<Model.Entity> FillChildren(int parentId, IReadOnlyList<Entity> allEntities)
        {
            var children = new List<Model.Entity>();

            foreach (var entityChildren in allEntities)
            {
                if (entityChildren.ParentId == parentId)
                {
                    var mappedChildren = new Model.Entity
                    {
                        Id = entityChildren.Id,
                        Entities = FillChildren(entityChildren.Id, allEntities)
                    };
                    children.Add(mappedChildren);
                }
            }

            children.Sort();
            return children;

        }
    }
}
