using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentGremlin.Core
{
    public enum StepType
    {
        Map,
        FlatMap,
        Filter,
        SideEffect,
        Branch
    }
}
