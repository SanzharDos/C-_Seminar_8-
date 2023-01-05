// Задача 57: Составить частотный словарь элементов двумерного массива. Частотный словарь содержит информацию о том, сколько раз встречается элемент входных данных.
// 1, 2, 3
// 4, 6, 1
// 2, 1, 6
// 1 встречается 3 раза
// 2 встречается 2 раз
// 3 встречается 1 раз
// 4 встречается 1 раз
// 6 встречается 2 раза

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

void Check(int[,] array) // Здесь заданы конкретные пределы значений элементов массива
{
    for (int find = 1; find < 11; find++)
    {
        int count = 0;
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array.GetLength(1); j++)
            {
                if (find == array[i, j])
                    count++;
            }
        }
        if (count != 0)
        {
            Console.Write($"Число {find} встречается {count} ");
            if (count < 2 || count > 4)
            {
                Console.Write("раз");
                Console.WriteLine();
            }
            else
            {
                Console.Write("раза");
                Console.WriteLine();
            }
        }
    }
}

int[] Check1(int[,] array)
{
    int[] numbers = new int[array.GetLength(0) * array.GetLength(1)];
    int count = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            numbers[count] = array[i, j];
            count++;
        }
    }
    return numbers;
}

void PrintArray2(int[] array)
{
    Console.WriteLine("Сформирован одномерный массив:");
    Console.Write("{ ");
    foreach (int el in array)
    {
        Console.Write($"{el} ");
    }
    Console.Write("}");
    Console.WriteLine();
}

void CheckAndPrint(int[] array) // Второй метод, однако необходимо делать проверку на повторяющиеся значения
{
    for (int i = 0; i < array.Length; i++)
    {
        int count = 0;
        for (int j = 1; j < array.Length; j++)
        {
            if (array[i] == array[j])
                count++;
        }
        if (count != 0)
        {
            Console.Write($"Число {array[i]} встречается {count} ");
            if (count < 2 || count > 4)
            {
                Console.Write("раз");
                Console.WriteLine();
            }
            else
            {
                Console.Write("раза");
                Console.WriteLine();
            }
        }
    }
}

int Check_Max(int[,] array)
{
    int max = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            if (array[i, j] > max) max = array[i, j];
        }
    }
    return max;
}

void Check2(int[,] array, int max)
{
    int[] temp = new int[max];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            temp[array[i, j]] += 1;
        }
    }
    for (int count = 0; count <= max; count++)
    {
        if (temp[count] != 0)
        {
            Console.Write($"Число {count} встречается {temp[count]} ");
            if (temp[count] < 2 || temp[count] > 4)
            {
                Console.Write("раз");
                Console.WriteLine();
            }
            else
            {
                Console.Write("раза");
                Console.WriteLine();
            }
        }
    }
}

Console.WriteLine("Введите количество строк двумерного массива:");
int rows = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Введите количество столбцов двумерного массива");
int cols = Convert.ToInt32(Console.ReadLine());
int[,] array = new int[rows, cols];
FillArray(array);
Console.WriteLine($"Сгенерирован массив из {array.GetLength(0)} строк и {array.GetLength(1)} столбцов:");
PrintArray(array);
int max = Check_Max(array);
Console.WriteLine();
Check(array);
Console.WriteLine();
PrintArray2(Check1(array));
CheckAndPrint(Check1(array));
Console.WriteLine();
Check2(array, max);