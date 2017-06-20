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
                ["V"] = "V"
            };

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Arguments.Count < 1)
            {
                throw new InvalidOperationException("Should have at least one argument (object of extension method).");
            }

            var obj = (string)((LambdaExpression)Visit(node.Arguments.First())).Compile().DynamicInvoke();

            if (!_methodNameMap.TryGetValue(node.Method.Name, out var mappedName))
            {
                mappedName = node.Method.Name.Substring(0, 1).ToLower() + node.Method.Name.Substring(1);
            }

            var args = GetArguments(node)
                .Select(a => (string)((LambdaExpression)Visit(a)).Compile().DynamicInvoke())
                .ToArray();
            Expression<Func<string>> f = () => $"{obj}.{mappedName}({string.Join(", ", args)})";
            return f;
        }

        private IEnumerable<Expression> GetArguments(MethodCallExpression node)
        {
            var args = node.Arguments.Skip(1);
            if (!args.Any())
            {
                return new Expression[] { };
            }

            if (args.Last() is ConstantExpression c && c.Value is Expression[] e)
            {
                return args.TakeWhile(arg => arg != c).Concat(e);
            }
            else
            {
                return args;
            }
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            var numericTypes = new HashSet<Type>() { typeof(short), typeof(int), typeof(long), typeof(float), typeof(double), typeof(decimal) };

            if (numericTypes.Contains(node.Type))
            {
                return RawLiteral(node.Value);
            }
            else if (node.Value is GremlinServerSource)
            {
                return RawLiteral("g");
            }
            else if (node.Value is bool b)
            {
                return RawLiteral(b.ToString().ToLower());
            }
            else
            {
                return QuotedLiteral(node.Value);
            }
        }

        private Expression RawLiteral(object o)
        {
            return (Expression<Func<string>>)(() => o.ToString());
        }

        private Expression QuotedLiteral(object o)
        {
            return (Expression<Func<string>>)(() => $"'{o}'");
        }

        public string BuildQuery(Expression expression)
        {
            var visitedExpression = Visit(expression);
            var query = ((Func<string>)Expression.Lambda(visitedExpression).Compile().DynamicInvoke())();
            return query;
        }
    }
}
