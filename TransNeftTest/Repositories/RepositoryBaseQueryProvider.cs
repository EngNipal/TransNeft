using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace TransNeftTest.Repositories
{
    public class RepositoryBaseQueryProvider<TEntity> : IQueryProvider where TEntity : class
    {
        private readonly Type _queryType;
        private readonly DbSet<TEntity> _targetDbSet;

        public RepositoryBaseQueryProvider(DbSet<TEntity> targetDbSet)
        {
            _queryType = typeof(RepositoryBase<>);
            _targetDbSet = targetDbSet;
        }

        public IQueryable CreateQuery(Expression expression)
        {
            var elementType = expression.Type.GetElementType();
            try
            {
                return (IQueryable)Activator.CreateInstance(_queryType.MakeGenericType(elementType), new object[] { this, expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        public object Execute(Expression expression)
        {
            try
            {
                return GetType().GetMethods()
                        .Single(m => m.Name == nameof(Execute) && m.IsGenericMethodDefinition)
                        .Invoke(this, new[] { expression });
            }
            catch (TargetInvocationException tie)
            {
                throw tie.InnerException;
            }
        }

        // See https://msdn.microsoft.com/en-us/library/bb546158.aspx for more details
        public TResult Execute<TResult>(Expression expression)
        {
            IQueryable<TEntity> newRoot = _targetDbSet;
            var treeCopier = new RootReplacingVisitor(newRoot);
            var newExpressionTree = treeCopier.Visit(expression);
            var isEnumerable = (typeof(TResult).IsGenericType && typeof(TResult).GetGenericTypeDefinition() == typeof(IEnumerable<>));
            if (isEnumerable)
            {
                return (TResult)newRoot.Provider.CreateQuery(newExpressionTree);
            }
            var result = newRoot.Provider.Execute(newExpressionTree);
            return (TResult)result;
        }

        public IQueryable<T> CreateQuery<T>(Expression expression)
        {
            var elementType = expression.Type.GetElementType();
            var type = _queryType.MakeGenericType(elementType);
            return (IQueryable<T>)Activator.CreateInstance(type, new object[] { this, expression });
        }

        internal class RootReplacingVisitor : ExpressionVisitor
        {
            private IQueryable<TEntity> newRoot;

            public RootReplacingVisitor(IQueryable<TEntity> newRoot)
            {
                this.newRoot = newRoot;
            }

            protected override Expression VisitConstant(ConstantExpression node)
            {
                return node.Type.BaseType != null
                    && node.Type.BaseType.IsGenericType
                    && node.Type.BaseType.GetGenericTypeDefinition() == typeof(RepositoryBase<>) ? Expression.Constant(newRoot) : node;
            }
        }
    }
}