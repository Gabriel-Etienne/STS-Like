using TMPro;
using UnityEngine;

public class EnemyView : CombatantView
{
    [SerializeField] private TMP_Text attackText;
    public int AttackPower { get; set; }

    public void Setup(EnemyData data)
    {
        AttackPower = data.Attack;
        UpdateAttackText();
        SetupBase(data.Health, data.Image);
    }

    private void UpdateAttackText()
    {
        attackText.text = AttackPower.ToString();
    }
}
