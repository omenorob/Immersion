namespace Immersion;

public interface IUi
{
    void WriteLine(string text);
    void Write(string text);
    ConsoleKeyInfo ReadKey();

    void ShowMenuUi();
    void ShowExitUi();
    void ShowImprovementsMenuUi(Player player);
    void ShowBestiaryMenuUi();
    void InvalidInputUi();
    void StartRunMessage();
    
    void ShowPlayerAttack(Player player, Entity enemy, int damage, bool crit);
    void ShowEnemyAttack(Entity enemy, int damage);
    void ShowPlayerHealth(Player player);
    void ShowEnemyHealth(Entity enemy);
    void ShowPlayerDeath();
    void ShowEnemyDeath(Entity enemy);

    void ShowEnemySpawn(Entity enemy, int number);
    void ShowCoinsEarned(int amount, int total);
    void ShowEnemySeparator();
    void ShowHeal(int amount);
    void ShowCreepMessage();
}