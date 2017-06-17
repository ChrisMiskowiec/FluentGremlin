using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentGremlin.Core
{
    public interface IGraphTraversalProvider
    {
        IGraphTraversal<TResult> CreateTraversal<TResult>(Expression expression);
        object Execute(Expression expression);
    }
}
