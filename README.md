# SuncoastHumanResources

//Ask for the name of an employee
var name = PromptForString("What name are you looking for?");

//Make a new variable to store the found employee, initializing to null which will indicate no match found

//If the foundEmployee is still null, nothing was found
if(foundEmployee == null){
Console.WriteLine("Nothing found.");
}else{
//Otherwise print the details of the found employee
Console.WriteLine($"{foundEmployee.Name} is in department {foundEmployee.Department} and makes {foundEmployee.Salary}.");
}
