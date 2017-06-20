using FluentGremlin.Core;
using FluentGremlin.GremlinServer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FluentGremlin.GermlinServer.Tests
{
    [TestFixture]
    public class QueryBuilderVisitorTests
    {
        [Test]
        public void Visit_WithAllVertices_ReturnsQuery()
        {
            var queryBuilder = new QueryBuilderVisitor();
            var g = new GremlinServerSource();

            var gremlin = queryBuilder.BuildQuery(g.V().Expression);

            Assert.That(gremlin, Is.EqualTo("g.V()"));
        }

        [Test]
        public void Visit_WithIntegerId_ReturnsQuery()
        {
            var g = new GremlinServerSource();
            var query = g.V(1);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V(1)"));
        }

        [Test]
        public void Visit_WithStringId_ReturnsQuery()
        {
            var g = new GremlinServerSource();
            var query = g.V("asdf");

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V('asdf')"));
        }

        [Test]
        public void Visit_WithHas_ReturnsQuery()
        {
            var g = new GremlinServerSource();
            var query = g.V().Has("prop", 1);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().has('prop', 1)"));
        }

        [Test]
        public void Visit_WithMultipleHas_ReturnsQuery()
        {
            var g = new GremlinServerSource();
            var query = g.V().Has("prop1", 1).Has("prop2", "2").Has("prop3", true);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().has('prop1', 1).has('prop2', '2').has('prop3', true)"));
        }
    }
}