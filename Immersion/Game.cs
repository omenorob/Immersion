namespace Immersion;

public class Game
{
    private int _userInput;
    private Ui _ui =  new Ui();
    private CombatSystem _combat = new CombatSystem();

    public void Start()
    {
        while (true)
        {
            _ui.ShowMenuUi();
            
            while (true)
            {
                _ui.ShowMenuUi();
                
                if (!int.TryParse(Console.ReadLine(), out _userInput))
                {
                    _ui.InvalidInputUi();
                    continue;
                }

                if (_userInput < 0 || _userInput > 3)
                {
                    _ui.InvalidInputUi();
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
                _ui.ShowExitUi();
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