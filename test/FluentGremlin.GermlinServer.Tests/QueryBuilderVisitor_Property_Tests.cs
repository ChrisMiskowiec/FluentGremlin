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
    public class QueryBuilderVisitor_Property_Tests
    {
        [Test]
        public void Property_WithInteger()
        {
            var g = new GremlinServerSource();
            var query = g.V().Property("prop", 1);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().property('prop', 1)"));
        }

        [Test]
        public void Property_WithBoolean()
        {
            var g = new GremlinServerSource();
            var query = g.V().Property("isActive", true);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().property('isActive', true)"));
        }

        [Test]
        public void Property_WithGuid()
        {
            var g = new GremlinServerSource();
            var guid = Guid.Parse("92bcee7b-c3b5-405a-9bd8-27dd4a635843");
            var query = g.V().Property("id", guid);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().property('id', '92bcee7b-c3b5-405a-9bd8-27dd4a635843')"));
        }
    }
}
