using System;

namespace SuncoastHumanResources
{
    class Program
    {
        static void Main(string[] args)
        {
            //greeting
            static void DisplayGreeting()
            {
                Console.WriteLine("---------------------------------------");
                Console.WriteLine("Welcome to Suncoast Human Resources");
                Console.WriteLine("---------------------------------------");
                Console.WriteLine();
            }
            static string PromptForString(string prompt)
            {
                Console.Write(prompt);
                var userInput = Console.ReadLine();
                return userInput;
            }
            static int PromptForInteger(string prompt)
            {
                Console.Write(prompt);
                // var userInput = int.Parse(Console.ReadLine());
                int userInput;
                var isThisGoodInput = int.TryParse(Console.ReadLine(), out userInput);
                if (isThisGoodInput)
                {
                    return userInput;
                }
                else
                {
                    Console.WriteLine("Sorry, that is not a valid input.");
                    return 0;
                }
            }
            //we create our employee object
            var employee = new Employee();

            DisplayGreeting();

            employee.Name = PromptForString("What is your name?: ");
            employee.Department = PromptForInteger("What is your department number?:");
            employee.Salary = PromptForInteger("What is your salary in dollars?: ");
            Console.WriteLine($"Hello, {employee.Name}, you make {employee.Salary} dollars per month.");
        }
    }
}
