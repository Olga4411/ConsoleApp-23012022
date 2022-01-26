using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppДелегатыЛекция23012022
{
    class Program
    {
        //описание первого делегата
        //описали делегат, который может работать с методами
        //double(double,double)
        public delegate double CalculatorDel(double a, double b);

        // метод обертка, который принимает в качестве параметра
        //делегат операции и вызывает его
          static void MakeOperation(CalculatorDel operation)
        {
            Console.WriteLine("Введите a:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите b:");
            double b = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine($"Результат операции:{operation(a, b)}");
        }

        // второй метод обертка
        //отличается тем, что получает результаты вызовов всех функицй,
        //хранящихся в делегате
        static void  MakeComplexOperation(CalculatorDel operations)
        {
            Console.WriteLine("Введите a:");
            double a = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите b:");
            double b = Convert.ToDouble(Console.ReadLine());

            // вызов всех методов
            //operations.GetInvocationList();// вернет массив методов
            foreach(CalculatorDel operation in operations.GetInvocationList())
            {
                Console.WriteLine($"Результат операции:{operation(a, b)}");
            }
        }
        static void Main(string[] args)
        {
            //1. Объявление делегата
            //обьявить тип делегата-в классе, структуре, в namespace
            // в методах нельзя
            //ТИП ДЕЛЕГАТА-тип, который будет описывать для каких методов

            //он будет работать

            //2 Создание экземпляра делегата
            // создали экземпляр делегата и сохранили туда результат суммы
            CalculatorDel operation = new CalculatorDel(Sum);
            operation += Sub;// добавили к методу суммы разность
            operation += Mul;
            MakeOperation(operation);
            Console.ReadLine();
            //MakeOperation(operation);
            //operation = Sub;// изменим на разность
            // MakeOperation(operation);
            // Console.WriteLine(operation(5, 15));

            // второй делегат
            //CalculatorDel op2 = Sub;
            //Console.WriteLine(op2(19, 20));
        }

        // методы операций, которые будут сохраняться в делегате
        static double Sum(double a, double b)
        {
            Console.WriteLine("Sum!");
            return  a + b;
        }

        static double Sub(double a, double b)
        {
            Console.WriteLine("Sub!");
            return a - b;
        }

        static double Mul(double a, double b)
        {
            Console.WriteLine("Mul!");
            return a *b;
        }
    }
}
