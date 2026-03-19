namespace Immersion;

public class WaveManager
{
    private Player _player;
    private CombatSystem _combat;
    private int _enemyNumber = 0;
    
    public WaveManager(Player player, CombatSystem combat)
    {
        _player = player;
        _combat = combat;
    }
    
    public void StartWave(Ui ui)
    {
        Console.Clear();
        ui.StartRunMessage();
        Console.ReadKey();
        Console.Clear();

        while (!_player.IsDead)
        {
            _enemyNumber++;
            Entity enemy = EnemyFactory.Spawn(_enemyNumber);
            
            if (_enemyNumber > 1)
                Console.WriteLine();
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Enemy #{_enemyNumber}: {enemy.Name} appears!");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(600);
            
            _combat.Fight(_player, enemy, ui);
            
            int baseCoins = enemy.GetBaseCoins() * (1 + (_enemyNumber / 10));
            int totalCoins = baseCoins * _player.Upgrade.CoinsBoost;
            _player.AddCoins(totalCoins);
            
            if (_enemyNumber % 10 == 0 && !_player.IsDead)
            {
                int healAmount = _player.Upgrade.HealBoost;
                _player.Heal(healAmount);
                Console.WriteLine($"\nAfter surviving 10 enemies, you healed for {healAmount} HP!");
                
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("\nYou feel yourself sinking deeper into the abyss...");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(800);
            }
        }
    }
    
    public void CheckHealth(Player player)
    {
        if (_enemyNumber % 10 == 0 && !_player.IsDead)
        {
            int healAmount = _player.Upgrade.HealBoost;
            _player.Heal(healAmount);

            Console.WriteLine($"\nAfter surviving 10 enemies, you healed for {healAmount} HP!");
            Thread.Sleep(700);
        }
    }
}