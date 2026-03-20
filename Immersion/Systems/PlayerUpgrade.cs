namespace Immersion;

public class PlayerUpgrade
{
    public int MaxHealthBoost { get; private set; } = 0;
    public int DamageBoost { get; private set; } = 0;
    public int HealBoost { get; private set; } = 3;
    public int ProtectBoost { get; private set; } = 0;
    public int CoinsBoost { get; private set; } = 1;
    
    public int HealthCost { get; set; } = 10;
    public int DamageCost { get; set; } = 5;
    public int HealCost { get; set; } = 5;
    public int ArmorCost { get; set; } = 5;
    public int CoinsCost { get; set; } = 20;
    
    public void IncreaseHealth(int amount)
    {
        MaxHealthBoost += amount;
        HealthCost *= 2;
    }

    public void IncreaseDamage(int amount)
    {
        DamageBoost += amount;
        DamageCost *= 2;
    }

    public void IncreaseHealPower(int amount)
    {
        HealBoost += amount;
        HealCost *= 2;
    }

    public void IncreaseProtect(int amount)
    {
        if (ProtectBoost >= GameConstants.MaxProtectBoost)
            return;
        ProtectBoost += amount;
        if (ProtectBoost > GameConstants.MaxProtectBoost)
            ProtectBoost = GameConstants.MaxProtectBoost;
        ArmorCost *= 2;
    }

    public void IncreaseCoins()
    {
        if (CoinsBoost >= GameConstants.MaxCoinsBoost)
            return;
        CoinsBoost++;
        CoinsCost *= 2;
    }
}