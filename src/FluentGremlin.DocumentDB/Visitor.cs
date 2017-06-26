using FluentGremlin.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentGremlin.DocumentDB
{
    public class Visitor : ExpressionVisitor
    {
        private Stack<string> _steps = new Stack<string>();

        protected override Expression VisitMethodCall(MethodCallExpression node)
        {
            if (node.Method.Name == "V")
            {
                _steps.Push("V()");
            }
            return base.VisitMethodCall(node);
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            if (node.Value is IGraphTraversalSource)
            {
                _steps.Push("g");
            }
            return base.VisitConstant(node);
        }

        public List<string> BuildSteps(Expression expression)
        {
            this.Visit(expression);
            return _steps.ToList();
        }
    }
}
