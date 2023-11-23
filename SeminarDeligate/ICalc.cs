using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarDeligate
{
    public interface ICalc
    {
        void Sum(double x);
        double Sub(double x);
        void Mul(double x);
        void Divide(double x);
        void CanselLast();

        event EventHandler<EventArgs> MyEventHandler;
    }
}
