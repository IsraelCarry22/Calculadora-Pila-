using System;
using System.Collections.Generic;

namespace Calculadora_Pila_.Clase
{
    public class Calculadora
    {
        public static double EvaluateExpression(string expression)
        {
            Stack<double> _Operand = new Stack<double>();
            Stack<char> _Operator = new Stack<char>();

            string[] token = expression.Split(' ');

            foreach (string item in token)
            {
                if (double.TryParse(item, out double operand))
                {
                    _Operand.Push(operand);
                }
                else if (IsOperator(item[0]))
                {
                    while (_Operator.Count > 0 && Precedence(_Operator.Peek()) >= Precedence(item[0]))
                    {
                        double operand2 = _Operand.Pop();
                        double operand1 = _Operand.Pop();
                        char op = _Operator.Pop();
                        double result = PerformOperation(operand1, operand2, op);
                        _Operand.Push(result);
                    }
                    _Operator.Push(item[0]);
                }
            }
            while (_Operator.Count > 0)
            {
                double operand2 = _Operand.Pop();
                double operand1 = _Operand.Pop();
                char op = _Operator.Pop();
                double result = PerformOperation(operand1, operand2, op);
                _Operand.Push(result);
            }
            return _Operand.Pop();
        }

        private static double PerformOperation(double operand1, double operand2, char op)
        {
            switch (op)
            {
                case '+':
                    return operand1 + operand2;
                case '-':
                    return operand1 - operand2;
                case '*':
                    return operand1 * operand2;
                case '/':
                    if (operand2 != 0)
                        return operand1 / operand2;
                    else
                        throw new DivideByZeroException("Division by zero.");
                default:
                    throw new ArgumentException("Invalid operator.");
            }
        }

        private static int Precedence(char op)
        {
            switch (op)
            {
                case '+':
                case '-':
                    return 1;
                case '*':
                case '/':
                    return 2;
                default:
                    return 0;
            }
        }

        private static bool IsOperator(char c)
        {
            return c == '+' || c == '-' || c == '*' || c == '/';
        }
    }
}