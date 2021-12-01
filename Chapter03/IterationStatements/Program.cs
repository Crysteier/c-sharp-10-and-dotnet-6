using static System.Console;

string? password;
do
{
    Write("Enter your password: ");
    password = ReadLine();
}
while (password != "Pa$$w0rd");
WriteLine("Correct!");

//like I will not do this whole section, I know how to use for and while my god