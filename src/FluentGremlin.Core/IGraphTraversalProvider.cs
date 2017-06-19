using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FluentGremlin.Core
{
    public interface IGraphTraversalProvider
    {
        IGraphTraversal<TResult> CreateTraversal<TResult>(Expression expression);
        Task<object> ExecuteAsync(Expression expression);
    }
}
