/* Задача 62: Заполните спирально массив 4 на 4. */

Console.Clear();

int row = GetNumberFromUser("Введите количество строк: ","Ошибка ввода!");
int col = GetNumberFromUser("Введите количество столбцов: ","Ошибка ввода!");
int[,] matrix = new int[row, col];
if (row == 1 && col == 1) matrix[0,0] = 1;   
else matrix = GetSpiralArray(row, col);
PrintArray(matrix);

//////////////////
int[,] GetSpiralArray(int row, int col)
{
    int[,] spiralArray = new int[row, col];
    int i = 0;   
    int j = 0;  
    int step = 1;   
    int num = 1;   
    
    while (num <= row * col) 
    {
        while (j + step >= 0 && j + step < col)
        {
            if (spiralArray[i, j] == 0)
            {
                spiralArray[i, j] = num;
                num++; 
            }         
            if (num > row * col ||  spiralArray[i, j + step] != 0) break;   
            j += step;
        }
        
        while (i + step >= 0 && i + step < row)
        {           
            if (spiralArray[i, j] == 0)
            {
                spiralArray[i, j] = num;
                num++;
            }          
            if (num > row * col || spiralArray[i + step, j] != 0) break;               
            i += step;
        }
        step *= -1;   
    }    
    return spiralArray;
}

//////////////
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

//////////////
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