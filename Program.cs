class Program
{
    static void Main()
    {
       
        do
        {
            //Menu
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("4. Exit");

            string option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    DisplayCharacters();
                    break;
                case "2":
                    AddCharacter();
                    break;
                case "3":
                    LevelUpCharacter();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (true);

    }

    static void DisplayCharacters()
    {
        var lines = File.ReadAllLines("input.csv");

        for (int i = 0; i < lines.Length; i++)
        {
            var cols = lines[i].Split(",");

            var name = cols[0];
            var profession = cols[1];
            var level = cols[2];
            var hitPoints = cols[3];
            var equipment = cols[4];
            //var items = equipment.Split("|");

            Console.WriteLine($"Name: {name}");
            Console.WriteLine($"Job: {profession}");
            Console.WriteLine($"Level: {level}");
            Console.WriteLine($"Hit Points: {hitPoints}");
            Console.WriteLine($"Equipment: {equipment}");
        }
    }
    static void AddCharacter()
    {
        Console.WriteLine("Enter the name of the character:");
        string name = Console.ReadLine();
        Console.WriteLine("Enter the level of the character:");
        string level = Console.ReadLine();
        Console.WriteLine("Enter the class of the character:");
        string characterClass = Console.ReadLine();
        Console.WriteLine("Enter the health of the character:");
        string health = Console.ReadLine();
        string[] equipment;
        
        Console.WriteLine("Enter the equipment of the character (separated by |):");
        equipment = Console.ReadLine().Split('|');

        Console.WriteLine($"Welcome, {name} the {characterClass}! You are level {level} and your equipment includes: {string.Join(", ", equipment)}.");

    }
    static void LevelUpCharacter()
    {
        {
            var lines = File.ReadAllLines("input.csv");
            

            Console.Write("Enter the name of the character you want to level up: ");
            string name = Console.ReadLine();
            Console.Write("Enter the amount of levels you want to increase: ");
            int levels = int.Parse(Console.ReadLine());


            


        }
    }
}