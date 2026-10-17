using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using DG.Tweening;

public class EnemyBoardView : MonoBehaviour
{
    [field: SerializeField] private List<Transform> slots;
    public List<EnemyView> EnemyViews { get; private set; }

    public void AddEnemy(EnemyData data)
    {
        Transform slot = slots[EnemyViews.Count];
        EnemyView enemyView = EnemyViewCreator.Instance.CreateEnemyView(data, slot.position, slot.rotation);
        enemyView.transform.SetParent(slot);
        EnemyViews.Add(enemyView);
    }

    public IEnumerator RemoveEnemy(EnemyView enemyView)
    {
        EnemyViews.Remove(enemyView);
        
        // small death animation
        Tween tween = enemyView.transform.DOScale(Vector3.zero, 0.25f);
        yield return tween.WaitForCompletion();
        
        Destroy(enemyView.gameObject);
    }
}
