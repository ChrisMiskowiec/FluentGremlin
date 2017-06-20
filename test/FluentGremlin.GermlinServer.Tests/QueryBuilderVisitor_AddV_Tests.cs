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
    public class QueryBuilderVisitor_AddV_Tests
    {
        [Test]
        public void AddV_FromSource()
        {
            var g = new GremlinServerSource();
            var query = g.AddV("test");

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.addV('test')"));
        }

        [Test]
        public void AddV_FromTraversal()
        {
            var g = new GremlinServerSource();
            var query = g.V().AddV("test");

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().addV('test')"));
        }
    }
}
