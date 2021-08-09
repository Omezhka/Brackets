using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var s = Console.ReadLine();
            var result = CheckBrackets.Check(s) ? $"Строка: \"{s}\", результат: корректно." : $"Строка: \"{s}\", результат: некорректно.";
            Console.WriteLine(result);
        }
    }
}
