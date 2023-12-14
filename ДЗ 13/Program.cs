using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ДЗ_13
{
    internal class Program
    {
        static decimal CountSquare(decimal b)
        {
            return b * b;

        }
        static async Task<object> CountFactorial(decimal x)
        {
            await Task.Delay(8000); // Задержка потока на 8 секунд
            string str1;
            string str2;
            int a =1;
            if (x > 0)
            {
                for (int i = 1 ; i <= x; i++)
                {
                    a *= i;
                }
                return $"Факториал числа {x} = {a}";

            }
            else if ( x == 0 )
            {
                return "Факториал этого числа = 1";
            }
            else
            { 
                return "Нужно было ввести целое число >=0";
            }

        }
        static void Numbers(object threadName)
        {
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{threadName}: {i}");
            }
        }

        static async Task Main(string[] args)
        {
            Console.WriteLine("Задание 1");
            Thread thread1 = new Thread(Numbers);
            Thread thread2 = new Thread(Numbers);
            Thread thread3 = new Thread(Numbers);

            thread1.Start("Первый поток");
            thread2.Start("Второй поток");
            thread3.Start("Третий поток");
            Thread.Sleep(1000);

            Console.WriteLine("Задание 2");
            Console.WriteLine("Введите целое число >= 0, факториал которого хотите найти");
            string num = Console.ReadLine();
            bool result = decimal.TryParse(num, out decimal number);
            if (result == true)
            {

            }
            else
            {
                Console.WriteLine("Введите число");
            }

            Task<object> factorialTask = CountFactorial(number);

            // Вычисление возведения в квадрат синхронно
            decimal squareResult = CountSquare(number);

            // Ожидание завершения вычисления факториала
            object factorialResult = await factorialTask;

            Console.WriteLine($"Квадрат числа {number}: {squareResult}");
            Console.WriteLine($"Результат вычисления факториала: {factorialResult}");

            Console.WriteLine("Задание 3");
            Refl obj = new Refl();
            MethodInfo[] methods = obj.GetType().GetMethods();
            Refl.Equals(methods, true);
            Console.ReadKey();
        }
    }
}
