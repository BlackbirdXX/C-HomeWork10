//Задача 61: Показать треугольник Паскаля. *Сделать вывод в виде равнобедренного треугольника.

using System;
using static System.Console;
Clear();

Console.WriteLine("Введите нужное количество строк треугольника Паскаля:");
int row = Convert.ToInt32(ReadLine());
PascalTriangle(row);

int Factorial(int n)
{
    int x = 1;
    for (int i = 1; i <= n; i++)
    {
        x *= i;
    }
    return x;
}

void PascalTriangle(int row)
{
    for (int r = 0; r < row; r++)
    {
        for (int i = 0; i <= (row - r); i++)
        {
            Console.Write(" ");
        }
        for (int j = 0; j <= r; j++)
        {
            Console.Write(" ");
            Console.Write(Factorial(r) / (Factorial(j) * Factorial(r - j)));
        }
        Console.WriteLine();
    }
}
