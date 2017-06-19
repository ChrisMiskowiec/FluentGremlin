using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentGremlin.GremlinServer
{
    public class QueryBuilderVisitor : ExpressionVisitor
    {
        private static readonly IReadOnlyDictionary<string, string> _methodNameMap =
            new Dictionary<string, string>()
            {
                ["E"] = "E",
                ["V"] = "V",
                ["AddV"] = "addV"
            };

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Arguments.Count < 1)
            {
                throw new InvalidOperationException("Should have at least one argument (object of extension method).");
            }

            var obj = (string)((LambdaExpression)Visit(node.Arguments.First())).Compile().DynamicInvoke();

            var method = _methodNameMap[node.Method.Name];

            var args = node.Arguments.Skip(1)
                .Select(a => (string)((LambdaExpression)Visit(a)).Compile().DynamicInvoke())
                .ToArray();
            Expression<Func<string>> f = () => $"{obj}.{method}({string.Join(", ", args)})";
            return f;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            switch (node.Value)
            {
                case GremlinServerSource _:
                    return (Expression<Func<string>>)(() => "g");
                case string s:
                    return (Expression<Func<string>>)(() => $"\"{s}\"");
                default:
                    var value = node.Value.ToString();
                    return (Expression<Func<string>>)(() => value);
            }
        }

        public string BuildQuery(Expression expression)
        {
            var exp = Visit(expression);
            return (string)Expression.Lambda(exp).Compile().DynamicInvoke();
            //return (string)((LambdaExpression)expression).Compile().DynamicInvoke();
        }
    }
}
