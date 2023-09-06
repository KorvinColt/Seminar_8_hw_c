// Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4

// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2


int[,] matrix =
{
    { 1, 4, 7, 2 },
    { 5, 9, 2, 3 },
    { 8, 4, 2, 4 }
};

SortRowsDescending(matrix);

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write(matrix[i, j] + " ");
    }
    Console.WriteLine();
}

static void SortRowsDescending(int[,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1) - 1; j++)
        {
            for (int k = j + 1; k < matrix.GetLength(1); k++)
            {
                if (matrix[i, k] > matrix[i, j])
                {
                    int temp = matrix[i, k];
                    matrix[i, k] = matrix[i, j];
                    matrix[i, j] = temp;
                }
            }
        }
    }
}

// Задача 56: Задайте прямоугольный двумерный массив. Напишите программу, которая будет находить строку с наименьшей суммой элементов.

// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт номер строки с наименьшей суммой элементов: 1 строка

Random random = new Random();

int rows = 4;
int columns = 4;

int[,] array = new int[rows, columns];
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        array[i, j] = random.Next(1, 10);
    }
}

int minSum = int.MaxValue;
int minRow = -1;

for (int i = 0; i < rows; i++)
{
    int sum = 0;
    for (int j = 0; j < columns; j++)
    {
        sum += array[i, j];
    }

    if (sum < minSum)
    {
        minSum = sum;
        minRow = i;
    }
}

Console.WriteLine("Массив:");
for (int i = 0; i < rows; i++)
{
    for (int j = 0; j < columns; j++)
    {
        Console.Write(array[i, j] + " ");
    }
    Console.WriteLine();
}

if (minRow != -1)
{
    Console.WriteLine($"Строка с наименьшей суммой элементов: {minRow + 1}");
}
else
{
    Console.WriteLine("Массив пустой.");
}

// Задача 58: Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

int[,] matrixA =
{
    { 2, 4 },
    { 3, 2 }
};

int[,] matrixB =
{
    { 3, 4 },
    { 3, 3 }
};

int[,] resultMatrix = MultiplyMatrices(matrixA, matrixB);

Console.WriteLine("Результирующая матрица:");
PrintMatrix(resultMatrix);

static int[,] MultiplyMatrices(int[,] matrixA, int[,] matrixB)
{
    int rowsA = matrixA.GetLength(0);
    int colsA = matrixA.GetLength(1);
    int colsB = matrixB.GetLength(1);

    int[,] resultMatrix = new int[rowsA, colsB];

    for (int i = 0; i < rowsA; i++)
    {
        for (int j = 0; j < colsB; j++)
        {
            int sum = 0;
            for (int k = 0; k < colsA; k++)
            {
                sum += matrixA[i, k] * matrixB[k, j];
            }
            resultMatrix[i, j] = sum;
        }
    }

    return resultMatrix;
}

static void PrintMatrix(int[,] matrix)
{
    int rows = matrix.GetLength(0);
    int cols = matrix.GetLength(1);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write(matrix[i, j] + " ");
        }
        Console.WriteLine();
    }
}

// Задача 60. ...Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. Напишите программу, которая будет
// построчно выводить массив, добавляя индексы каждого элемента.
// Массив размером 2 x 2 x 2
// 66(0,0,0) 25(0,1,0)
// 34(1,0,0) 41(1,1,0)
// 27(0,0,1) 90(0,1,1)
// 26(1,0,1) 55(1,1,1)

int[,,] threeDimArray = CreateThreeDimArray(2, 2, 2);
PrintThreeDimArray(threeDimArray);

static int[,,] CreateThreeDimArray(int x, int y, int z)
{
    int[,,] array = new int[x, y, z];
    bool[] used = new bool[100];

    Random random = new Random();

    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z; k++)
            {
                int num;
                do
                {
                    num = random.Next(10, 100);
                } while (used[num]);

                array[i, j, k] = num;
                used[num] = true;
            }
        }
    }

    return array;
}

static void PrintThreeDimArray(int[,,] array)
{
    int x = array.GetLength(0);
    int y = array.GetLength(1);
    int z = array.GetLength(2);

    for (int i = 0; i < x; i++)
    {
        for (int j = 0; j < y; j++)
        {
            for (int k = 0; k < z; k++)
            {
                Console.Write(array[i, j, k] + $"({i},{j},{k}) ");
            }
            Console.WriteLine();
        }
    }
}

// Задача 62. Напишите программу, которая заполнит спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 01 02 03 04
// 12 13 14 05
// 11 16 15 06
// 10 09 08 07

int n = 4;
int[,] spiralArray = FillSpiralArray(n);

PrintArray(spiralArray);

static int[,] FillSpiralArray(int n)
{
    int[,] array = new int[n, n];

    int left = 0,
        right = n - 1,
        top = 0,
        bottom = n - 1;
    int current = 1;

    while (left <= right && top <= bottom)
    {
        for (int i = left; i <= right; i++)
        {
            array[top, i] = current++;
        }
        top++;

        for (int i = top; i <= bottom; i++)
        {
            array[i, right] = current++;
        }
        right--;

        for (int i = right; i >= left; i--)
        {
            array[bottom, i] = current++;
        }
        bottom--;

        for (int i = bottom; i >= top; i--)
        {
            array[i, left] = current++;
        }
        left++;
    }

    return array;
}

static void PrintArray(int[,] array)
{
    int n = array.GetLength(0);

    for (int i = 0; i < n; i++)
    {
        for (int j = 0; j < n; j++)
        {
            Console.Write(array[i, j].ToString("D2") + " ");
        }
        Console.WriteLine();
    }
}