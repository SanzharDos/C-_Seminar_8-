// Задача 55: Задайте двумерный массив. Напишите программу, которая заменяет строки на столбцы. В случае, если это невозможно, программа должна вывести сообщение для пользователя.


void FillArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(1, 11);
        }
    }
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        Console.Write("{ ");
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j],3}\t");
        }
        Console.Write("}");
        Console.WriteLine();
    }
}

int[,] NewArray(int[,] array)
{
    // Мой способ:
    // 
    // int count = 0;
    // for (int i = 0; i < array.GetLength(0); i++)
    // {
    //     for (int j = count; j < array.GetLength(1); j++)
    //     {
    //         int temp = array[i, j];
    //         array[i, j] = array[j, i];
    //         array[j, i] = temp;
    //     }
    //     count++;
    // }
    //
    // Способ на семинаре:
    for (int i = 0; i < array.GetLength(0); i++)
        for (int j = i; j < array.GetLength(1); j++)
            (array[i, j], array[j, i]) = (array[j, i], array[i, j]);

    return array;
}

Console.WriteLine("Введите количество строк двумерного массива:");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов двумерного массива");
int cols = Convert.ToInt32(Console.ReadLine());
int[,] array = new int[rows, cols];
FillArray(array);
Console.WriteLine($"Сгенерирован массив из {array.GetLength(0)} строк и {array.GetLength(1)} столбцов:");
PrintArray(array);
if (array.GetLength(0) == array.GetLength(1))
{
    Console.WriteLine($"Строки и столбцы массива были заменены местами, измененный массив:");
    PrintArray(NewArray(array));
}
else Console.WriteLine($"Строки и столбцы массива нельзя заменить местами, т.к. количество столбцов и строк не равны друг другу");