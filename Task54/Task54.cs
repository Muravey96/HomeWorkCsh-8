/* Задача 54: Задайте двумерный массив. Напишите программу, которая упорядочит 
по убыванию элементы каждой строки двумерного массива.
*/

Console.Clear();

int row = GetNumberFromUser("Введите количество строк: ","Ошибка ввода!");
int col = GetNumberFromUser("Введите количество столбцов: ","Ошибка ввода!");
int[,] matrix = GetArray(row, col, 0, 100);
PrintArray(matrix);
Console.WriteLine();
MatrixRowBubbleSort(matrix);
PrintArray(matrix);

//////////////////
int GetNumberFromUser(string message, string errorMessage)
{
    while(true)
    {
        Console.Write(message);
        bool isCorrect = int.TryParse(Console.ReadLine(), out int userNumber);
        if(isCorrect)
            return userNumber;
        Console.WriteLine(errorMessage);
    } 
}

/////////////////

int[,] GetArray(int m, int n, int minValue, int maxValue)
{
    int[,] result = new int[m, n];
    for (int i = 0; i < m; i++)
    {
        for (int j = 0; j < n; j++)
        {
            result[i, j] = new Random().Next(minValue, maxValue + 1);;
        }
    }
    return result;
}

//////////////// 
int[] BubbleSort(int[] array)
{
    int temp;
    int count = 0;   
    int n = array.Length;
    for (int i = 0; i < n - 1; i++)   
    {
        for (int j = 0; j < n - i - 1; j++)   
        {
            if (array[j] < array[j + 1])
            {
                temp = array[j];
                array[j] = array[j + 1];
                array[j + 1] = temp;
                count++;
            }
        }
        if (count == 0) break;   
        count = 0;
    }    
    return array;
}

//////////////////////

void MatrixRowBubbleSort(int[,] array)
{    
    int[] sortedRow = new int[array.GetLength(1)];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sortedRow[j] = array[i,  j];   
        }
        sortedRow = BubbleSort(sortedRow);   
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i,  j] = sortedRow[j];   
        }
    }
}

//////////////////////////

void PrintArray(int[,] inArray)
{
    for (int i = 0; i < inArray.GetLength(0); i++)
    {
        for (int j = 0; j < inArray.GetLength(1); j++)
        {
             Console.Write($"{inArray[i, j]} ");
        }
         Console.WriteLine();
     }
}