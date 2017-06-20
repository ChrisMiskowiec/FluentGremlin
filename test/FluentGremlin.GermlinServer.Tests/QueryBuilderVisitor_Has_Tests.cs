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
    public class QueryBuilderVisitor_Has_Tests
    {
        [Test]
        public void Has_WithInteger()
        {
            var g = new GremlinServerSource();
            var query = g.V().Has("prop", 1);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().has('prop', 1)"));
        }

        [Test]
        public void Has_WithBoolean()
        {
            var g = new GremlinServerSource();
            var query = g.V().Has("isActive", true);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().has('isActive', true)"));
        }

        [Test]
        public void Has_WithGuid()
        {
            var g = new GremlinServerSource();
            var guid = Guid.Parse("92bcee7b-c3b5-405a-9bd8-27dd4a635843");
            var query = g.V().Has("id", guid);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().has('id', '92bcee7b-c3b5-405a-9bd8-27dd4a635843')"));
        }
    }
}
