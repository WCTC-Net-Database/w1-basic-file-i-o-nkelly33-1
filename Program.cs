class Program
{
    static void Main()
    {
       
        do
        {

            //Menu
            Console.WriteLine();
            Console.WriteLine("Choose an option:");
            Console.WriteLine("1. Display Characters");
            Console.WriteLine("2. Add Character");
            Console.WriteLine("3. Level Up Character");
            Console.WriteLine("4. Exit");
            Console.WriteLine();

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
            Console.WriteLine("------------------------");
        }
    }
    static void AddCharacter()
    {
        Console.Write("Enter the name of the character: ");
        string name = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Enter the level of the character: ");
        string level = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Enter the class of the character: ");
        string characterClass = Console.ReadLine();
        Console.WriteLine();
        Console.Write("Enter the health of the character: ");
        string health = Console.ReadLine();
        Console.WriteLine();
        string[] equipment;
        
        Console.WriteLine("Enter the equipment of the character (separated by |):");
        equipment = Console.ReadLine().Split('|');
        Console.WriteLine();

        Console.WriteLine($"Welcome, {name} the {characterClass}! You are level {level} and your equipment includes: {string.Join(", ", equipment)}.");

        // Write to input.csv
        using (StreamWriter writer = new StreamWriter("input.csv", true))
        {
            writer.WriteLine($"{name},{characterClass},{level},{health},{string.Join("|", equipment)}");
        }

    }
    static void LevelUpCharacter()
    {
        {
            var lines = File.ReadAllLines("input.csv");
            

            Console.Write("Enter the name of the character you want to level up: ");
            string name = Console.ReadLine();
            Console.Write("Enter the amount of levels you want to increase: ");
            int levels = int.Parse(Console.ReadLine());

            bool characterFound = false;

            for (int i = 0; i < lines.Length; i++)
            {
                var cols = lines[i].Split(",");
                if (cols[0].Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    int currentLevel = int.Parse(cols[2]);
                    cols[2] = (currentLevel + levels).ToString();
                    lines[i] = string.Join(",", cols);
                    characterFound = true;
                    break;
                }
            }

            if (characterFound)
            {
                using (StreamWriter writer = new StreamWriter("input.csv"))
                {
                    foreach (var line in lines)
                    {
                        writer.WriteLine(line);
                    }
                }
                Console.WriteLine($"{name} has been leveled up.");
            }
            else
            {
                Console.WriteLine("Character not found.");
            }




        }
    }
}