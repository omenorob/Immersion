namespace Immersion;

public class Entity
{
    public string Name { get; protected set; }
    public int Health { get; protected set; }
    public int Damage { get; protected set; }
    public int Protect { get; protected set; }
    
    public bool IsDead => Health <= 0;

    public virtual void TakeDamage(int damage)
    {
        int finalDamage = Math.Max(1, damage - Protect);
        Health -= finalDamage;
    }
    
    public virtual void OnDeath(UI ui)
    {
        ui.ShowEnemyDeathUI(this);
    }
}