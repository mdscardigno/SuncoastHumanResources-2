using System;
using System.Collections.Generic;

namespace SuncoastHumanResources
{
    class Program
    {
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
        static void Main(string[] args)
        {
            //greeting
            DisplayGreeting();

            //list of employees
            var employees = new List<Employee>();

            //Should we show the menu?
            var keepShowingTheMenu = true;

            while (keepShowingTheMenu)
            {
                //MENU
                //insert a blank line then prompt them and get their answer (force to upper case)
                Console.WriteLine();
                Console.Write("What do you want to do? (A)dd and employee (S)how all the employees (F)ind and employee or (Q)uit? ");
                var choice = Console.ReadLine().ToUpper();
                //quit or exit
                if (choice == "Q")
                {
                    keepShowingTheMenu = false;
                }

                //show all employee
                else if (choice == "S")
                {
                    //loop through each employee
                    foreach (var employee in employees)
                    {
                        Console.WriteLine("Show the employees");
                        Console.WriteLine($"{employee.Name} is in department {employee.Department} and makes ${employee.Salary}.");
                    }
                }
                // else if (choice == "F") { }
                //while the user has's quit yet
                else
                {
                    //create
                    //make the employee object
                    var employee = new Employee();

                    //we set the properties of the employee object
                    employee.Name = PromptForString("What is your name?: ");
                    employee.Department = PromptForInteger("What is your department number?:");
                    employee.Salary = PromptForInteger("What is your salary in dollars?: ");
                    Console.WriteLine($"Hello, {employee.Name}, you are in the department number {employee.Department} you make ${employee.Salary}.");

                    //we add the employee object to the list of employees
                    employees.Add(employee);
                }//end of while loop
            }




        }
    }
}
