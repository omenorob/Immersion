namespace Immersion;

public class CombatSystem
{
    private const int TurnDelay = 250;
    
    public void Fight(Player player, Entity entity, Ui ui)
    {
        Console.Clear();
        
        while (!player.IsDead && !entity.IsDead)
        {
            entity.TakeDamage(player.Damage);
            ui.ShowPlayerAttackUi(player, entity);
            if (!entity.IsDead)
            {
                ui.ShowEnemyHealthUi(entity);
            }
            if (entity.IsDead)
            {
                CheckDeath(entity, ui);
                break;
            }
            
            Console.WriteLine();
            Thread.Sleep(TurnDelay);
            
            player.TakeDamage(entity.Damage);
            ui.ShowEnemyAttackUi(entity);
            if (!player.IsDead)
            {
                ui.ShowPlayerHealthUi(player);
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

    private void CheckDeath(Entity entity, Ui ui)
    {
        if (!entity.IsDead)
            return;
        
        entity.OnDeath(ui);
    }
}