namespace Immersion;

public class Player : Entity
{
    public PlayerUpgrade Upgrade { get; private set; }
    public int Coins { get; private set; }

    public Player()
    {
        Name = "Player";
        Health = GameConstants.PlayerStartHealth;
        Damage = GameConstants.PlayerStartDamage;
        Protect = GameConstants.PlayerStartProtect;
        Coins = GameConstants.PlayerStartCoins;
        Upgrade = new PlayerUpgrade();
    }

    public int Heal(int amount)
    {
        Health += amount;
        return amount;
    }

    public void PlayerReset()
    {
        Health = GameConstants.PlayerStartHealth + Upgrade.MaxHealthBoost;
        Damage = GameConstants.PlayerStartDamage + Upgrade.DamageBoost;
        Protect = GameConstants.PlayerStartProtect + Upgrade.ProtectBoost;
    }

    public int AddCoins(int amount)
    {
        Coins += amount;
        return Coins;
    }
    
    public bool SpendCoins(int amount)
    {
        if (Coins < amount)
            return false;

        Coins -= amount;
        return true;
    }
}