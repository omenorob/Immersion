namespace Immersion;

public class CombatSystem
{
    private const int TurnDelay = 250;
    
    public void Fight(Player player, Entity entity, UI ui)
    {
        Console.Clear();
        
        while (!player.IsDead && !entity.IsDead)
        {
            entity.TakeDamage(player.Damage);
            ui.ShowPlayerAttackUI(player, entity);
            if (!entity.IsDead)
            {
                ui.ShowEnemyHealthUI(entity);
            }
            if (entity.IsDead)
            {
                CheckDeath(entity, ui);
                break;
            }
            
            Console.WriteLine();
            Thread.Sleep(TurnDelay);
            
            player.TakeDamage(entity.Damage);
            ui.ShowEnemyAttackUI(entity);
            if (!player.IsDead)
            {
                ui.ShowPlayerHealthUI(player);
            }
            if (player.IsDead)
            {
                CheckDeath(player, ui);
                break;
            }
            
            Console.WriteLine();
            Thread.Sleep(TurnDelay);
        }
    }

    private void CheckDeath(Entity entity, UI ui)
    {
        if (!entity.IsDead)
            return;
        
        entity.OnDeath(ui);
    }
}