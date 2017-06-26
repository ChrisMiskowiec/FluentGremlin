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
        public void Has_PropertyKey()
        {
            var g = new GremlinServerSource();
            var query = g.V().Has("prop");

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().has('prop')"));
        }

        [Test]
        public void Has_PropertyValue_WithInteger()
        {
            var g = new GremlinServerSource();
            var query = g.V().Has("prop", 1);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().has('prop', 1)"));
        }

        [Test]
        public void Has_PropertyValue_WithBoolean()
        {
            var g = new GremlinServerSource();
            var query = g.V().Has("isActive", true);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().has('isActive', true)"));
        }

        [Test]
        public void Has_PropertyValue_WithGuid()
        {
            var g = new GremlinServerSource();
            var guid = Guid.Parse("92bcee7b-c3b5-405a-9bd8-27dd4a635843");
            var query = g.V().Has("id", guid);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().has('id', '92bcee7b-c3b5-405a-9bd8-27dd4a635843')"));
        }

        [Test]
        public void Has_PropertyValue_WithOne()
        {
            var g = new GremlinServerSource();
            var guid = Guid.Parse("92bcee7b-c3b5-405a-9bd8-27dd4a635843");
            var query = g.V().HasId(guid);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().hasId('92bcee7b-c3b5-405a-9bd8-27dd4a635843')"));
        }

        [Test]
        public void Has_PropertyValue_WithMany()
        {
            var g = new GremlinServerSource();
            var query = g.V().HasId(1, 2, 3);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().hasId(1, 2, 3)"));
        }
    }
}
