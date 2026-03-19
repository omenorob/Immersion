namespace Immersion;

public class PlayerUpgrade
{
    public int MaxHealthBoost { get; private set; } = 0;
    public int  DamageBoost { get; private set; } = 0;
    public int HealPower { get; private set; } = 5;
    
    public void IncreaseHealth(int amount) => MaxHealthBoost += amount;
    public void IncreaseDamage(int amount) => DamageBoost += amount;
    public void IncreaseHealPower(int amount) => HealPower += amount;
}