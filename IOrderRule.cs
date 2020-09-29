using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cart.Engine.Interfaces
{
    public interface IOrderRule
    {
        IList<Product> Products { get; }
    }
}
