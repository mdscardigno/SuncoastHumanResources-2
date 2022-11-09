namespace SuncoastHumanResources
{
    public class Employee
    {
        public string Name { get; set; }
        public int Department { get; set; }
        public int Salary { get; set; }
        public int MonthlySalary()
        {
            return Salary / 12;
        }

    }
    //Our employee is our MODEL
    //The thing that we are keeping track of
}