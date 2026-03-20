namespace Immersion;

public class WaveManager
{
    private int _enemyNumber;
    private int _lastHealWave = 0;
    private int _lastCreepMessageWave = 0;
    
    public Entity NextEnemy()
    {
        _enemyNumber++;
        return EnemyFactory.Spawn(_enemyNumber);
    }
    
    public int EnemyNumber => _enemyNumber;
    
    public void Reset() => _enemyNumber = 0;
    
    public bool ShouldHeal() => (_enemyNumber / 10) > _lastHealWave;
    public void MarkHealed() => _lastHealWave = _enemyNumber / 10;

    public bool ShouldShowCreepMessage() => (_enemyNumber / 20) > _lastCreepMessageWave;
    public void MarkCreepMessageShown() => _lastCreepMessageWave = _enemyNumber / 20;
}