using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    internal interface IConnection<TNode, TConcrete>
        where TNode : notnull
        where TConcrete : IConnection<TNode, TConcrete>
    {
        TNode From { get; }
        TNode To { get; }

        public TConcrete GetOpposite();
    }
}
