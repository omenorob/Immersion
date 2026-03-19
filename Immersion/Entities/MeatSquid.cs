namespace Immersion;

public class MeatSquid : Entity
{
    public MeatSquid()
    {
        Name = "Meat Squid";
        Health = 5;
        Damage = 5;
    }
    
    public override int GetBaseCoins()
    {
        return 2;
    }
}