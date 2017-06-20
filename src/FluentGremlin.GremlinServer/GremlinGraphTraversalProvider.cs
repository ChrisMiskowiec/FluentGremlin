using FluentGremlin.Core;
using System;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FluentGremlin.GremlinServer
{
    public class GremlinGraphTraversalProvider : IGraphTraversalProvider
    {
        public GremlinGraphTraversalProvider()
        {
        }

        public IGraphTraversal<TResult> CreateTraversal<TResult>(Expression expression)
        {
            return new GremlinServerGraphTraversal<TResult>(this, expression);
        }

        public Task<object> ExecuteAsync(Expression expression)
        {
            throw new NotImplementedException();
        }

        public string ToGremlinQuery(Expression expression)
        {
            var visitor = new QueryBuilderVisitor();
            return visitor.BuildQuery(expression);
        }
    }
}
