namespace Immersion;

public class Ui
{
    public void ShowMenuUi()
    {
        Console.Clear();
        Console.WriteLine("===== Immersion =====");
        Console.WriteLine("\nSelect an action:");
        Console.WriteLine("1. Start\n2. Improvements\n3. Bestiary\n0. Exit\n");
        Console.Write("-> ");
    }

    public void ShowExitUi()
    {
        Console.Clear();
        Console.WriteLine("===== Press any key to exit... =====");
        Console.ReadKey();
    }

    public void InvalidInputUi()
    {
        Console.Clear();
        Console.WriteLine("===== Invalid input! =====");
        Console.WriteLine("Press any key to exit to the menu...");
        Console.ReadKey();
    }

    public void ShowPlayerDeathUi()
    {
        Console.WriteLine();
        Console.WriteLine("╔════════════════════════════╗");
        Console.WriteLine("║          YOU DEAD          ║");
        Console.WriteLine("║      Maybe next time?      ║");
        Console.WriteLine("╚════════════════════════════╝");
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
        Console.ReadKey();
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