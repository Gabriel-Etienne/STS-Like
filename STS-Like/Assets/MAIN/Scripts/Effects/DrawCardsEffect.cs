using UnityEngine;
using System.Collections.Generic;

public class DrawCardsEffect : Effect
{
    [SerializeField] private int drawAmount;
    
    public override GameAction GetGameAction(List<CombatantView> _targets)
    {
        DrawCardGA drawCardGa = new(drawAmount);
        return drawCardGa;
    }
}
