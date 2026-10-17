using UnityEngine;
using System.Collections.Generic;

public class EnemyBoardView : MonoBehaviour
{
    [field: SerializeField] private List<Transform> slots;
    public List<EnemyView> enemyViews { get; private set; }

    public void AddEnemy(EnemyData data)
    {
        Transform slot = slots[enemyViews.Count];
        EnemyView enemyView = EnemyViewCreator.Instance.CreateEnemyView(data, slot.position, slot.rotation);
        enemyView.transform.SetParent(slot);
        enemyViews.Add(enemyView);
    }
    
    // add a remove method later
    
}
