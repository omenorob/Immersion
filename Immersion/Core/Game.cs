namespace Immersion;

public class Game
{
    private MenuAction _userChoice;
    private Ui _ui =  new Ui();
    private Player _player = new Player();

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
            
            _userChoice = (MenuAction)input;

            switch (_userChoice)
            {
                case MenuAction.Start:
                    StartGame();
                    break;
                case MenuAction.Improvements:
                    _ui.ShowImprovementsMenuUi(_player);
                    break;
                case MenuAction.Bestiary:
                    _ui.ShowBestiaryMenuUi();
                    break;
                case MenuAction.Exit:
                    _ui.ShowExitUi();
                    return;
            }
        }
    }

    private void StartGame()
    {
        _player.PlayerReset();
        
        CombatSystem combat = new CombatSystem();
        WaveManager waveManager = new WaveManager(_player, combat);
        
        waveManager.StartWave(_ui);
    }
}