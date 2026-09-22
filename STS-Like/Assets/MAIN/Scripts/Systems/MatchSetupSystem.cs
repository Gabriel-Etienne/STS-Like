using UnityEngine;
using System.Collections.Generic;

public class MatchSetupSystem : MonoBehaviour
{
    [SerializeField] private List<CardData> deckData;

    private void Start()
    {
        CardSystem.Instance.Setup(deckData);
        DrawCardGA drawCardGa = new(5);
        ActionSystem.Instance.Perform(drawCardGa);
    }
    
}
