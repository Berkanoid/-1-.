using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DZ_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите путь к файлу: ");
            string[] lines = System.IO.File.ReadAllLines(Console.ReadLine());
            int n = int.Parse(lines[0]);
            double[,] G = new double[n, n];
            double[] x = new double[n];
            for (int i = 0; i < n; i++)
            {
                double[] row = lines[i + 1].Split(' ').Select(double.Parse).ToArray();
                for (int j = 0; j < n; j++)
                    G[i, j] = row[j];
            }
            double[] vector = lines[n + 1].Split(' ').Select(double.Parse).ToArray();
            for (int i = 0; i < n; i++)
                x[i] = vector[i];
            for (int i = 0; i < n; i++)
                for (int j = i + 1; j < n; j++)
                    if (G[i, j] != G[j, i])
                    {
                        Console.WriteLine("Матрица не симметрична!");
                        return;
                    }
            double sum = 0;
            for (int i = 0; i < n; i++)
                for (int j = 0; j < n; j++)
                    sum += x[i] * G[i, j] * x[j];
            Console.WriteLine($"Длина вектора: {Math.Sqrt(sum)}");
        }
    }
}

