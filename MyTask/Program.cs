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

// Метод парсит строку, введенную пользователем в массив, и заодно возвращает количество элементов не длиннее 3 символов
(string[], int, bool) ParseMsg(int count, string message)
{
    string[] result = new string[count];
    int shortItemCnt = 0;
    int element = 0;
    string item = string.Empty;
    for (int i = 0; i < message.Length; i++)
    {
        if (message[i] == ',')
        {
            if (AddItem(ref result, item, element))
            {
                if (item.Length <= 3) shortItemCnt++;
                element++;
                item = string.Empty;
            }
            else break;
        }
        else
        {
            item += message[i].ToString();
        }
    }
    if (AddItem(ref result, item, element))
    {
        if (item.Length <= 3) shortItemCnt++;
        return (result, shortItemCnt, true);
    }
    else return (new string[0], 0, false);
}

// Метод добавляет элемент в массив
bool AddItem(ref string[] array, string item, int index)
{
    bool result = true;
    if (index >= array.Length)
    {
        result = false;
        Console.WriteLine("Вы ввели больше элементов массива, чем указали!");
    }
    else array[index] = item;

    return result;
}

// Метод выводит заданный массив в консоль 
void PrintArray(string[] data)
{
    int cnt = data.Length;
    for (int i = 0; i < cnt; i++)
    {
        Console.Write(data[i]);
        if (i < cnt - 1) Console.Write(", ");
    }
    Console.WriteLine();
}

// Метод возвращает новый массив, состоящий из элементов заданного не длиннее 3 символов
string[] NewArray(int count, string[] data)
{
    string[] result = new string[count];
    int elements = 0;
    foreach (string item in data)
    {
        if (item.Length <= 3)
        {
            result[elements] = item;
            elements++;
        }
    }
    return result;
}

int number = GetNumber("Введите количество элементов массива: ");

Console.Write("Введите элементы массива через запятую (без пробелов): ");
(string[] data, int shortItemCount, bool correct) = ParseMsg(number, Console.ReadLine());

if (correct)
{
    Console.WriteLine();
    Console.WriteLine($"Вы ввели массив из {number} элементов:");
    PrintArray(data);

    string[] newArray = NewArray(shortItemCount, data);

    Console.WriteLine();
    Console.WriteLine($"Полученный массив из элементов не длиннее 3 символов:");
    PrintArray(newArray);
}