using System;
using System.Threading;
using System.Reflection;
using System.Threading.Tasks;

namespace DZ12
{
    internal class Program
    {
        static void PrintNumber()
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.Write(i + " ");
            }
        }
        static int Factorial(int number)
        {
            if (number == 1)
            {
                return 1;
            }

            return number * Factorial(number - 1);
        }
        static async Task<int> FactorialAsync(int number)
        {
            int factorial = await Task.Run(() => Factorial(number));
            Thread.Sleep(8000);

            return factorial;
        }
        static int Square(int number)
        {
            return (number * number);
        }


        static async Task Main()
        {
            Console.WriteLine("Зад. 1: Необходимо создать программу, где будет реализовано 3 потока.");

            Thread firstThread = new Thread(PrintNumber);
            Thread secondThread = new Thread(PrintNumber);
            Thread thirdThread = new Thread(PrintNumber);

            firstThread.Start();
            secondThread.Start();
            thirdThread.Start();


            Console.WriteLine("Зад. 2: Вычисление факториала должно проходить асинхронно, вычисление возведения в квадрат синхронно.");

            int number = 5;

            int square = Square(number);
            Console.WriteLine($"{number}^2 = {square}");

            int factorial = await FactorialAsync(number);
            Console.WriteLine($"{number}! = {factorial}");


            Console.WriteLine("Зад. 3: Вы получаете объект и должны вернуть имена всех(!) методов, которые вы нашли для этого объекта.");

            REFL reflection = new REFL();

            Type Type = reflection.GetType();
            MethodInfo[] methods = Type.GetMethods();

            Console.WriteLine("Методы:");

            foreach (MethodInfo method in methods)
            {
                Console.WriteLine(method.Name);
            }
        }
    }
}
