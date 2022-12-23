/* Задача 60: Сформируйте трёхмерный массив из неповторяющихся двузначных чисел. 
Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента. */

Console.Clear();

int dimensionX = GetNumberFromUser("Введите количество строк: ","Ошибка ввода!");
int dimensionY = GetNumberFromUser("Введите количество столбцов: ","Ошибка ввода!");
int dimensionZ = GetNumberFromUser("Введите количество слоев: ","Ошибка ввода!");

int[, ,] matrix3D = GetArray(dimensionX, dimensionY, dimensionZ);

PrintArray(matrix3D);

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
int[, ,] GetArray(int x, int y, int z)
{
    int[, ,] result = new int[x, y, z];   
    int[] newNumbers = new int[x * y * z];   
    int count = 0;   
    for (int k = 0; k < z; k++)   
    {
        for (int i = 0; i < x; i++)
        {
            for (int j = 0; j < y; j++)
            {
                result[i, j, k] = AddNewElement(result[i, j, k], newNumbers, count, 10, 99);
                newNumbers[count] = result[i, j, k];
                count++;
            }
        }
    }
    return result;
}

/////////////////////
int AddNewElement(int element, int[] array, int count, int minValue, int maxValue)
{
    element = new Random().Next(minValue, maxValue + 1);   
    if (array.Contains(element)) element = AddNewElement(element, array, count, minValue, maxValue); 
    else 
    {
        array[count] = element;  
        count++;
    }
    return element;            
}

//////////////////
void PrintArray(int[,,] inArray)
{
    for (int k = 0; k < inArray.GetLength(2); k++)
    {    
        for (int i = 0; i < inArray.GetLength(0); i++)
        {
            for (int j = 0; j < inArray.GetLength(1); j++)
            {
                Console.Write($"{inArray[i, j, k]} ({i},{j},{k})  ");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
    }
}