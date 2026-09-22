using UnityEngine;

public class PlayCardGA : GameAction
{
    public Card card { get; set; }

    public PlayCardGA(Card _card)
    {
        card =  _card;
    }
    
}
