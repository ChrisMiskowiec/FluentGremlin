namespace FluentGremlin.Core
{
    public class GraphTraversalSource : IGraphTraversalSource
    {
        private readonly IGraphTraversalProvider _provider;
        public IGraphTraversalProvider Provider => _provider;

        public GraphTraversalSource(IGraphTraversalProvider provider)
        {
            _provider = provider;
        }
    }
}
