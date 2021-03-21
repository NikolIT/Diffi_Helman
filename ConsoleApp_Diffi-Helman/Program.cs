using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp_Diffi_Helman
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введiть p ->");
            int p = int.Parse(Console.ReadLine());
            int g;
            int a;
            int b;
            int A;
            int B;
            int KA;
            int KB;
            List<int> originalRoot = OriginalRoot(p);

            if (originalRoot.Count == 0)
            {
                Console.WriteLine("Нажаль для цього числа немає первiсних корнiв");
                Console.ReadLine();
                return;
            }

            Console.WriteLine($"можливi наспурнi числа якi є первiсним коренем числа {p} - ");
            ShowArray(originalRoot);
            Console.WriteLine("Видерiть число а з представлених.");
            Console.Write("g ->");
            g = int.Parse(Console.ReadLine());
            while (!originalRoot.Contains(g))
            {
                Console.WriteLine("ви ввели чилсо що не налажить масиву, спробуйте ще раз.");
                Console.Write("g ->");
                g = int.Parse(Console.ReadLine());
            }

            Console.WriteLine($"Вiдкритi числа g - {g} та p - {p} ");
            Console.Write("Приховане число Алiси а - ");
            a = int.Parse(Console.ReadLine());

            Console.Write("Приховане число Боба b - ");
            b = int.Parse(Console.ReadLine());

            A = (int)Math.Pow(g, a) % p;
            Console.WriteLine($"А велике Алiси = {A}");

            B = (int)Math.Pow(g, b) % p;
            Console.WriteLine($"B велике Боба = {B}");

            Console.WriteLine("Тереп Алiса та Боб вiдкрито обмiнюються великими А та В.");

            KA = (int)Math.Pow(B, a) % p;
            Console.WriteLine($"K Алiси = {KA}");

            KB = (int)Math.Pow(A, b) % p;
            Console.WriteLine($"K Боба = {KB}");

            Console.ReadLine();
        }

        static void ShowArray<T> (IEnumerable<T> array)
        {
            foreach (var item in array)
            {
                Console.Write($" {item}");
            }
            Console.WriteLine();
        }

        static List<int> OriginalRoot(int p)
        {
            List<int> a = new List<int>();
            List<int> ak = new List<int>();
            List<int> check = new List<int>();

            for (int i = 1; i < p; i++)
            {
                check.Add(i);
            }

            for (int i = 1; i < p; i++)
            {
                for (int j = 1; j < p; j++)
                {
                    ak.Add((int)Math.Pow(i, j) % p);
                }
                ak.Sort();
                if (ak.SequenceEqual(check))
                    a.Add(i);
                ak.Clear();
            }

            return a;
        }
    }
}
