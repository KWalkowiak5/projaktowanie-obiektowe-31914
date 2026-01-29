
//  1
/*const string greeting = "Hello";
int age;
string firstName = "Artur";
age = 31;
firstName = "Jan";
string message = $"{greeting} {firstName}. You are {age} years old. ";
Console.WriteLine(message);*/

//  2
/*const int simRequiredAge = 16; 
const int requiredAge = 14;
const int beerRequiredAge = 18;
const string accesDeniedMessage = "You must be at least 14 years.";
const string accesAllowedMessage = "Welcome to my shop.";
const string beerRestrictionMessage = "You must be 18 years old to buy a beer.";
const string simRestrictionMessage = "You must be 16 years old to buy a SIM card.";


int age = 14;

if (age >= beerRequiredAge)
{
    Console.WriteLine(accesAllowedMessage);
}
else if (age >= simRequiredAge)
{
    Console.WriteLine($"{accesAllowedMessage} {beerRestrictionMessage}");
}
else if (age >= requiredAge)
{
    Console.WriteLine($"{accesAllowedMessage } {beerRestrictionMessage} {simRestrictionMessage}");
}
else
{
    Console.WriteLine(accesDeniedMessage); 
}*/

//  3
string[] names = {"Artur", "Jan", "Agata", "Alicja", "Bartosz"};
string[] names2 = new string[5];
names2[0] = "Artur";
names2[1] = "Jan";
names2[2] = "Agata";
names2[3] = "Alicja";
names2[4] = "Bartosz";
string[] names3 = new string[] {"Artur", "Jan", "Agata", "Alicja", "Bartosz"};

Console.WriteLine("Names:");
//Console.WriteLine(names[0]);
//Console.WriteLine(names[1]);
//Console.WriteLine(names[2]);
//Console.WriteLine(names[3]);
//Console.WriteLine(names[4]);
for (int i = 0; i < names.Length; i++)
{
    Console.WriteLine(names[i]);
}

