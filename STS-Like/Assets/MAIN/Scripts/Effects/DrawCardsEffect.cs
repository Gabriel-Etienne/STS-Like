using UnityEngine;

public class DrawCardsEffect : Effect
{
    [SerializeField] private int drawAmount;
    
    public override GameAction GetGameAction()
    {
        DrawCardGA drawCardGa = new(drawAmount);
        return drawCardGa;
    }
}
