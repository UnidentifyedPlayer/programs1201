using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        enum SimpleColor
        {
            White,
            Gray,
            Blue,
            Orange
        }
        static void ReadData(string message, ref double x)
        {
            double u;
            bool result;
            do
            {
                Console.WriteLine(message);
                result = double.TryParse(Console.ReadLine(), out u);
                if (result != true)
                    Console.WriteLine("введеное значение не является целым числом");
                if ((x < -10 || x > 10))
                {
                    Console.WriteLine("Введенное значение переменной не принадлежит отрезку [-10;10]");
                    result = false;
                }
                x = u;
            }
            while (!result);
        }
        static bool IsPointInCircle(double x, double y,
        double x0, double y0, double r)
        {
            return ((x - x0) * (x - x0) + (y - y0) * (y - y0)) < r * r;
        }
        static bool IsPointLeftOfHParabola(double x, double y, double x0, double y0, double a)
        {
            return x < a * (y - y0) * (y - y0) + x0;
        }
        static bool IsPointLeftOfHParabola1(double x, double y)
        {
            return IsPointLeftOfHParabola(x, y, 4, -3, 0.5);
        }
        static bool IsPointInCircle1(double x, double y)
        {
            return IsPointInCircle(x, y, 1, -3, 4);
        }
        static bool IsPointInCircle2(double x, double y)
        {
            return IsPointInCircle(x, y, -2, -5, 2);
        }
        static SimpleColor GetColor(double x, double y)
        {
            if (IsPointLeftOfHParabola1(x, y) && !IsPointInCircle1(x, y) && !IsPointInCircle2(x, y))
                return SimpleColor.White;
            if (IsPointLeftOfHParabola1(x, y) && IsPointInCircle1(x, y) && !IsPointInCircle2(x, y))
                return SimpleColor.Gray;
            if (IsPointLeftOfHParabola1(x, y) && !IsPointInCircle1(x, y) && IsPointInCircle2(x, y))
                return SimpleColor.Orange;
            if (IsPointLeftOfHParabola1(x, y) && IsPointInCircle1(x, y) && IsPointInCircle2(x, y))
                return SimpleColor.White;
            if (!IsPointLeftOfHParabola1(x, y) && IsPointInCircle1(x, y))
                return SimpleColor.Blue;
            else
                return SimpleColor.Gray;
        }
        static void Main(string[] args)
        {
            
            double x = 0;
            double y = 0;
            int count = 0;
            do
            {
                    ReadData("x = ", ref x);
                    ReadData("y = ", ref y);
                    Console.WriteLine(GetColor(x, y));
                Console.WriteLine("Для ввода новых данных нажмите 0, для выхода -любую клавишу");
                count = int.Parse(Console.ReadLine());
            }
            while (count == 0);
        }
    }
}
