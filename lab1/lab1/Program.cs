const int requireAge = 18;
const string accesDeniedMessage ="you must be at least 18 years old";
const string accesAllowedMesage ="Welcome";

int age =18;
Console.WriteLine("write your age");
string input =Console.ReadLine();
bool success = int.TryParse(input,out age);
do
{
    if (!success)
    {
        Console.WriteLine("write a number");
    }
    else
    {
        if (age < requireAge)
        {
            Console.WriteLine(accesDeniedMessage);
        }
        else if (age >= requireAge)
        {
            Console.WriteLine(accesAllowedMesage);
        }
    }
}while(age >= requireAge);
        