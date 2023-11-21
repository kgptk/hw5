using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarDeligate
{
    public interface ICalc
    {
        void Sum(int x);
        void Sub(int x);
        void Mul(int x);
        void Divide(int x);
        void CanselLast();

        event EventHandler<EventArgs> MyEventHandler;
    }
}
