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
            // var employees = new List<Employee>();
            var database = new EmployeeDB();

            //Should we show the menu?
            var keepShowingTheMenu = true;

            while (keepShowingTheMenu)
            {
                //MENU
                //insert a blank line then prompt them and get their answer (force to upper case)
                Console.WriteLine();
                Console.Write("What do you want to do?\n (A)dd and employee\n (S)how all the employees\n (F)ind and employee\n (D)elete\n (U)pdate\n or (Q)uit?\n ");

                var choice = Console.ReadLine().ToUpper();

                switch (choice)
                {
                    case "Q":
                        keepShowingTheMenu = false;
                        System.Console.WriteLine("Thank you for using Suncoast Human Resources DB. Goodbye!");
                        break;
                    case "D":
                        DeleteEmployee(database);
                        break;
                    case "F":
                        FindEmployee(database);
                        break;
                    case "S":
                        ShowAllEmployees(database);
                        break;
                    case "U":
                        UpdateEmployee(database);
                        break;
                    case "A":
                        AddEmployee(database);
                        break;
                    default:
                        Console.WriteLine("Sorry, that is not a valid input.");
                        break;
                }
            }//end of while loop
        }

        private static void DeleteEmployee(EmployeeDB database)
        {
            //small algo
            //search the database for the employee
            //prompt for the employee name
            var employeeName = PromptForString("What is the employee name you are looking for? ");
            //find the employee
            var employeeToDelete = database.FindOneEmployee(employeeName);
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
                    database.DeleteEmployee(employeeName);
                    Console.WriteLine($"We deleted {employeeToDelete.Name} from the list of employees.");
                }
            }
        }

        private static void FindEmployee(EmployeeDB database)
        {
            // Console.WriteLine("Find an employee.");
            var nameToFind = PromptForString("What is the name of the employee you want to find? ");
            //create a variable to hold the employee we find foundEmployee
            // Employee foundEmployee = null;//explicitly declare the variable
            Employee foundEmployee = database.FindOneEmployee(nameToFind);
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

        private static void UpdateEmployee(EmployeeDB database)
        {
            System.Console.WriteLine("Updating employee");
            //prompt for the name of the employee
            var nameToUpdate = PromptForString("What is the name of the employee you want to update? ");
            //search the database for the employee
            Employee foundEmployee = database.FindOneEmployee(nameToUpdate);
            //if we find the employee
            if (foundEmployee == null)
            {
                Console.WriteLine($"Sorry, no such employee with the name of {nameToUpdate}.");
            }
            else
            {
                //confirm that we found the employee
                Console.WriteLine($"We found {foundEmployee.Name} in department {foundEmployee.Department} and makes ${foundEmployee.Salary}.");
                //prompt user for what change they want to make?
                Console.WriteLine("What do you want to change?\n (N)ame\n (D)epartment\n (S)alary\n ");
                //get the user's choice of change to employee
                var change = Console.ReadLine().ToUpper();
                //--if name
                //----prompt for new name
                if (change == "N")
                {
                    //prompt for new name
                    var newName = PromptForString("What is the new name? ");
                    //update the name
                    foundEmployee.Name = newName;
                    //show the new name
                    Console.WriteLine($"The new name is now: {foundEmployee.Name}.");
                }
                //--if department
                else if (change == "D")
                {
                    //prompt for new department
                    var newDepartment = PromptForString("What is the new department? ");
                    //update the department
                    foundEmployee.Department = int.Parse(newDepartment);
                    //show the new department
                    Console.WriteLine($"The new department for {foundEmployee.Name} is {foundEmployee.Department}.");
                }
                //--if salary
                else if (change == "S")
                {
                    //prompt for new salary
                    var newSalary = PromptForInteger($"What is the new salary for {foundEmployee.Name}?: ");
                    //update the salary
                    foundEmployee.Salary = newSalary;
                    //show the new salary
                    Console.WriteLine($"The new salary for {foundEmployee.Name} is {foundEmployee.Salary}.");
                }
                else
                {//if we don't find the employee
                 //----tell the user we could not find the employee
                    Console.WriteLine("Sorry, that is not a valid choice.");
                }
            }
        }

        private static void AddEmployee(EmployeeDB database)
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
            database.AddEmployee(employee);
        }

        private static void ShowAllEmployees(EmployeeDB database)
        {
            //READ (out of CREATE - READ - UPDATE - DELETE)
            foreach (var employee in database.GetAllEmployees())
            {
                //show the details of each employee
                Console.WriteLine($"Name: {employee.Name} Department: {employee.Department} Salary: {employee.Salary}");
            }
        }
    }
}
