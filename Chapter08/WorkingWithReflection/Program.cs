using System.Reflection;
using static System.Console;
using System.Runtime.CompilerServices; // CompilerGeneratedAttribute
using System.Globalization;


WriteLine("Assembly metadata:");
Assembly? assembly = Assembly.GetEntryAssembly();
if (assembly is null)
{
    WriteLine("Failed to get entry assembly.");
    return;
}
WriteLine($" Full name: {assembly.FullName}");
WriteLine($" Location: {assembly.Location}");
IEnumerable<Attribute> attributes = assembly.GetCustomAttributes();
WriteLine($" Assembly-level attributes:");
foreach (Attribute a in attributes)
{
    WriteLine($" {a.GetType()}");
}
AssemblyInformationalVersionAttribute? version = assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
WriteLine($" Version: {version?.InformationalVersion}");
AssemblyCompanyAttribute? company = assembly.GetCustomAttribute<AssemblyCompanyAttribute>();
WriteLine($" Company: {company?.Company}");

CultureInfo globalization = CultureInfo.CurrentCulture;
CultureInfo localization = CultureInfo.CurrentUICulture;
WriteLine("The current globalization culture is {0}: {1}", globalization.Name, globalization.DisplayName);
WriteLine("The current localization culture is {0}: {1}", localization.Name, localization.DisplayName);
WriteLine();
WriteLine("en-US: English (United States)");
WriteLine("da-DK: Danish (Denmark)");
WriteLine("fr-CA: French (Canada)");
Write("Enter an ISO culture code: ");
string? newCulture = ReadLine();
if (!string.IsNullOrEmpty(newCulture))
{
    CultureInfo ci = new(newCulture);
    // change the current cultures
    CultureInfo.CurrentCulture = ci;
    CultureInfo.CurrentUICulture = ci;
}
WriteLine();
Write("Enter your name: ");
string? name = ReadLine();
Write("Enter your date of birth: ");
string? dob = ReadLine();
Write("Enter your salary: ");
string? salary = ReadLine();
DateTime date = DateTime.Parse(dob);
int minutes = (int)DateTime.Today.Subtract(date).TotalMinutes;
decimal earns = decimal.Parse(salary);
WriteLine(
 "{0} was born on a {1:dddd}, is {2:N0} minutes old, and earns {3:C}",
 name, date, minutes, earns);