using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGremlin.Core
{
    public class GraphTraversal<TResult>
    {
        public GraphTraversal<TNewResult> Add<TNewResult>(ITraversalStep<TResult, TNewResult> step)
        {
            return null;
        }
    }
}
