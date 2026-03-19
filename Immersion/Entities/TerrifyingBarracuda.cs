namespace Immersion;

public class TerrifyingBarracuda : Entity
{
    public TerrifyingBarracuda()
    {
        Name = "Terrifying Barracuda";
        Health = 20;
        Damage = 5;
    }
    
    public override int GetBaseCoins()
    {
        return 3;
    }
}