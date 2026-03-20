namespace Immersion;

public class CombatSystem
{
    private readonly Random _random = new Random();
    
    public AttackResult PlayerAttack(Player player, Entity enemy)
    {
        bool isCritical = _random.Next(100) < GameConstants.CriticalChancePercent;
        int damage = isCritical ? player.Damage * 2 : player.Damage;
        
        enemy.TakeDamage(damage);
        
        return new AttackResult
        {
            Damage = damage,
            IsCritical = isCritical,
            TargetDead = enemy.IsDead
        };
    }
    
    public AttackResult EnemyAttack(Entity enemy, Player player)
    {
        int damage = enemy.Damage;
        
        player.TakeDamage(damage);
        
        return new AttackResult
        {
            Damage = damage,
            IsCritical = false,
            TargetDead = player.IsDead
        };
    }
}