using Calculadora_Pila_.Clase;
using System;

namespace Calculadora_Pila_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("== Calculadora Simple con Pila ==");
            Console.Write("Ingrese una expresión aritmética (ejemplo: '2 + 10 * 3 - 6 / 2'): ");
            string expression = Console.ReadLine();
            try
            {
                double result = Calculadora.EvaluateExpression(expression);
                Console.WriteLine($"Resultado: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.ReadKey();
        }
    }
}