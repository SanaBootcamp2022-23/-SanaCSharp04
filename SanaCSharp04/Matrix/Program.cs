Random random = new Random();
uint N, M;
Console.Write("Row Count: ");
N = uint.Parse(Console.ReadLine());
Console.Write("Col Count: ");
M = uint.Parse(Console.ReadLine());
int CountingPosElem = 0, CountMaxElem = 0, CountRowWithoutZero = 0, CountColWithZero = 0, CountSameElem = 0, Repeat = 0, IndexOfRowsWithSameElem = 0;
int[,] matrix = new int[N, M];
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        matrix[i, j] = random.Next(-10, 10 + 1);
    }
}
Console.WriteLine();
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[i, j], 3}");
    }
    Console.WriteLine();
}
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] > 0)
        {
            CountingPosElem++;
        }
    }
}
Console.WriteLine($"Counting of positive elements is: {CountingPosElem}");
int max = matrix[0, 0];
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] > max)
        {
            max = matrix[i, j];
            CountMaxElem = 0;
        }
        if (matrix[i, j] == max)
        {
            CountMaxElem++;
        }
    }
}
if (CountMaxElem > 1)
    Console.WriteLine($"Max repeated elemet is: {max} and count of reapeating is: {CountMaxElem}");
else
    Console.WriteLine($"The maximum element does not repeat");

for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] == 0)
        {
            CountRowWithoutZero++;
            break;
        }
    }
}
Console.WriteLine($"Count rows without zero: {N - CountRowWithoutZero}");
for (int j = 0; j < matrix.GetLength(1); j++)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, j] == 0)
        {
            CountColWithZero++;
            break;
        }
    }
}
Console.WriteLine($"Count colums with zero element: {CountColWithZero}");
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1) - 1; j++)
    {
        if (matrix[i, j] == matrix[i, j + 1])
        {
            CountSameElem++;
        }
    }
    if (CountSameElem > Repeat)
    {
        Repeat = CountSameElem;
        IndexOfRowsWithSameElem = i;
    }
    CountSameElem = 0;
}
Console.WriteLine($"Row with longest series of same elements : {IndexOfRowsWithSameElem}");
for (int i = 0; i < matrix.GetLength(0); i++)
{
    bool row = true;
    int prod = 1;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if (matrix[i, j] < 0)
        {
            row = false;
            break;
        }
    }
    if (row)
    {
        for (int k = 0; k < matrix.GetLength(1); k++)
        {
            prod *= matrix[i, k];
        }
        Console.WriteLine($"Row {i + 1} without negative number, product: {prod}");
    }
    else
    {
        Console.WriteLine($"Row {i + 1} with negative number, product = 0");
    }
}
int CoordRow, CoordCol, summa, maxSum = 0;
for (int j = 1; j < matrix.GetLength(1); j++)
{
    CoordRow = 0;
    CoordCol = j;
    summa = 0;
    for (int k = 0; k < matrix.GetLength(0) - j; k++)
    {
        summa += matrix[CoordRow, CoordCol];
        CoordRow++;
        CoordCol++;
    }
    if (summa > maxSum)
    {
        maxSum = summa;
    }
}
for (int i = 1; i < matrix.GetLength(1); i++)
{
    CoordRow = i;
    CoordCol = 0;
    summa = 0;
    for (int k = 0; k < matrix.GetLength(0) - i; k++)
    {
        summa += matrix[CoordRow, CoordCol];
        CoordRow++;
        CoordCol++;
    }
    if (summa > maxSum)
    {
        maxSum = summa;
    }
}
Console.WriteLine($"Maximum among of sums of diagonales parallel to main diagonal: {maxSum}");
for (int j = 0; j < matrix.GetLength(1); j++)
{
    bool flag = true;
    int SumInColWithoutNegEl = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, j] < 0)
        {
            flag = false;
            break;
        }
    }
    if (flag)
    {
        for (int k = 0; k < matrix.GetLength(0); k++)
        {
            SumInColWithoutNegEl += matrix[k, j];
        }
        Console.WriteLine($"Sum of Col {j + 1} without negative elements: {SumInColWithoutNegEl}");
    }
    else
    {
        Console.WriteLine($"Col {j + 1} with negative elements, sum = 0");
    }
}
int minSum = 0, sum = 0;
for (int j = matrix.GetLength(1) - 2; j >= 0; j--)
{
    CoordRow = 0;
    CoordCol = j;
    sum = 0;
    for (int k = 0; k <= j; k++)
    {
        sum += Math.Abs(matrix[CoordRow, CoordCol]);
        CoordRow++;
        CoordCol--;
    }
    if (sum > minSum)
    {
        minSum = sum;
    }
}
for (int i = 1; i < matrix.GetLength(0); i++)
{
    CoordRow = i;
    CoordCol = matrix.GetLength(1) - 1;
    sum = 0;
    for (int k = 0; k < matrix.GetLength(1) - i; k++)
    {
        sum += Math.Abs(matrix[CoordRow, CoordCol]);
        CoordRow++;
        CoordCol--;
    }
    if (sum > minSum)
    {
        minSum = sum;
    }
}
Console.WriteLine($"Minimin among of abs of elements that parallel to side diagonal: {minSum}");
for (int j = 0; j < matrix.GetLength(1); j++)
{
    bool flag_repeat = true;
    int SumOfColumThatContainOneNegElem = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if (matrix[i, j] < 0)
        {
            flag_repeat = false;
            break;
        }
    }
    if (!flag_repeat)
    {
        for (int k = 0; k < matrix.GetLength(0); k++)
        {
            SumOfColumThatContainOneNegElem += matrix[k, j];
        }
        Console.WriteLine($"Sum of Col {j + 1} that contain at least one negative element: {SumOfColumThatContainOneNegElem}");
    }
    else
    {
        Console.WriteLine($"Col {j + 1} does not have negative elements, sum = 0");
    }
}
Console.WriteLine($"Transposed matrix: ");
Console.WriteLine();
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        Console.Write($"{matrix[j, i], 3}");
    }
    Console.WriteLine();
}

