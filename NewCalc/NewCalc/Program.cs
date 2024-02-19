using System;

namespace Variable
{
    class program
    {
        static void Main(string[] args)
        {
            double num1, num2;

            while(true)
            {
                Console.WriteLine("Enter first number: ");
                num1 = GetUserEntry();

                Console.WriteLine("Enter first number: ");
                num2 = GetUserEntry();

                Console.WriteLine("Enter operation (+, -, *, /, cos, tan, sin): ");
                char operation = GetUserOperation();

                double result;
                if(operation == 't' || operation == 'c' || operation == 's')
                {
                    result = TrigonometryCalculation(num1, operation);
                }
                else
                {
                    result = Calculation(num1, num2, operation);
                }

                Console.WriteLine($"Result: {result}");

                Console.WriteLine("Do you want to perform another calculation (Y/N): ");
                char Response = Console.ReadKey().KeyChar;
                if(Response != 'Y' || Response != 'y')
                {
                    break;
                }
            }
            Console.WriteLine("Enter any key to exit...");
            Console.ReadLine();
        }

        // Method for Getting user number input
        static double GetUserEntry()
        {
            double number;
            while(!double.TryParse(Console.ReadLine(), out number))
            {
                break;
            }
            return number;
        }

        // Method for getting user operation input

        static char GetUserOperation()
        {
            char operation;
            while(!char.TryParse(Console.ReadLine(), out operation) && !SupportedOperation(operation))
            {
                Console.WriteLine("Invalid operation. Enter a valid operation");
            }
            return operation;
        }
        
        // Methos for validating user entry

        static bool SupportedOperation(char operation)
        {
            return operation == '-' || operation == '+' || operation == '*' || operation == '/' || operation == 'c' || operation == 't' || operation == 's';
        }

        // Method for calculation

        static double Calculation(double num1, double num2, char operation)
        {
            switch(operation)
            {
                case '+':
                    return num1 + num2;
                case '-':
                    return num1 - num2;
                case '*':
                    return num1 * num2;
                case '/':
                    if(num2 == 0)
                    {
                        return double.NaN;
                    }
                    else
                    {
                        return num1 / num2;
                    }
                default:
                    Console.WriteLine("Invalid Entry");
                    return 0;

            }
        }

        // Trigonometry Calculation

        static double TrigonometryCalculation(double num1, char operation)
        {
            double radians = num1 * Math.PI / 180;

            switch(operation)
            {
                case 'c':
                    return Math.Cos(radians);
                case 't':
                    return Math.Tan(radians);
                case 's':
                    return Math.Sin(radians);
                default:
                    Console.WriteLine("Invalid Entry");
                    return 0;
            }

        }
    }
}