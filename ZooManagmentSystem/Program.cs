using System;
using System.Collections.Generic;

// enum for AnimalTypes
public enum AnimalType
{
    Mammal,
    Bird,
    Reptile
}
//enum for FoodTypes

public enum FoodType
{
    Meat,
    Vegetation,
    Mixed
}
//enum for HabitatType

public enum HabitatType
{
    Desert,
    Forest,
    Aquatic
}

//  DietInfo
public struct DietInfo
{
    public FoodType FoodType;
    public string FeedingSchedule;

    // Constructor for DietInfo
    public DietInfo(FoodType foodType, string feedingSchedule)
    {
        FoodType = foodType;
        FeedingSchedule = feedingSchedule;
    }
}

//  class Animal
public abstract class Animal
{
   
    public string Name { get; protected set; }
    public int Age { get; protected set; }
    public AnimalType Type { get; protected set; }
    public HabitatType Habitat { get; protected set; }
    public DietInfo Diet { get; set; } 

    
    public abstract void Eat();
    public abstract void Move();
    public abstract void Speak();
}
public interface IClimbable
{
    void Climb();
}

public interface ISwimmable
{
    void Swim();
}

public interface IFlyable
{
    void Fly();
}

//Lion inheriting from Animal
public class Lion : Animal, IClimbable
{
    // Constructor for Lion
    public Lion(string name, int age, HabitatType habitat, DietInfo diet)
    {
        Name = name;
        Age = age;
        Type = AnimalType.Mammal;
        Habitat = habitat;
        Diet = diet;
    }

    
    public override void Eat()
    {
        Console.WriteLine($"{Name} eats {Diet.FoodType} according to the feeding schedule: {Diet.FeedingSchedule}");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} roams in the {Habitat.ToString().ToLower()} habitat.");
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} roars loudly.");
    }

    public void Climb()
    {
        Console.WriteLine($"{Name} climbs the rock.");
    }
}

public class Penguin : Animal, ISwimmable
{
    // Constructor for Penguin
    public Penguin(string name, int age, HabitatType habitat, DietInfo diet)
    {
        Name = name;
        Age = age;
        Type = AnimalType.Bird;
        Habitat = habitat;
        Diet = diet;
    }

    public override void Eat()
    {
        Console.WriteLine($"{Name} eats {Diet.FoodType} according to the feeding schedule: {Diet.FeedingSchedule}");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} waddles on the icy terrain.");
    }

    public override void Speak()
    {
        Console.WriteLine($"{Name} squawks quietly.");
    }

    public void Swim()
    {
        Console.WriteLine($"{Name} swims gracefully.");
    }
}

// Main class
class Program
{
    // Main method
    static void Main(string[] args)
    {
        try
        {
         
            List<Animal> zoo = new List<Animal>();

            zoo.Add(new Lion("Simba", 5, HabitatType.Forest, new DietInfo(FoodType.Meat, "Twice a day")));
            zoo.Add(new Penguin("Pingu", 3, HabitatType.Aquatic, new DietInfo(FoodType.Mixed, "Three times a day")));

           
            zoo.Add(new Lion("Katliey", 4, HabitatType.Forest, new DietInfo(FoodType.Meat, "Twice a day")));
            zoo.Add(new Penguin("pengu", 2, HabitatType.Aquatic, new DietInfo(FoodType.Mixed, "Three times a day")));
            zoo.Add(new Lion("Scar", 8, HabitatType.Desert, new DietInfo(FoodType.Meat, "Once a day")));
            zoo.Add(new Penguin("Waddle", 1, HabitatType.Aquatic, new DietInfo(FoodType.Mixed, "Four times a day")));
            zoo.Add(new Lion("Mufasa", 10, HabitatType.Forest, new DietInfo(FoodType.Meat, "Once a day")));

         
            bool continueInteracting = true;

            
            while (continueInteracting)
            {
                // Display the menu
                Console.WriteLine("Welcome to Zoo Management Menu:");
                Console.WriteLine("1. View animals in the zoo");
                Console.WriteLine("2. Feed an animal");
                Console.WriteLine("3. Make an animal move");
                Console.WriteLine("4. Make an animal speak");
                Console.WriteLine("5. Exit");

               
                Console.WriteLine("Please enter your choice (1-5):");
                string choice = Console.ReadLine();

                
                switch (choice)
                {
                    case "1":
                        DisplayAnimals(zoo);
                        break;
                    case "2":
                        FeedAnimal(zoo);
                        break;
                    case "3":
                        MakeAnimalMove(zoo);
                        break;
                    case "4":
                        MakeAnimalSpeak(zoo);
                        break;
                    case "5":
                        continueInteracting = false;
                        Console.WriteLine("Exiting the Zoo Management System. Have a nice day!");
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }

    // Method to feed an animal
    static void FeedAnimal(List<Animal> zoo)
    {
        Console.WriteLine("Which animal would you like to feed?");
        for (int i = 0; i < zoo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {zoo[i].Name}");
        }

        
        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= zoo.Count)
        {
            // Display food options
            Console.WriteLine("What type of food would you like to feed the animal?");
            Console.WriteLine("1. Meat");
            Console.WriteLine("2. Vegetable");
            Console.WriteLine("3. Both Meat and Vegetable");
            Console.WriteLine("Please enter your choice (1-3):");
            string foodChoice = Console.ReadLine();

            
            switch (foodChoice)
            {
                case "1":
                    zoo[choice - 1].Diet = new DietInfo(FoodType.Meat, zoo[choice - 1].Diet.FeedingSchedule);
                    break;
                case "2":
                    zoo[choice - 1].Diet = new DietInfo(FoodType.Vegetation, zoo[choice - 1].Diet.FeedingSchedule);
                    break;
                case "3":
                    zoo[choice - 1].Diet = new DietInfo(FoodType.Mixed, zoo[choice - 1].Diet.FeedingSchedule);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Using the default food type.");
                    break;
            }

            
            zoo[choice - 1].Eat();
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter a number corresponding to an animal.");
        }
    }

 
    static void MakeAnimalMove(List<Animal> zoo)
    {
        Console.WriteLine("Which animal would you like to make move?");
        for (int i = 0; i < zoo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {zoo[i].Name}");
        }

        
        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= zoo.Count)
        {
           
            zoo[choice - 1].Move();
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter a number corresponding to an animal.");
        }
    }

    //  animal speak
    static void MakeAnimalSpeak(List<Animal> zoo)
    {
        
        Console.WriteLine("Which animal would you like to make speak?");
        for (int i = 0; i < zoo.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {zoo[i].Name}");
        }

        
        int choice;
        if (int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= zoo.Count)
        {
            
            zoo[choice - 1].Speak();
        }
        else
        {
            Console.WriteLine("Invalid choice. Please enter a number corresponding to an animal.");
        }
    }

    // Method to display animals in the zoo
    static void DisplayAnimals(List<Animal> zoo)
    {
        Console.WriteLine("Animals in the zoo:");
        foreach (var animal in zoo)
        {
            Console.WriteLine($"{animal.Name}, {animal.Age} years old, Type: {animal.Type}, Habitat: {animal.Habitat}");
        }
    }
}
