Methods.CalculatorMeniu();

string operationInput;
do
{
    do
    {
        Console.Write("Input operation: ");
        operationInput = Console.ReadLine().ToLower().Trim();
    } while (!Methods.IsOperationInputValid(operationInput));

    double num1, num2;
    double result = 0;
    switch (operationInput)
    {
        case "+":
            Console.WriteLine("input first number: ");
            num1 = Methods.UserInput();
            Console.WriteLine("input second number: ");
            num2 = Methods.UserInput();
            result = Methods.Summation(num1, num2);
            break;
        case "-":
            Console.WriteLine("input first number: ");
            num1 = Methods.UserInput();
            Console.WriteLine("input second number: ");
            num2 = Methods.UserInput();
            result = Methods.Subtraction(num1, num2);
            break;
        case "*":
            Console.WriteLine("input first number: ");
            num1 = Methods.UserInput();
            Console.WriteLine("input second number: ");
            num2 = Methods.UserInput();
            result = Methods.Multiplication(num1, num2);
            break;
        case "/":
            Console.WriteLine("input first number: ");
            num1 = Methods.UserInput();
            Console.WriteLine("input second number: ");
            num2 = Methods.UserInput();
            result = Methods.Division(num1, num2);
            break;
        case "pow":
            Console.WriteLine("input a number: ");
            num1 = Methods.UserInput();
            Console.WriteLine("input a power value: ");
            num2 = Methods.UserInput();
            result = Methods.Power(num1, num2);
            break;
        case "sqrt":
            Console.WriteLine("input a number a square root to be extracted from: ");
            num1 = Methods.UserInput();
            result = Methods.Sqrt(num1);
            break;
    }
    Console.WriteLine($"Result is: {result}");
} while (operationInput != "q");



public static class Methods
{
    public static int GetTextLength(string text, bool includeLeadSpace = false)
    {
        if (!includeLeadSpace)
        {
            return text.Trim().Length;
        }
        return text.Length;
    }

    public static void CalculatorMeniu()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("CALCULATOR");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("Possible operations:");
        Console.WriteLine("""
            1: +
            2: -
            3: *
            4: /
            5: Pow
            6: Sqrt
            """);
        Console.ForegroundColor = ConsoleColor.DarkYellow;
        Console.WriteLine("To exit application input 'Q'");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Input Operands and operation: ");
        Console.ResetColor();
    }

    public static double Summation(double operand1, double operand2)
    {
        return operand1 + operand2;
    }

    public static double Subtraction(double operand1, double operand2)
    {
        return operand1 - operand2;
    }

    public static double Multiplication(double operand1, double operand2)
    {
        return operand1 * operand2;
    }

    public static double Division(double operand1, double operand2)
    {
        return operand1 / operand2;
    }

    public static double Power(double operand1, double operand2)
    {
        return Math.Pow(operand1, operand2);
    }

    public static double Sqrt(double operand1)
    {
        return Math.Sqrt(operand1);
    }

    public static bool IsOperationInputValid(string input)
    {
        if (input == "+" || input == "-" || input == "*" || input == "/" || input == "pow" || input == "sqrt" || input == "q")
        {
            return true;
        }
        return false;
    }

    public static double UserInput()
    {
        double num;
        string input;
        do
        {
            input = Console.ReadLine().ToLower().Trim();
        } while (!double.TryParse(input, out num));
        return num;
    }
}