namespace Immersion;

public class Game
{
    private int _userInput;
    private UI _ui =  new UI();
    private CombatSystem _combat = new CombatSystem();

    public void Start()
    {
        while (true)
        {
            _ui.ShowMenuUI();
            
            while (true)
            {
                _ui.ShowMenuUI();
                
                if (!int.TryParse(Console.ReadLine(), out _userInput))
                {
                    _ui.InvalidInputUI();
                    continue;
                }

                if (_userInput < 0 || _userInput > 3)
                {
                    _ui.InvalidInputUI();
                    continue;
                }

                break;
            }

            if (_userInput == 1)
            {
                StartGame();
            }
            else if (_userInput == 0)
            {
                _ui.ShowExitUI();
                break;
            }
        }
    }

    private void StartGame()
    {
        var player = new Player();
        var enemy = new BloodShark();
        
        _combat.Fight(player, enemy, _ui);
    }
}