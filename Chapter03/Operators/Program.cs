using static System.Console;

bool a = true;
bool b = false;

WriteLine();
WriteLine($"a && DoStuff() = {a && DoStuff()}");
WriteLine($"b && DoStuff() = {b && DoStuff()}");

static bool DoStuff()
{
    Console.WriteLine("I am doing some shady stuff");
    return true;
}