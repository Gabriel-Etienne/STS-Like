using UnityEngine;
using System.Collections.Generic;

public class MatchSetupSystem : MonoBehaviour
{
    [SerializeField] private HeroData heroData;

    private void Start()
    {
        HeroSystem.Instance.Setup(heroData);
        CardSystem.Instance.Setup(heroData.Deck);
        DrawCardGA drawCardGa = new(5);
        ActionSystem.Instance.Perform(drawCardGa);
    }
    
}
