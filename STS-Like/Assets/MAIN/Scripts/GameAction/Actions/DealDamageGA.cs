using UnityEngine;
using System.Collections.Generic;

public class DealDamageGA : GameAction
{
    public int Amount;
    public List<CombatantView> Targets { get; set; }
    public DealDamageGA(int amount, List<CombatantView> targets)
    {
        Amount = amount;
        Targets = targets;
    }
}
