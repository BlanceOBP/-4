﻿using System;

namespace IDZ
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ввод данных, а именно размерность массива по параметрам n и m
            Console.Write("Введите параметр n: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введите параметр m: ");
            int m = Convert.ToInt32(Console.ReadLine());

            // Инициализация массива
            int[,] inputData = Array_Position(n, m);

            // Цикл для вывода данных
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    Console.Write($" {inputData[j, i],2}");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        // Статичная функция для обработки массива. Принимает два параметра - размерность
        static int[,] Array_Position(int n, int m)
        {
            int dir = 1; // направление 1-влево, 2-вниз, 3-вправо, 4-вверх

            // Инициализация вспомогательного массива
            int[,] mass = new int[m, n];

            // Цикл для заполнения массива нулями
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    mass[i, j] = 0;
                }
            }

            int current = m * n;
            int c1 = m - 1;
            int c2 = 0;

            mass[c1, c2] = current--;

            while (current > 0)
            {
                // Множественная выборка для определения позиция в массиве
                switch (dir)
                {
                    case 1:
                        if (c1 > 0 && mass[c1 - 1, c2] == 0)
                        {
                            c1--;
                        }
                        else
                        {
                            dir = 2;
                            c2++;
                        }
                        break;
                    case 2:
                        if (c2 < (n - 1) && mass[c1, c2 + 1] == 0)
                        {
                            c2++;
                        }
                        else
                        {
                            dir = 3;
                            c1++;
                        }
                        break;
                    case 3:
                        if (c1 < (m - 1) && mass[c1 + 1, c2] == 0)
                        {
                            c1++;
                        }
                        else
                        {
                            dir = 4;
                            c2--;
                        }
                        break;
                    case 4:
                        if (c2 > 0 && mass[c1, c2 - 1] == 0)
                        {
                            c2--;
                        }
                        else
                        {
                            dir = 1;
                            c1--;
                        }
                        break;
                }
                mass[c1, c2] = current--;
            }

            // Возвращение результата
            return mass;
        }
    }
}