namespace Immersion;

public class Game
{
    private readonly IUi _ui = new Ui();
    private readonly IInput _input = new ConsoleInput();
    private readonly IDelay _delay = new ThreadDelay();
    
    private readonly Player _player = new();
    private readonly CombatSystem _combat = new();
    private readonly WaveManager _wave = new();

    public void Start()
    {
        while (true)
        {
            _ui.ShowMenuUi();

            if (!int.TryParse(Console.ReadLine(), out int input) || !Enum.IsDefined(typeof(MenuAction), input))
            {
                _ui.InvalidInputUi();
                continue;
            }

            if ((MenuAction)input == MenuAction.Start)
                StartGame();
            else if ((MenuAction)input == MenuAction.Improvements)
                _ui.ShowImprovementsMenuUi(_player);
            else if ((MenuAction)input == MenuAction.Bestiary)
                _ui.ShowBestiaryMenuUi();
            else if ((MenuAction)input == MenuAction.Exit)
            {
                _ui.ShowExitUi();
                return;
            }
        }
    }

    private void StartGame()
    {
        _player.PlayerReset();
        _wave.Reset();
        
        _ui.StartRunMessage();

        while (!_player.IsDead)
        {
            var enemy = _wave.NextEnemy();
            
            if(_wave.EnemyNumber > 1)
                _ui.ShowEnemySeparator();
            
            _ui.ShowEnemySpawn(enemy, _wave.EnemyNumber);
            _delay.Wait(600);

            while (!enemy.IsDead && !_player.IsDead)
            {
                var playerHit = _combat.PlayerAttack(_player, enemy);
                _ui.ShowPlayerAttack(_player, enemy, playerHit.Damage, playerHit.IsCritical);
                if (enemy.Health > 0)
                    _ui.ShowEnemyHealth(enemy);

                if (playerHit.TargetDead)
                {
                    _ui.ShowEnemyDeath(enemy);
                    
                    int coins = EnemyCalculator.CalculateCoins(enemy, _wave.EnemyNumber, _player.Upgrade.CoinsBoost);
                    _player.AddCoins(coins);
                    _ui.ShowCoinsEarned(coins, _player.Coins);
                                    
                    if (_wave.ShouldHeal())
                    {
                        int heal = _player.Heal(_player.Upgrade.HealBoost);
                        _ui.ShowHeal(heal);
                        _wave.MarkHealed();
                    }

                    if (_wave.ShouldShowCreepMessage())
                    {
                        _ui.ShowCreepMessage();
                        _wave.MarkCreepMessageShown();
                    }
                    break;
                }
                
                _delay.Wait(350);
                
                var enemyHit = _combat.EnemyAttack(enemy, _player);
                _ui.ShowEnemyAttack(enemy, enemyHit.Damage);
                if (_player.Health > 0)
                    _ui.ShowPlayerHealth(_player);
                
                if (enemyHit.TargetDead)
                {
                    _delay.Wait(200);
                    _ui.ShowPlayerDeath();
                    Console.Clear();
                    break;
                }
                _delay.Wait(350);
            }
        }
    }
}