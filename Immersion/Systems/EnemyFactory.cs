namespace Immersion;

public static class EnemyFactory
{
    private static Random _rnd = new Random();

    public static Entity Spawn(int enemyNumber)
    {
        Entity enemy;

        if (enemyNumber < 20)
        {
            if (_rnd.Next(0, 2) == 0)
                enemy = new BloodShark();
            else
                enemy = new MeatSquid();
        }
        else
        {
            int roll = _rnd.Next(0, 3);
            
            if (roll == 0)
                enemy = new BloodShark();
            else if (roll == 1)
                enemy = new MeatSquid();
            else
                enemy = new TerrifyingBarracuda();
        }

        int boost = (enemyNumber / 10) * 2;
        enemy.Health += boost;
        enemy.Damage += boost;
        
        return enemy;
    }
}