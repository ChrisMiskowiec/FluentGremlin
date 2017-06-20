using FluentGremlin.Core;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Collections;

namespace FluentGremlin.GremlinServer
{
    public class GremlinServerGraphTraversal<TResult> : IGraphTraversal<TResult>
    {
        private readonly IGraphTraversalProvider _provider;
        public IGraphTraversalProvider Provider => _provider;

        public Type ElementType => typeof(TResult);

        private readonly Expression _expression;
        public Expression Expression => _expression;

        public GremlinServerGraphTraversal(IGraphTraversalProvider provider)
            : this(provider, null)
        {
        }

        public GremlinServerGraphTraversal(
            IGraphTraversalProvider provider,
            Expression expression)
        {
            _provider = provider;
            _expression = expression;
        }
    }
}
