using System;
using System.Collections;
using UnityEngine;

public class DamageSystem : MonoBehaviour
{
    
    // later this script will most likely hold a dictionnary of vfx 
    // the key of the dictionnary will be an enum so the DealDamageGA can send witch vfx has to be played
    
    [SerializeField] private GameObject damageVFX;  // prefab

    void OnEnable()
    {
        ActionSystem.AttachPerformer<DealDamageGA>(DealDamagePerformer);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<DealDamageGA>();
    }


    private IEnumerator DealDamagePerformer(DealDamageGA dealDamageGA)
    {
        foreach (var target in dealDamageGA.Targets)
        {
            target.Damage(dealDamageGA.Amount);
            Instantiate(damageVFX, target.transform.position, Quaternion.identity);
            yield return new WaitForSeconds(0.15f);

            if (target.CurrentHealth <= 0)
            {
                if (target is EnemyView enemyView)
                {
                    KillEnemyGA killEnemyGA = new(enemyView);
                    ActionSystem.Instance.AddReaction(killEnemyGA);
                }
                else
                {
                    // logic for the player death
                }
            }
        }
    }


}
