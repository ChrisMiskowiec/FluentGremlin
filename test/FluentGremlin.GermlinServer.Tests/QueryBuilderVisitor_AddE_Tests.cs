using FluentGremlin.Core;
using FluentGremlin.GremlinServer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGremlin.GermlinServer.Tests
{
    [TestFixture]
    public class QueryBuilderVisitor_AddE_Tests
    {
        [Test]
        public void AddE_FromSource()
        {
            var g = new GremlinServerSource();
            var query = g.AddE("test");

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.addE('test')"));
        }

        [Test]
        public void AddE_FromTraversal()
        {
            var g = new GremlinServerSource();
            var query = g.V().AddE("test");

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().addE('test')"));
        }
    }
}
