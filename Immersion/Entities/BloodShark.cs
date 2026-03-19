namespace Immersion;

public class BloodShark : Entity
{
    public BloodShark()
    {
        Name = "Blood Shark";
        Health = 10;
        Damage = 2;
    }
    
    public override int GetBaseCoins()
    {
        return 1;
    }
}