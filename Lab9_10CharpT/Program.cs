using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        string formula = ReadFormulaFromFile("formula.txt");
        int result = EvaluateFormula(formula);
        Console.WriteLine($"Результат: {result}");
    }

    static string ReadFormulaFromFile(string filePath)
    {
        try
        {
            return File.ReadAllText(filePath).Trim();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка читання файлу: {ex.Message}");
            return null;
        }
    }

    static int EvaluateFormula(string formula)
    {
        Stack<int> stack = new Stack<int>();
        for (int i = 0; i < formula.Length; i++)
        {
            char c = formula[i];
            if (Char.IsDigit(c))
            {
                stack.Push(int.Parse(c.ToString()));
            }
            else if (c == 'm' || c == 'p')
            {
                stack.Push((int)c);
            }
            else if (c == ')')
            {
                int b = stack.Pop();
                char operation = (char)stack.Pop();
                int a = stack.Pop();
                int result;
                if (operation == 'm')
                {
                    result = (a - b) % 10;
                }
                else // operation == 'p'
                {
                    result = (a + b) % 10;
                }
                stack.Push(result);
            }
        }
        return stack.Pop();
    }
}
