namespace Immersion;

public class Player : Entity
{
    public int HealPower { get; set; }

    public Player()
    {
        Name = "You";
        Health = 20;
        Damage = 5;
    }

    public void Heal()
    {
        Health += HealPower;
    }
    
    public override void OnDeath(UI ui)
    {
        ui.ShowPlayerDeathUI();
    }
}