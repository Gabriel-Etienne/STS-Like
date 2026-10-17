using UnityEngine;

public class KillEnemyGA : GameAction
{
    public EnemyView Target;

    public KillEnemyGA(EnemyView enemyView)
    {
        Target = enemyView;
    }
}
