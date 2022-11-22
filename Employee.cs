namespace SuncoastHumanResources
{
    public class Employee
    {
        public string Name { get; set; }
        public int Department { get; set; }
        public int Salary { get; set; }
        //it is not going to write out any of the behaviors because the behavior is shared amongst all employees. It is just going to write out the properties.
        //the only thing specific to an employee is the name, department and salary.
        //behavior is shared and state is individual to instances of employees in our list or instances of them in our file.
        public int MonthlySalary()
        {
            return Salary / 12;
        }

    }
    //Our employee is our MODEL
    //The thing that we are keeping track of
}