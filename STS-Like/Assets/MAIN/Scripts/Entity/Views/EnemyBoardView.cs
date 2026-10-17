using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class EnemyBoardView : MonoBehaviour
{
    [field: SerializeField] private List<Transform> slots;
    public List<EnemyView> EnemyViews = new List<EnemyView>();

    public void AddEnemy(EnemyData data)
    {
        Transform slot = slots[EnemyViews.Count];
        EnemyView enemyView = EnemyViewCreator.Instance.CreateEnemyView(data, slot.position, slot.rotation);
        enemyView.transform.SetParent(slot);
        EnemyViews.Add(enemyView);
    }
    
    // public void AddEnemy(EnemyData data)
    // {
    //     Debug.Log("[AddEnemy] Début");
    //
    //     if (slots == null)
    //     {
    //         Debug.LogError("[AddEnemy] slots est null");
    //         return;
    //     }
    //
    //     if (EnemyViews == null)
    //     {
    //         Debug.LogError("[AddEnemy] EnemyViews est null");
    //         return;
    //     }
    //
    //     if (EnemyViews.Count >= slots.Count)
    //     {
    //         Debug.LogError(
    //             $"[AddEnemy] Pas assez de slots : {EnemyViews.Count}/{slots.Count}"
    //         );
    //         return;
    //     }
    //
    //     Transform slot = slots[EnemyViews.Count];
    //
    //     if (slot == null)
    //     {
    //         Debug.LogError($"[AddEnemy] Le slot {EnemyViews.Count} est null");
    //         return;
    //     }
    //
    //     if (EnemyViewCreator.Instance == null)
    //     {
    //         Debug.LogError("[AddEnemy] EnemyViewCreator.Instance est null");
    //         return;
    //     }
    //
    //     EnemyView enemyView = EnemyViewCreator.Instance.CreateEnemyView(
    //         data,
    //         slot.position,
    //         slot.rotation
    //     );
    //
    //     if (enemyView == null)
    //     {
    //         Debug.LogError("[AddEnemy] CreateEnemyView a retourné null");
    //         return;
    //     }
    //
    //     enemyView.transform.SetParent(slot);
    //     EnemyViews.Add(enemyView);
    //
    //     Debug.Log("[AddEnemy] Terminé");
    // }

    public IEnumerator RemoveEnemy(EnemyView enemyView)
    {
        EnemyViews.Remove(enemyView);
        
        // small death animation
        Tween tween = enemyView.transform.DOScale(Vector3.zero, 0.25f);
        yield return tween.WaitForCompletion();
        
        Destroy(enemyView.gameObject);
    }
}
