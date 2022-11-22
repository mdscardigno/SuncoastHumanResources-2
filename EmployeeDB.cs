using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;

namespace SuncoastHumanResources
{
    class EmployeeDB
    {
        //THIS BRIDGED THE MODEL AND THE CONTROLLER PARTS OF THE MVC
        //API
        //Move our List<Employee> inside.
        //Make this class property private.
        private List<Employee> Employees { get; set; } = new List<Employee>();

        private string FileName = "employees.csv";

        //Method to load Employees (does not return anything. Just populates Employees lists.) 
        public void LoadEmployees()
        {
            if (File.Exists(FileName))
            {
                var fileReader = new StreamReader(FileName);
                var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
                //replaces our list of employees with the list of employees that we read from the csv file.
                Employees = csvReader.GetRecords<Employee>().ToList();
                //in this case we do not have to configure the csvReader to ignore the header because I want the headers 
                //there because we are going to use that header to know in what order to read the various properties.
                fileReader.Close();
            }
        }


        //Write the list Employee to a file.
        public void SaveEmployees()
        {
            var fileWriter = new StreamWriter(FileName);
            var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            csvWriter.WriteRecords(Employees);//csv is smart enough to know that we are writing a list of employees objects
            fileWriter.Close();
        }
        //Develop public methods to perform common actions we need:
        //GetAllEmployees. FindOneEmployee. AddEmployee. UpdateEmployee. DeleteEmployee.
        //CREATE Add Employee
        //BEHAVIOR
        public void AddEmployee(Employee newEmployee)
        {
            Employees.Add(newEmployee);
        }
        //READ
        //BEHAVIOR
        public List<Employee> GetAllEmployees()
        {
            return Employees;
        }

        //READ
        //We created this API that says: If you send me a name, and you call FindOneEmployee, I will FindOneEmployee and return it. 
        //separating code based on area of concern is decoupling.
        //We don't want interface code, searching code, prompting code, list code and data code all in one place.
        public Employee FindOneEmployee(string nameToFind)
        {
            //In one place I declared how I find employees. 
            Employee foundEmployee = Employees.FirstOrDefault(employee => employee.Name.ToUpper().Contains(nameToFind.ToUpper()));
            return foundEmployee;
        }

        //DELETE
        public void DeleteEmployee(string employeeToDelete)
        {
            Employee foundEmployee = FindOneEmployee(employeeToDelete);
            Employees.Remove(foundEmployee);

        }

        //UPDATE


        //Methods receive data it needs and returns the data it provides.
        //These methods essentially create an API or Application Programming Interface for how to use this code.
    }
}