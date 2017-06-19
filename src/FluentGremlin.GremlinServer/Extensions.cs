using FluentGremlin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGremlin.GremlinServer
{
    public static class Extensions
    {
        public static string GetQuery<T>(this IGraphTraversal<T> traversal)
        {
            if (traversal.Provider is GremlinGraphTraversalProvider provider)
            {
                return provider.ToGremlinQuery(traversal.Expression);
            }
            throw new InvalidOperationException();
        }
    }
}
