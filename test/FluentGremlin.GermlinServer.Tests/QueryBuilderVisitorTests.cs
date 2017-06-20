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
        public void GetQuery_WithMultipleCalls_Chains()
        {
            var g = new GremlinServerSource();
            var query = g.V().Has("prop1", 1).Has("prop2", "2").Has("prop3", true);

            var gremlin = query.GetQuery();

            Assert.That(gremlin, Is.EqualTo("g.V().has('prop1', 1).has('prop2', '2').has('prop3', true)"));
        }
    }
}