using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace FluentGremlin.Core
{
    public static class GraphTraversal
    {
        public static async Task<TResult> ExecuteAsync<TResult>(this IGraphTraversal<TResult> traversal)
        {
            var result = await traversal.Provider.ExecuteAsync(traversal.Expression);
            return (TResult)result;
        }

        public static IGraphTraversal<Vertex> V(this IGraphTraversalSource source)
        {
            return source.Provider.CreateTraversal<Vertex>(Expression.Call(
                null,
                new Func<IGraphTraversalSource, IGraphTraversal<Vertex>>(GraphTraversal.V).GetMethodInfo(),
                Expression.Constant(source)));
        }

        public static IGraphTraversal<Vertex> V<TId>(this IGraphTraversalSource source, TId id)
        {
            return source.Provider.CreateTraversal<Vertex>(Expression.Call(
                null,
                new Func<IGraphTraversalSource, TId, IGraphTraversal<Vertex>>(GraphTraversal.V).GetMethodInfo().GetGenericMethodDefinition().MakeGenericMethod(typeof(TId)),
                Expression.Constant(source),
                Expression.Constant(id)));
        }

        public static IGraphTraversal<Vertex> Out(this IGraphTraversal<Vertex> source, string edgeLabel)
        {
            return source.Provider.CreateTraversal<Vertex>(Expression.Call(
                null,
                new Func<IGraphTraversal<Vertex>, string, IGraphTraversal<Vertex>>(GraphTraversal.Out).GetMethodInfo(),
                source.Expression,
                Expression.Quote(source.Expression)
                ));
        }
    }

    internal static class CachedReflectionInfo
    {
        private static MethodInfo s_Out_1;

        public static MethodInfo Out_1(Type TSource) =>
             (s_Out_1 ??
             (s_Out_1 = new Func<IQueryable<object>, Expression<Func<object, object, object>>, object>(Queryable.Aggregate).GetMethodInfo().GetGenericMethodDefinition()))
              .MakeGenericMethod(TSource);
    }
}
