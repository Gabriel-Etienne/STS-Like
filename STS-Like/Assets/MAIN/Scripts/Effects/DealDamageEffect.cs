using UnityEngine;
using System.Collections.Generic;

public class DealDamageEffect : Effect
{
    [SerializeField] private int damageAmount;
    public override GameAction GetGameAction(List<CombatantView> _targets)
    {
        DealDamageGA dealDamageGA = new(damageAmount, _targets);
        return dealDamageGA;
    }
}
