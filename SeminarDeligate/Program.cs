using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
                double number;
                if (DoubleTryParse(strDigit, out number))
                {
                    try
                    {
                        NegativeNumber(number);
                    }
                    catch (NegativeExeption ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                    catch { };

                    Console.WriteLine("Введите операцию, которую необходимо выполнить \n" +
                        "+, -, *, /\n" +
                        "< чтобы отменить последнее действие \n" +
                        "! чтобы закончить: ");
                    string operation = Console.ReadLine();

                    char[] chars = operation.ToCharArray();

                    if (chars.Length == 1)
                    {
                        switch (chars[0])
                        {
                            case '+': calc.Sum(number);
                                break;
                           
                            case '-':
                                try
                                {
                                    ResultNegativeNumber(calc.Sub(number));
                                }
                                catch (NegativeExeption ex)
                                {
                                    Console.WriteLine(ex.ToString());
                                }
                                catch { };

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
        }

        private static void Calc_MyEventHandler(object sender, EventArgs e)
        {
            if (sender is Calc) 
            {
                var calc = sender as Calc;
            }
            Console.WriteLine(((Calc)sender).Result);
        }

        static bool DoubleTryParse(string str, out double value)
        {
            value = 0;
            try
            {
                value = Convert.ToDouble(str);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex);
                return false;
            }
            return true;
        }

        static void NegativeNumber(double number)
        {
            
            if (number < 0)
            { 
                throw new NegativeExeption("Число отрицательное", new Exception("Введено недопустимое число"));
            }
        }

        static void ResultNegativeNumber (double number)
        {
            if (number < 0)
            {
                throw new NegativeExeption("Результат операции оторицателен!", new Exception("Выполнено недопустимое действие!"));
            }

        }

        
    }

    
}
