using FluentGremlin.Core;
using FluentGremlin.DocumentDB;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGremlin.DocumentDB.Tests
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void GenerateSteps()
        {
            var v = new Visitor();
            var g = new GraphTraversalSource(new DocumentDBGraphTraversalProvider());

            var query = g.V();

            var steps = v.BuildSteps(query.Expression);
        }
    }
}
