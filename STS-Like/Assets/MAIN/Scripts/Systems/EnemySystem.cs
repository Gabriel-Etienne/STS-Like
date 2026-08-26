using System.Collections;
using UnityEngine;

public class EnemySystem : MonoBehaviour
{
    // Performers

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<EnemyTurnGA>(EnemyTurnPerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<EnemyTurnGA>();
    }
    
    
    

    private IEnumerator EnemyTurnPerformer(EnemyTurnGA enemyTurnGa)
    {
        Debug.Log("Enemy Turn");
        yield return new WaitForSeconds(2f);
        Debug.Log("End Enemy Turn");
    }
    
    
    
}
