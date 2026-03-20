namespace Immersion;

public class EnemyCalculator
{
    public static void ApplyBoost(Entity enemy, int enemyNumber)
    {
        int boost = (enemyNumber / 10) * 2;
        enemy.Health += boost;
        enemy.Damage += boost;
    }
    
    public static int CalculateCoins(Entity enemy, int enemyNumber, int coinsBoost)
    {
        int baseCoins = enemy.GetBaseCoins() + (enemyNumber / 10);
        return baseCoins * coinsBoost;
    }
}