using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab8Task5
{
    class Program
    {
        private static void GoodMorning()
        {
            Console.WriteLine("Good morning!");
        }
        private static void GoodDay()
        {
            Console.WriteLine("Good day!");
        }
        private static void GoodEvening()
        {
            Console.WriteLine("Good evening!");
        }
        private static void GoodNight()
        {
            Console.WriteLine("Good night!");
        }
        private static void DoDivision(double x, double y)
        {
            if (y != 0)
                Console.WriteLine("" + (x / y));
            else
                Console.WriteLine("Can not divide by 0");
        }
        private static void DoMultiplication(double x, double y)
        {
            Console.WriteLine("" + (x * y));
        }
        private static void DoSubtraction(double x, double y)
        {
            Console.WriteLine("" + (x - y));
        }
        private static void DoAddition(double x, double y)
        {
            Console.WriteLine("" + (x + y));
        }

        delegate void GetGreeting();
        delegate void UseOperation(double x, double y);

        static void Main(string[] args)
        {
            GetGreeting del;

            if (DateTime.Now.Hour < 12)
            {
                del = GoodMorning;
                del.Invoke();
            }
            else if (DateTime.Now.Hour >= 12 && DateTime.Now.Hour < 16)
            {
                del = GoodDay;
                del.Invoke();
            }
            else if (DateTime.Now.Hour >= 16 && DateTime.Now.Hour < 22)
            {
                del = GoodEvening;
                del.Invoke();
            }
            else if (DateTime.Now.Hour >= 22 && DateTime.Now.Hour < 4)
            {
                del = GoodNight;
                del.Invoke();
            }

            Console.WriteLine("Input x and y");
            double x = double.Parse(Console.ReadLine());
            double y = double.Parse(Console.ReadLine());
            Console.WriteLine("Input operation (+, -, *, /)");
            string symbol = Console.ReadLine();

            UseOperation op;

            switch (symbol)
            {
                case "+":
                    op = DoAddition;
                    op.Invoke(x, y);
                    break;
                case "-":
                    op = DoSubtraction;
                    op.Invoke(x, y);
                    break;
                case "*":
                    op = DoMultiplication;
                    op.Invoke(x, y);
                    break;
                case "/":
                    op = DoDivision;
                    op.Invoke(x, y);
                    break;
                default:
                    throw new ArgumentException(string.Format("Operation {0} is invalid", symbol), "symbol");
            }

            Console.ReadKey();
        }
    }
}