using FluentGremlin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace FluentGremlin.DocumentDB
{
    public class GraphTraversal<T> : IGraphTraversal<T>
    {
        private readonly IGraphTraversalProvider _provider;
        public IGraphTraversalProvider Provider => _provider;

        public Type ElementType => typeof(T);

        private readonly Expression _expression;
        public Expression Expression => _expression;

        public GraphTraversal(IGraphTraversalProvider provider, Expression expression)
        {
            _provider = provider;
            _expression = expression;
        }
    }
}
