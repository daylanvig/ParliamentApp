using ParliamentApp.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace ParliamentApp.Infrastructure
{
    public class QueryBuilder<TEntity> where TEntity : Entity
    {
        private readonly List<Expression<Func<TEntity, bool>>> _filters = new();
        

        public QueryBuilder<TEntity> AddCondition(Expression<Func<TEntity, bool>> condition)
        {
            _filters.Add(condition);
            return this;
        }

        public QueryBuilder<TEntity> AddConditionIfNotNull(Expression<Func<TEntity, bool>> condition, int? parameter)
        {
            if (parameter.HasValue)
            {
                AddCondition(condition);
            }
            return this;
        }

        public Expression<Func<TEntity, bool>> BuildWhereCondition()
        {
            throw new NotImplementedException();
        }
    }
}
