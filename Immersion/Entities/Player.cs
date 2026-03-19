namespace Immersion;

public class Player : Entity
{
    public PlayerUpgrade Upgrade { get; private set; }
    public int Coins { get; private set; }

    public Player()
    {
        Name = "You";
        Health = 20;
        Damage = 5;
        Protect = 0;
        Coins = 0;
        Upgrade = new PlayerUpgrade();
    }

    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"You healed for {amount} HP! Current health: {Health}");
    }
    
    public override void OnDeath(Ui ui)
    {
        ui.ShowPlayerDeathUi();
    }

    public void PlayerReset()
    {
        Health = 20 + Upgrade.MaxHealthBoost;
        Damage = 5 + Upgrade.DamageBoost;
        Protect = Upgrade.ArmorBoost;
    }

    public void AddCoins(int amount)
    {
        Coins += amount;
        Console.WriteLine($"\nYou got {amount} coins! Total: {Coins}");
    }
    
    public bool SpendCoins(int amount)
    {
        if (Coins < amount)
            return false;

        Coins -= amount;
        return true;
    }
}