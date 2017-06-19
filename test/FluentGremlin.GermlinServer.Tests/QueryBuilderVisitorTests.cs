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

        //[Test]
        //public void ToGremlinQuery_WithSingleVertex_ReturnsQuery()
        //{
        //    var g = new GremlinServerSource();
        //    var query = g.V(1);

        //    var gremlin = query.GetQuery();

        //    Assert.That(gremlin, Is.EqualTo("g.V(1)"));
        //}
    }
}
