using System;

namespace FluentGremlin.Core
{
    public class GremlinSyntaxException : Exception
    {
        public GremlinSyntaxException(string message) : base(message) { }
    }
}
