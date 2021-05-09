using System;
using System.Collections.Generic;
using System.Text;

namespace Alliant.Shopping
{
    public interface ITerminal
    {
        void Scan(string item);
        decimal Total();
    }
}
