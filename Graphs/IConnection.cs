using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public interface IConnection<TNode, TConcrete>
        where TNode : notnull
        where TConcrete : notnull, IConnection<TNode, TConcrete>
    {
        public TNode From { get; }
        public TNode To { get; }

        public TConcrete GetOpposite();
    }
}
