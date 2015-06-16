using System;
using System.Collections;
using System.Collections.Generic;

namespace POC.Bussines.Model
{
    public class Entity : Record, IComparable
    {
        public string Number;

        public string Name;

        public int ClosePeriodId;

        public int ParentId;

        public int DefinitionId;

        public int TaskTreeId;

        public IEnumerable<Model.Entity> Entities;

        public int CompareTo(object obj)
        {
            var compare = (Entity)obj;
            int result = String.Compare(Number, compare.Number, StringComparison.Ordinal);
            if (result == 0)
                result = String.Compare(Number, compare.Number, StringComparison.Ordinal);
            return result;
        }
    }
}
