class Vehicle
{
    public virtual void Start() => Console.WriteLine("Vehicle Start");
}

class Car : Vehicle
{
    public void  Go() => Console.WriteLine("Car Go");
}
class Bike : Vehicle
{
    public void Ride() => Console.WriteLine("Bike ride");
}