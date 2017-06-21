using FluentGremlin.Core;
using FluentGremlin.GremlinServer;
using NUnit.Framework;

namespace FluentGremlin.GermlinServer.Tests
{
    [TestFixture]
    public class QueryBuilderVisitor_As_Tests
    {
        [Test]
        public void As_WithString()
        {
            var g = new GremlinServerSource();
            var query = g.V().As("a");

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().as('a')"));
        }
    }
}
