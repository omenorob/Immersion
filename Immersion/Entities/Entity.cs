namespace Immersion;

public class Entity
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Damage { get; set; }
    public int Protect { get; set; }
    public int Coins { get; set; }
    
    public bool IsDead => Health <= 0;

    public virtual void TakeDamage(int damage)
    {
        int finalDamage = Math.Max(1, damage - Protect);
        Health -= finalDamage;

        if (Health < 0)
            Health = 0;
    }
    
    public virtual int GetBaseCoins()
    {
        return 1;
    }
}