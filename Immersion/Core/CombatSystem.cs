namespace Immersion;

public class CombatSystem
{
    private const int TurnDelay = 350;
    
    public void Fight(Player player, Entity entity, Ui ui)
    {
        while (!player.IsDead && !entity.IsDead)
        {
            entity.TakeDamage(player.Damage);
            ui.ShowPlayerAttackUi(player, entity);
            if (entity.IsDead)
            {
                CheckDeath(entity, ui);
                break;
            }
            else
            {
                ui.ShowEnemyHealthUi(entity);
            }
            
            Console.WriteLine();
            Thread.Sleep(TurnDelay);
            
            player.TakeDamage(entity.Damage);
            ui.ShowEnemyAttackUi(entity);
            if (player.IsDead)
            {
                CheckDeath(player, ui);
                break;
            }
            else
            {
                ui.ShowPlayerHealthUi(player);
            }
            
            Console.WriteLine();
            Thread.Sleep(TurnDelay);
        }
    }

    private void CheckDeath(Entity entity, Ui ui)
    {
        if (!entity.IsDead)
            return;
        
        entity.OnDeath(ui);
    }
    
    private void CriticalDamage(Entity entity)
    {
        Random random = new Random();
        
        bool isCritical = random.Next(0, 100) < 5;
        int damage = isCritical ? entity.Damage * 2 : entity.Damage;
        
        entity.TakeDamage(damage);
        
        if (isCritical)
            Console.WriteLine("Critical hit!");
    }
}