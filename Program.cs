//19. В данной матрице размером n * n для каждого столбца найти позиции локальных минимумов
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace lab4_19
{
    internal class Program
    {
        static void fill_matrix(int size, int[,] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                    arr[i, j] = rnd.Next(0, 10);
        }

        static void print_matrix(int size, int[,] arr)
        {
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                    Console.Write(arr[i, j] + " ");
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        static void task_print(int size, int[] arr, int size_arr)
        {
            if (arr[0] == 0 && arr[1] == 0)
                Console.WriteLine("Нет локальных минимумов");
            else
            {
                for (int i = 0; i < size_arr; i++)
                    Console.Write(arr[i] + " ");
                Console.WriteLine();
            }
        }

        static int[,] create_matrix(out int n)
        {
            Console.Write("Введите размер n матрицы nxn: ");
            int.TryParse(Console.ReadLine(), out n);

            int[,] matr = new int[n, n];
            fill_matrix(n, matr);
            return matr;
        }

        static int[] task(int coll, int size, ref int[,] matr, out int size_arr)
        {
            int[] res = new int[size];
            int curr = 0;

            if (matr[coll, 0] < matr[coll, 1])
                res[curr++] = 1;

            for (int i = 1; i < size - 1; ++i)
            {
                if (matr[coll, i] < matr[coll, i + 1] && matr[coll, i] < matr[coll, i - 1])
                    res[curr++] = 1 + i++;
            }

            if (matr[coll, size-1] < matr[coll, size-2])
                res[curr++] = size;

            size_arr = curr;
            return res;
        }

        static void transpose_matrix(ref int[,] matr, int size)
        {
            for (int i = 0; i < size; i++)
                for (int j = i + 1; j < size; j++)
                {
                    int temp = matr[i, j];
                    matr[i, j] = matr[j, i];
                    matr[j, i] = temp;
                }
        }

        static void Main(string[] args)
        {
            int size, size_arr;
            int[,] matr = create_matrix(out size);

            Console.WriteLine("\nПроизвольно заданная матрица: ");
            print_matrix(size, matr);

            transpose_matrix(ref matr, size);

            Console.WriteLine("\nПозиции локальных минимумов для каждого столбца: ");
            for (int i = 0; i < size; ++i)
            {
                Console.Write($"{i + 1}) ");
                task_print(size, task(i, size, ref matr, out size_arr), size_arr);
            }

            transpose_matrix(ref matr, size);

            Console.ReadLine();
        }
    }
}