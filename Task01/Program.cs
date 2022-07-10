//Задача 59: Из двумерного массива целых чисел удалить строку и столбец, на пересечении которых расположен наименьший элемент.

using System;
using static System.Console;
Clear();
WriteLine("Программа, которая из двумерного массива целых чисел удалить строку и столбец, \nна пересечении которых расположен наименьший элемент.");
WriteLine("Введите размеры двумерного массива. \nПоложительные целые числа, через пробел.");
string[] size = ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
int min = new Random().Next(10, 20);
int max = min + int.Parse(size[0]) * int.Parse(size[1]);
int[,] array = FillArray(new int[] { int.Parse(size[0]), int.Parse(size[1]) }, min, max);
PrintArray(array);
string position = FindMinimalElement(array);
int[,] cutArray = CutTheLines(array, position);
PrintArray(cutArray);

int[,] CutTheLines(int[,] inputArray, string adress)
{
    int[,] cutArray = new int[inputArray.GetLength(0) - 1, inputArray.GetLength(1) - 1];
    for (int i = 0; i < cutArray.GetLength(0); i++)
    {
        int row = i >= adress[0] ? i + 1 : i;
        for (int j = 0; j < cutArray.GetLength(1); j++)
        {
            int column = j >= adress[1] ? j + 1 : j;
            cutArray[i, j] = inputArray[row, column];
        }
    }
    return cutArray;
}

string FindMinimalElement(int[,] inputArray)
{
    string adress = String.Empty;
    int row = 0;
    int column = 0;
    int minElement = inputArray[0, 0];
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            if (inputArray[i, j] < minElement)
            {
                minElement = inputArray[i, j];
                row = i;
                column = j;
            }
        }
    }
    adress = Convert.ToString(row) + Convert.ToString(column);
    WriteLine($"Минимальный элемент: {minElement}\n");
    WriteLine($"Координаты минимального элемента: ({adress[0]},{adress[1]})");
    return adress;
}

bool FindElement(int[,] inputArray, int element)
{
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            if (inputArray[i, j] == element) return true;
        }
    }
    return false;
}

int[,] FillArray(int[] sizes, int minValue, int maxValue)
{
    int[,] outputArray = new int[sizes[0], sizes[1]];
    for (int i = 0; i < outputArray.GetLength(0); i++)
    {
        int j = 0;
        while (j < outputArray.GetLength(1))
        {
            int elem = new Random().Next(minValue, maxValue + 1);
            if (FindElement(outputArray, elem)) continue;
            outputArray[i, j] = elem;
            j++;
        }
    }
    return outputArray;
}

void PrintArray(int[,] inputArray)
{
    for (int i = 0; i < inputArray.GetLength(0); i++)
    {
        for (int j = 0; j < inputArray.GetLength(1); j++)
        {
            Write($"{inputArray[i, j]} ");
        }
        WriteLine();
    }
}