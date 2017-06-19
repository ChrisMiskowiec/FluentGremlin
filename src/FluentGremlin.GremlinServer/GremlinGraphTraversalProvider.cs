using FluentGremlin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FluentGremlin.GremlinServer
{
    public class GremlinGraphTraversalProvider : IGraphTraversalProvider
    {
        public IGraphTraversal<TResult> CreateTraversal<TResult>(Expression expression)
        {
            throw new NotImplementedException();
        }

        public Task<object> ExecuteAsync(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
