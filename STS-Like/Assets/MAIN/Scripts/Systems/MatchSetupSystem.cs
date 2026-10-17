using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class MatchSetupSystem : MonoBehaviour
{
    [SerializeField] private HeroData heroData;
    
    [SerializeField] private List<EnemyData> enemyDatas;   // temporary because the system to select witch enemy spawn is not ready yet

    private void Start()
    {
        StartCoroutine(WaitForSetup());
    }
    
    private IEnumerator WaitForSetup()
    {
        bool isEverythingReady = false;
        while (!isEverythingReady)
        {
            isEverythingReady =
                HeroSystem.Instance != null &&
                EnemySystem.Instance != null &&
                CardSystem.Instance != null &&
                ActionSystem.Instance != null &&
                EnemyViewCreator.Instance != null;

            yield return null; 
        }
        
        HeroSystem.Instance.Setup(heroData);
        EnemySystem.Instance.Setup(enemyDatas);
        
        CardSystem.Instance.Setup(heroData.Deck);
        
        DrawCardGA drawCardGa = new(5);
        ActionSystem.Instance.Perform(drawCardGa);
    }
    
}
