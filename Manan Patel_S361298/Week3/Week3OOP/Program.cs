// See https://aka.ms/new-console-template for more information

abstract class Animal
{
    // abstract method

    public abstract void animalSound();
    
    // Normal Method

    public void sleep()
    {
        Console.WriteLine("ZZZZZZ");
    }
}

class Cow : Animal
{
    public override void animalSound()
    {
        Console.WriteLine("The COW sounds");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Cow cow = new Cow();
        cow.animalSound();
        cow.sleep();
    }
}