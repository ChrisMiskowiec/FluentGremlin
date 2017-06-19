using FluentGremlin.Core;

namespace FluentGremlin.GremlinServer
{
    public class GremlinServerSource : IGraphTraversalSource
    {
        private readonly IGraphTraversalProvider _provider = new GremlinGraphTraversalProvider();
        public IGraphTraversalProvider Provider => _provider;
    }
}
