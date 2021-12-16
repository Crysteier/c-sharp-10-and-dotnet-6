using static System.Console;
using PacktLibrary;

int thisCannotBeNull = 4;
//thisCannotBeNull = null;

int? thisCouldBeNull = null;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

thisCouldBeNull = 7;
WriteLine(thisCouldBeNull);
WriteLine(thisCouldBeNull.GetValueOrDefault());

Address address = new();
address.Building = null;
//address.Street = null;
address.City = "London";
//address.Region = null;  //will not work

Employee john = new()
{
    Name = "John Jones",
    DateOfBirth = new(year: 1990, month: 7, day: 28)
};
john.WriteToConsole();

john.EmployeeCode = "JJ001";
john.HireDate = new(year: 2014, month: 11, day: 23);
WriteLine($"{john.Name} was hired on {john.HireDate:dd/MM/yyyy}");

WriteLine(john.ToString());

Employee aliceInEmployee = new()
{ Name = "Alice", EmployeeCode = "AA123" };
Person aliceInPerson = aliceInEmployee;
aliceInEmployee.WriteToConsole();
aliceInPerson.WriteToConsole();
WriteLine(aliceInEmployee.ToString());
WriteLine(aliceInPerson.ToString());

Employee? aliceAsEmployee = aliceInPerson as Employee; // could be null
if (aliceAsEmployee != null)
{
    WriteLine($"{nameof(aliceInPerson)} AS an Employee");
    // safely do something with aliceAsEmployee
}

try
{
    john.TimeTravel(when: new(1999, 12, 31));
    john.TimeTravel(when: new(1920, 12, 31));
}
catch(PersonException ex)
{
    WriteLine(ex.Message);
}

string email1 = "pamela@test.com";
string email2 = "ian&test.com";
WriteLine("{0} is a valid e-mail address: {1}",
 arg0: email1,
 arg1: StringExtensions.IsValidEmail(email1));
WriteLine("{0} is a valid e-mail address: {1}",
 arg0: email2,
 arg1: StringExtensions.IsValidEmail(email2));

WriteLine("{0} is a valid e-mail address: {1}",
 arg0: email1,
 arg1: email1.IsValidEmail());
WriteLine("{0} is a valid e-mail address: {1}",
 arg0: email2,
 arg1: email2.IsValidEmail());

class Address
{
    public string? Building;
    public string Street =string.Empty;
    public string City =string.Empty;
    public string Region=string.Empty;
}

