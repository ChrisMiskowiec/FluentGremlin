using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace FluentGremlin.Core
{
    public static class GraphTraversal
    {
        //public static async Task<TResult> ExecuteAsync<TResult>(this IGraphTraversal<TResult> traversal)
        //{
        //    var result = await traversal.Provider.ExecuteAsync(traversal.Expression);
        //    return (TResult)result;
        //}

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

        public static IGraphTraversal<Edge> AddE(this IGraphTraversalSource source, string label)
        {
            return source.Provider.CreateTraversal<Edge>(Expression.Call(
                null,
                new Func<IGraphTraversalSource, string, IGraphTraversal<Edge>>(GraphTraversal.AddE).GetMethodInfo(),
                Expression.Constant(source),
                Expression.Constant(label)));
        }

        public static IGraphTraversal<Edge> AddE<TSource>(this IGraphTraversal<TSource> source, string label)
        {
            return source.Provider.CreateTraversal<Edge>(Expression.Call(
                null,
                new Func<IGraphTraversal<TSource>, string, IGraphTraversal<Edge>>(GraphTraversal.AddE).GetMethodInfo(),
                source.Expression,
                Expression.Constant(label)));
        }

        public static IGraphTraversal<Edge> AddV(this IGraphTraversalSource source, string label)
        {
            return source.Provider.CreateTraversal<Edge>(Expression.Call(
                null,
                new Func<IGraphTraversalSource, string, IGraphTraversal<Edge>>(GraphTraversal.AddV).GetMethodInfo(),
                Expression.Constant(source),
                Expression.Constant(label)));
        }

        public static IGraphTraversal<Edge> AddV<TSource>(this IGraphTraversal<TSource> source, string label)
        {
            return source.Provider.CreateTraversal<Edge>(Expression.Call(
                null,
                new Func<IGraphTraversal<TSource>, string, IGraphTraversal<Edge>>(GraphTraversal.AddV).GetMethodInfo(),
                source.Expression,
                Expression.Constant(label)));
        }

        public static IGraphTraversal<TSource> Property<TSource, TValue>(this IGraphTraversal<TSource> source, string propertyName, TValue propertyValue)
        {
            return source.Provider.CreateTraversal<TSource>(Expression.Call(
                null,
                new Func<IGraphTraversal<TSource>, string, object, IGraphTraversal<TSource>>(GraphTraversal.Property).GetMethodInfo().GetGenericMethodDefinition().MakeGenericMethod(typeof(TSource), typeof(TValue)),
                source.Expression,
                Expression.Constant(propertyName),
                Expression.Constant(propertyValue)));
        }

        public static IGraphTraversal<Vertex> Has<TValue>(this IGraphTraversal<Vertex> source, string propertyName, TValue propertyValue)
        {
            return source.Provider.CreateTraversal<Vertex>(Expression.Call(
                null,
                new Func<IGraphTraversal<Vertex>, string, TValue, IGraphTraversal<Vertex>>(GraphTraversal.Has).GetMethodInfo().GetGenericMethodDefinition().MakeGenericMethod(typeof(TValue)),
                source.Expression,
                Expression.Constant(propertyName),
                Expression.Constant(propertyValue)));
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

        public async static Task<IList<TSource>> ToListAsync<TSource>(this IGraphTraversal<TSource> source)
        {
            return (IList<TSource>)(await source.Provider.ExecuteAsync(source.Expression));
        }
    }
}
