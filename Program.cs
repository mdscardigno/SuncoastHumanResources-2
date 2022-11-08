using System;
using System.Collections.Generic;
using System.Linq;

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
                Console.Write("What do you want to do?\n (A)dd and employee\n (S)how all the employees\n (F)ind and employee\n (D)elete or (Q)uit?\n ");

                var choice = Console.ReadLine().ToUpper();
                //quit or exit
                if (choice == "Q")
                {
                    keepShowingTheMenu = false;
                }

                else if (choice == "D")
                {
                    //small algo
                    //search the database for the employee
                    //prompt for the employee name
                    var employeeName = PromptForString("What is the employee name you are looking for? ");
                    //find the employee
                    var employeeToDelete = employees.FirstOrDefault(employee => employee.Name == employeeName);
                    //if we did not find anybody
                    if (employeeToDelete == null)
                    {
                        //if employee not found
                        //show that employee does not exist.
                        //tell the user we could not find the employee
                        Console.WriteLine($"Sorry, we could not find {employeeName} in the list.");
                    }
                    else
                    {
                        //if found employee
                        //show details
                        Console.WriteLine($"Name found: {employeeToDelete.Name} in department {employeeToDelete.Department} with salary {employeeToDelete.Salary}");
                        //ask to confirm delete
                        Console.WriteLine($"Are you sure you want to delete {employeeToDelete.Name}?: (Y)es or (N)o");
                        //if no 
                        if (Console.ReadLine().ToUpper() == "N")
                        {
                            //do nothing
                            //return to menu
                            System.Console.WriteLine("Employee not deleted");
                        }
                        //if yes
                        else//this becomes a double negative and double negatives in languages are hard to keep track of
                        {
                            //remove the employee
                            employees.Remove(employeeToDelete);
                            Console.WriteLine($"We deleted {employeeToDelete.Name} from the list of employees.");
                        }
                    }


                }

                //READ - OUT OF CREATE READ UPDATE DELETE
                //show all employee
                else if (choice == "F")
                {
                    // Console.WriteLine("Find an employee.");
                    var nameToFind = PromptForString("What is the name of the employee you want to find? ");
                    //create a variable to hold the employee we find foundEmployee
                    // Employee foundEmployee = null;//explicitly declare the variable
                    Employee foundEmployee = employees.FirstOrDefault(employee => employee.Name == nameToFind);
                    //since we do not initialize the foundEmployee variable or set it equal to something, it is null
                    //Prompt for the name of the employee
                    // 
                    //Loop through the list of employees to look for a match
                    // foreach (var employee in employees)
                    // {
                    //     //if the name matches, set foundEmployee to that employee
                    //     if (employee.Name == nameToFind)
                    //     {
                    //         foundEmployee = employee;
                    //     }

                    // }
                    //After the loop, foundEmployee will either be null or have a value referring to the matching name
                    //If we found one, show the employee
                    //If we find one, update foundEmployee 
                    if (foundEmployee != null)
                    {
                        Console.WriteLine($"We found {foundEmployee.Name} in department {foundEmployee.Department} and makes ${foundEmployee.Salary}.");
                    }
                    //If we did not find one, show a message
                    else
                    {
                        Console.WriteLine($"Sorry, we could not find {nameToFind}.");
                    }
                    //Show a message if null, otherwise show the details about the foundEmployee
                }
                else if (choice == "S")
                {
                    //loop through each employee
                    foreach (var employee in employees)
                    {
                        Console.WriteLine("Show the employees");
                        Console.WriteLine($"{employee.Name} is in department {employee.Department} and makes ${employee.Salary}.");
                    }
                }
                //while the user has's quit yet
                else
                {
                    //CREATE - OUT OF CREATE READ UPDATE DELETE
                    //make the employee object
                    var employee = new Employee();

                    //we set the properties of the employee object
                    employee.Name = PromptForString("What is the name of the employee to enter?: ");
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
