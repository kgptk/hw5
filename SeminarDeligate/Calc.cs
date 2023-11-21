using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarDeligate
{
    internal class Calc: ICalc
    {
        public double Result { get; set; } = 1;
        private Stack<double> LastResult { get; set; } = new Stack<double>();

        public event EventHandler<EventArgs> MyEventHandler;



        //public Calc()
        //{
        //    LastResult = Result;
        //}
        private void PrintResult()
        {
            MyEventHandler?.Invoke(this, new  EventArgs());   
        }

        public void Sum(int x)
        {
            Result += x;
            PrintResult();
            LastResult.Push(Result);


           
        }
        public void Sub(int x)
        {
            Result -= x;
            PrintResult();
            LastResult.Push(Result);


        }

        public void Divide(int x)
        {
            Result /= x;
            PrintResult();
            LastResult.Push(Result);



        }

        public void Mul(int x)
        {
            Result *= x;
            PrintResult();
            LastResult.Push(Result);

        }

        //Метод CanselLast() отменяет последние действия вплоть до последнего


        public void CanselLast()
        {
           
            if (LastResult.Pop() is double)
            {
                double res = LastResult.Pop();
                Result = res;
                Console.WriteLine("Последнее действие отменено");
                PrintResult();
            }
            else
            {
                Console.WriteLine("Невозможно отменить посднее действие");
            }
        }
    }

}
