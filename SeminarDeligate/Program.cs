using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeminarDeligate
{
    internal class Program
    {
        delegate void myDelegate(string message);
        static void Main(string[] args)
        {
            var calc = new Calc();
            calc.MyEventHandler += Calc_MyEventHandler;

            bool flag = true;
            while (flag)
            {            
                Console.WriteLine("Введите число: ");
                string strDigit = Console.ReadLine();
                int number;
                if (int.TryParse(strDigit, out number))
                {
                    Console.WriteLine("Введите операцию, которую необходимо выполнить \n (+, -, *, /) \n < чтобы отменить последнее действие \n! чтобы закончить: ");
                    string operation = Console.ReadLine();

                    char[] chars = operation.ToCharArray();
                    if (chars.Length == 1)
                    {
                        switch (chars[0])
                        {
                            case '+': calc.Sum(number);
                                break;
                           
                            case '-':
                                calc.Sub(number);
                                break;
                            case '*':
                                calc.Mul(number);
                                break;

                            case '/':
                                calc.Divide(number);
                                break;
                            case '<':
                                calc.CanselLast();
                                break;

                            case '!':
                                flag = false;
                                break;

                            default:
                                Console.WriteLine("Неверный ввод");
                                break;
                        }
                    }
                }
            }
           
            //calc.Sub(10);
            //calc.Sum(1);
            //calc.Mul(5);
            //calc.CanselLast();
            //calc.CanselLast();
            //
            //calc.CanselLast();
            Console.ReadKey();

        }

        private static void Calc_MyEventHandler(object sender, EventArgs e)
        {
            if (sender is Calc) 
            {
                var calc = sender as Calc;
            }
            Console.WriteLine(((Calc)sender).Result);
        }
    }

    
}
