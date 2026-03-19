namespace Immersion;

public class UI
{
    public void ShowMenuUI()
    {
        Console.Clear();
        Console.WriteLine("===== Immersion =====");
        Console.WriteLine("\nSelect an action:");
        Console.WriteLine("1. Start\n2. Improvements\n3. Bestiary\n0. Exit\n");
        Console.Write("-> ");
    }

    public void ShowExitUI()
    {
        Console.Clear();
        Console.WriteLine("===== Press any key to exit... =====");
        Console.ReadKey();
    }

    public void InvalidInputUI()
    {
        Console.Clear();
        Console.WriteLine("===== Invalid input! =====");
        Console.WriteLine("Press any key to exit to the menu...");
        Console.ReadKey();
    }

    public void ShowPlayerDeathUI()
    {
        Console.WriteLine();
        Console.WriteLine("╔════════════════════════════╗");
        Console.WriteLine("║          YOU DEAD          ║");
        Console.WriteLine("║      Maybe next time?      ║");
        Console.WriteLine("╚════════════════════════════╝");
        Console.ReadKey();
    }
    
    public void ShowPlayerAttackUI(Player player, Entity entity)
    {
        Console.WriteLine($"{player.Name} attack {entity.Name} for {player.Damage} damage!");
    }
    
    public void ShowPlayerHealthUI(Player player)
    {
        Console.WriteLine($"{player.Name} health: {player.Health}");
    }

    public void ShowEnemyDeathUI(Entity entity)
    {
        Console.WriteLine($"{entity.Name} is dead!");
        Console.ReadKey();
    }
    
    public void ShowEnemyAttackUI(Entity entity)
    {
        Console.WriteLine($"{entity.Name} attack you for {entity.Damage} damage!");
    }
    
    public void ShowEnemyHealthUI(Entity entity)
    {
        Console.WriteLine($"{entity.Name} health: {entity.Health}");
    }
}