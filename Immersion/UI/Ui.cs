using System.Runtime.InteropServices;

namespace Immersion;

public class Ui : IUi
{
    public void WriteLine(string text) => Console.WriteLine(text);
    public void Write(string text) => Console.Write(text);
    public ConsoleKeyInfo ReadKey() => Console.ReadKey();

    public void ShowMenuUi()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("===== Immersion =====");
        Console.ForegroundColor = ConsoleColor.White;
        WriteLine("Select an action:");
        WriteLine("1. Start\n2. Improvements\n3. Bestiary\n0. Exit\n");
        Write("-> ");
    }

    public void ShowExitUi()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("===== Exit Menu =====");
        Console.ForegroundColor = ConsoleColor.White;
        WriteLine("Press any key to exit...");
        ReadKey();
    }
    
    public void ShowImprovementsMenuUi(Player player)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("===== Improvements =====");
            Console.ForegroundColor = ConsoleColor.White;
            WriteLine($"Coins: {player.Coins}");
            WriteLine($"1. Increase Max Health (+5)  | Cost: {player.Upgrade.HealthCost}   | Current Boost: {player.Upgrade.MaxHealthBoost}");
            WriteLine($"2. Increase Damage (+1)      | Cost: {player.Upgrade.DamageCost}   | Current Boost: {player.Upgrade.DamageBoost}");
            WriteLine($"3. Increase Heal Power (+3)  | Cost: {player.Upgrade.HealCost}    | Current Heal: {player.Upgrade.HealBoost}");
            WriteLine($"4. Increase Armor (+5)       | Cost: {player.Upgrade.ArmorCost}    | Current Armor: {player.Upgrade.ProtectBoost}");
            WriteLine($"5. Increase Coin Multiplier  | Cost: {player.Upgrade.CoinsCost}   | Current x{player.Upgrade.CoinsBoost}");
            WriteLine("0. Back to menu\n");
            Write("-> ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (player.SpendCoins(player.Upgrade.HealthCost))
                    {
                        player.Upgrade.IncreaseHealth(5);
                        WriteLine("Max health increased!");
                    }
                    else
                        WriteLine("Not enough coins!");
                    break;
                case "2":
                    if (player.SpendCoins(player.Upgrade.DamageCost))
                    {
                        player.Upgrade.IncreaseDamage(1);
                        WriteLine("Damage increased!");
                    }
                    else
                        WriteLine("Not enough coins!");
                    break;
                case "3":
                    if (player.SpendCoins(player.Upgrade.HealCost))
                    {
                        player.Upgrade.IncreaseHealPower(3);
                        WriteLine("Heal power increased!");
                    }
                    else
                        WriteLine("Not enough coins!");
                    break;
                case "4":
                    if (player.Upgrade.ProtectBoost >= GameConstants.MaxProtectBoost)
                        WriteLine("Armor is already at maximum!");
                    else if (player.SpendCoins(player.Upgrade.ArmorCost))
                    {
                        player.Upgrade.IncreaseProtect(5);
                        WriteLine("Armor increased!");
                    }
                    else
                        WriteLine("Not enough coins!");
                    break;
                case "5":
                    if (player.Upgrade.CoinsBoost >= GameConstants.MaxCoinsBoost)
                        WriteLine("Coins multiplier is already at maximum!");
                    else if (player.SpendCoins(player.Upgrade.CoinsCost))
                    {
                        player.Upgrade.IncreaseCoins();
                        WriteLine($"Coins multiplier increased! Current x{player.Upgrade.CoinsBoost}");
                    }
                    else
                        WriteLine("Not enough coins!");
                    break;
                case "0":
                    return;
            }

            WriteLine("Press any key to return...");
            ReadKey();
        }
    }
    
    public void ShowBestiaryMenuUi()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            WriteLine("===== Bestiary =====");
            Console.ForegroundColor = ConsoleColor.White;
            WriteLine("1. Blood Shark");
            WriteLine("2. Meat Squid");
            WriteLine("3. Terrifying barracuda");
            WriteLine("0. Back to menu\n");
            Write("-> ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    WriteLine("===== Blood Shark =====");
                    WriteLine("Its jaws never close, as if it already knows you are its next prey.");
                    break;
                case "2":
                    Console.Clear();
                    WriteLine("===== Meat Squid =====");
                    WriteLine("Its body seems crudely stitched together from pieces of flesh.");
                    WriteLine("Its tentacles reach for you, leaving trails of slime and blood.");
                    break;
                case "3":
                    Console.Clear();
                    WriteLine("===== Terrifying barracuda =====");
                    WriteLine("Its eyes are hollow, yet it still sees you.");
                    WriteLine("The water trembles as it draws closer.");
                    break;
                case "0":
                    return;
            }

            WriteLine("\nPress any key to return...");
            ReadKey();
        }
    }

    public void InvalidInputUi()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("===== Invalid Input! =====");
        Console.ForegroundColor = ConsoleColor.White;
        WriteLine("Press any key to exit to the menu...");
        ReadKey();
    }

    public void StartRunMessage()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("===== Immersion =====");
        Console.ForegroundColor = ConsoleColor.White;
        WriteLine("Here begins the path to death...");
        WriteLine("Press any key to start...");
        ReadKey();
        Console.Clear();
    }

    public void ShowPlayerDeath()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("╔════════════════════════════╗");
        WriteLine("║          YOU DEAD          ║");
        WriteLine("║      Maybe next time?      ║");
        WriteLine("╚════════════════════════════╝");
        Console.ForegroundColor = ConsoleColor.White;
        WriteLine("\nPress any key to exit to the menu...");
        ReadKey();
        Console.Clear();
    }
    
    public void ShowPlayerHealth(Player player)
    {
        WriteLine($"{player.Name} health: {player.Health}\n");
    }

    public void ShowPlayerAttack(Player player, Entity enemy, int damage, bool crit)
    {
        if (crit)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Write("Critical hit! ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        
        WriteLine($"{player.Name} attacks {enemy.Name} for {damage}");
    }
    
    public void ShowEnemySpawn(Entity enemy, int number)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        WriteLine($"Enemy #{number}: {enemy.Name} appears!");
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    public void ShowEnemyDeath(Entity enemy)
    {
        WriteLine($"{enemy.Name} is dead!");
    }

    public void ShowEnemyAttack(Entity enemy, int damage)
    {
        WriteLine($"{enemy.Name} attacks you for {damage}");
    }

    public void ShowEnemyHealth(Entity enemy)
    {
        WriteLine($"{enemy.Name} health: {enemy.Health}\n");
    }
    
    public void ShowCoinsEarned(int amount, int total)
    {
        WriteLine($"\nYou got {amount} coins! Total: {total}");
    }
    
    public void ShowEnemySeparator()
    {
        WriteLine("");
    }
    
    public void ShowHeal(int amount)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        WriteLine($"\nAfter surviving 10 enemies, you healed for {amount} HP!\n");
        Console.ForegroundColor = ConsoleColor.White;
    }
    
    public void ShowCreepMessage()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        WriteLine("You feel yourself sinking deeper into the abyss...\n");
        Console.ForegroundColor = ConsoleColor.White;
    }
}