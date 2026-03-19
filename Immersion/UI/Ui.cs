namespace Immersion;

public class Ui
{
    public void ShowMenuUi()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("===== Immersion =====");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Select an action:");
        Console.WriteLine("1. Start\n2. Improvements\n3. Bestiary\n0. Exit\n");
        Console.Write("-> ");
    }

    public void ShowExitUi()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("===== Exit Menu =====");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
    
    public void ShowImprovementsMenuUi(Player player)
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("===== Improvements =====");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Coins: {player.Coins}");
            Console.WriteLine($"1. Increase Max Health (+5)  | Cost: {player.Upgrade.HealthCost} | Current Boost: {player.Upgrade.MaxHealthBoost}");
            Console.WriteLine($"2. Increase Damage (+1)      | Cost: {player.Upgrade.DamageCost} | Current Boost: {player.Upgrade.DamageBoost}");
            Console.WriteLine($"3. Increase Heal Power (+1)  | Cost: {player.Upgrade.HealCost}  | Current Heal: {player.Upgrade.HealBoost}");
            Console.WriteLine($"4. Increase Armor (+5)       | Cost: {player.Upgrade.ArmorCost}  | Current Armor: {player.Upgrade.ArmorBoost}");
            Console.WriteLine($"5. Increase Coin Multiplier  | Cost: {player.Upgrade.CoinsCost} | Current x{player.Upgrade.CoinsBoost}");
            Console.WriteLine("0. Back to menu\n");
            Console.Write("-> ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    if (player.SpendCoins(player.Upgrade.HealthCost))
                    {
                        player.Upgrade.IncreaseHealth(5);
                        Console.WriteLine("Max health increased!");
                    }
                    else
                        Console.WriteLine("Not enough coins!");
                    break;
                case "2":
                    if (player.SpendCoins(player.Upgrade.DamageCost))
                    {
                        player.Upgrade.IncreaseDamage(1);
                        Console.WriteLine("Damage increased!");
                    }
                    else
                        Console.WriteLine("Not enough coins!");
                    break;
                case "3":
                    if (player.SpendCoins(player.Upgrade.HealCost))
                    {
                        player.Upgrade.IncreaseHealPower(1);
                        Console.WriteLine("Heal power increased!");
                    }
                    else
                        Console.WriteLine("Not enough coins!");
                    break;
                case "4":
                    if (player.Upgrade.ArmorBoost >= 75)
                        Console.WriteLine("Armor is already at maximum!");
                    else if (player.SpendCoins(player.Upgrade.ArmorCost))
                    {
                        player.Upgrade.IncreaseArmor(5);
                        Console.WriteLine("Armor increased!");
                    }
                    else
                        Console.WriteLine("Not enough coins!");
                    break;
                case "5":
                    if (player.Upgrade.CoinsBoost >= 5)
                        Console.WriteLine("Coins multiplier is already at maximum!");
                    else if (player.SpendCoins(player.Upgrade.CoinsCost))
                    {
                        player.Upgrade.IncreaseCoins();
                        Console.WriteLine($"Coins multiplier increased! Current x{player.Upgrade.CoinsBoost}");
                    }
                    else
                        Console.WriteLine("Not enough coins!");
                    break;
                case "0":
                    return;
            }

            Console.WriteLine("Press any key to return...");
            Console.ReadKey();
        }
    }
    
    public void ShowBestiaryMenuUi()
    {
        while (true)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("===== Bestiary =====");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("1. Blood Shark");
            Console.WriteLine("2. Meat Squid");
            Console.WriteLine("3. Terrifying barracuda");
            Console.WriteLine("0. Back to menu\n");
            Console.Write("-> ");

            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("===== Blood Shark =====");
                    Console.WriteLine("Its jaws never close, as if it already knows you are its next prey.");
                    break;
                case "2":
                    Console.Clear();
                    Console.WriteLine("===== Meat Squid =====");
                    Console.WriteLine("Its body seems crudely stitched together from pieces of flesh.");
                    Console.WriteLine("Its tentacles reach for you, leaving trails of slime and blood.");
                    break;
                case "3":
                    Console.Clear();
                    Console.WriteLine("===== Terrifying barracuda =====");
                    Console.WriteLine("Its eyes are hollow, yet it still sees you.");
                    Console.WriteLine("The water trembles as it draws closer.");
                    break;
                case "0":
                    return;
            }

            Console.WriteLine("\nPress any key to return...");
            Console.ReadKey();
        }
    }

    public void InvalidInputUi()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("===== Invalid Input! =====");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Press any key to exit to the menu...");
        Console.ReadKey();
    }

    public void StartRunMessage()
    {
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("===== Immersion =====");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("Here begins the path to death...");
        Console.WriteLine("Press any key to start...");
    }

    public void ShowPlayerDeathUi()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkRed;
        Console.WriteLine("╔════════════════════════════╗");
        Console.WriteLine("║          YOU DEAD          ║");
        Console.WriteLine("║      Maybe next time?      ║");
        Console.WriteLine("╚════════════════════════════╝");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("\nPress any key to exit to the menu...");
        Console.ReadKey();
    }
    
    public void ShowPlayerAttackUi(Player player, Entity entity)
    {
        Console.WriteLine($"{player.Name} attack {entity.Name} for {player.Damage} damage!");
    }
    
    public void ShowPlayerHealthUi(Player player)
    {
        Console.WriteLine($"{player.Name} health: {player.Health}");
    }

    public void ShowEnemyDeathUi(Entity entity)
    {
        Console.WriteLine($"{entity.Name} is dead!");
    }
    
    public void ShowEnemyAttackUi(Entity entity)
    {
        Console.WriteLine($"{entity.Name} attack you for {entity.Damage} damage!");
    }
    
    public void ShowEnemyHealthUi(Entity entity)
    {
        Console.WriteLine($"{entity.Name} health: {entity.Health}");
    }
}