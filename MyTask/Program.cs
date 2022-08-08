/*

Написать программу, которая из имеющегося массива строк формирует массив из строк, длина которых меньше либо равна 3 символов.
Первоначальный массив можно ввести с клавиатуры либо задать на старте выполнения алгоритма.
При решении не рекомендуется пользоваться коллекциями, лучше обойтись исключительно массивами.

Примеры:
["hello", "2", "world", ":-)"] -> ["2", ":-)"]
["1234", "1567", "-2", "computer sience"] -> ["-2"]
["Russia", "Denmark", "Kazan"] -> []

*/


// Метод получает число из консоли и проверяет его корректность
int GetNumber(string message)
{
    int result = 0;
    string errorMessage = "Вы ввели не число. Введите корректное число.";

    while (true)
    {

        Console.Write(message);

        if (int.TryParse(Console.ReadLine(), out result))
        {
            break;
        }
        else
        {
            Console.Clear();
            Console.WriteLine(errorMessage);
        }
    }

    return result;
}

// Метод парсит строку, введенную пользователем в массив
string[] ParseMsg(int count, string message)
{
    string[] result = new string[count];
    //bool next = false;
    string item = string.Empty;
    for (int i = 0; i < message.Length; i++)
    {
        if (message[i] == ',')
        {
            result[result.Length - 1] = item;
            //next = true;
            item = string.Empty;
        } 
        else
        {
            //if (next && message[i] == ' ') next = false;
            //else item += message[i].ToString();

            item += message[i].ToString();
        }
    }
    return result;
}

// Метод выводит заданный массив в консоль
void PrintArray(string[] data)
{
    int cnt = data.Length;
    for (int i = 0; i < cnt; i++)
    {
        Console.Write(data[i]);
        if (i < cnt-1) Console.Write(", ");         
    } 
}


int number = GetNumber("Введите количество элементов массива: ");
Console.Write("Введите элементы массива через запятую: ");
string[] data = ParseMsg(number, Console.ReadLine());
PrintArray(data);