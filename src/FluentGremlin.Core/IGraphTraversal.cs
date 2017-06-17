using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentGremlin.Core
{
    public interface IGraphTraversal<T>
    {
        IGraphTraversalProvider Provider { get; }
        Type ElementType { get; }
        Expression Expression { get; }
    }
}
