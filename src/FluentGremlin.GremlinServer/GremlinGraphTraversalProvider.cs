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
            switch (expression)
            {
                case MethodCallExpression methodCall:
                    return ToGremlinQuery(methodCall.Arguments[0]) + "." + methodCall.Method.Name + "()";

                case ConstantExpression constant:
                    if (constant.Value is GremlinServerSource)
                    {
                        return "g";
                    }
                    else
                    {
                        throw new InvalidOperationException("Unknown constant");
                    }
                default:
                    throw new InvalidOperationException("Unknown expression");
            }
        }
    }
}
