using UnityEngine;

public class HeroView : CombatantView
{
    public void Setup(HeroData data)
    {
        SetupBase(data.Health, data.Image);
    }
}
