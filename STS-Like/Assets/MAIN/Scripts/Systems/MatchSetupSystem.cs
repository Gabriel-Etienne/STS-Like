using UnityEngine;
using System.Collections.Generic;

public class MatchSetupSystem : MonoBehaviour
{
    [SerializeField] private HeroData heroData;
    
    [SerializeField] private List<EnemyData> enemyDatas;   // temporary because the system to select witch enemy spawn is not ready yet

    private void Start()
    {
        HeroSystem.Instance.Setup(heroData);
        EnemySystem.Instance.Setup(enemyDatas);
        
        CardSystem.Instance.Setup(heroData.Deck);
        
        DrawCardGA drawCardGa = new(5);
        ActionSystem.Instance.Perform(drawCardGa);
    }
    
}
