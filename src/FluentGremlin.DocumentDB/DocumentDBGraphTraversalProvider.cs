using FluentGremlin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FluentGremlin.DocumentDB
{
    public class DocumentDBGraphTraversalProvider : IGraphTraversalProvider
    {
        public IGraphTraversal<TResult> CreateTraversal<TResult>(Expression expression)
        {
            return new GraphTraversal<TResult>(this, expression);
        }

        public Task<object> ExecuteAsync(Expression expression)
        {
            throw new NotImplementedException();
        }
    }
}
