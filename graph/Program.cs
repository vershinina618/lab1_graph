using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace graph
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\user\source\repos\graph\graph\input_file.txt";
            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default))  //построчное чтение из файла
            {
                string line = sr.ReadLine(); //считывает одну строку в файле
                int size = Convert.ToInt32(line);
                int x1, x2, weight;
                int[,] adjacency_matrix = new int[size,size];
                int[,] weight_matrix = new int[size, size]; 
                for (int i = 0; i < size; i ++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        adjacency_matrix[i, j] = 0;
                        weight_matrix[i, j] = Int32.MaxValue;
                    }
                }
                Console.WriteLine($"Количество вершин {size}");
                while ((line = sr.ReadLine())!= null) //до конца файла
                {
                    string[] arr_str = line.Split(new char[] {' '}); //разделить строки на массив по пробелам
                    x1 = Convert.ToInt32(arr_str[0]);
                    x2 = Convert.ToInt32(arr_str[1]);
                    weight = Convert.ToInt32(arr_str[2]);
                    Console.WriteLine($"{x1} {x2} {weight}");
                    adjacency_matrix[x1 - 1, x2 - 1] = 1;
                    weight_matrix[x1 - 1, x2 - 1] = weight;
                }
                Console.WriteLine("Матрица смежности:" );
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(String.Format("{0,2}", adjacency_matrix[i, j]));
                    }                     
                    Console.WriteLine();
                }
                Console.WriteLine("Матрица весов:");
                for (int i = 0; i < size; i++)
                {
                    for (int j = 0; j < size; j++)
                    {
                        Console.Write(String.Format("{0,11}", weight_matrix[i, j]));
                    }
                    Console.WriteLine();
                }
            }           
            Console.ReadKey();
        }
    }
}
