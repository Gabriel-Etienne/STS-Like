using UnityEngine;

public class EndTurnButtonUI : MonoBehaviour
{
    public void OnClick()
    {
        EnemyTurnGA enemyTurnGa = new EnemyTurnGA();
        ActionSystem.Instance.Perform(enemyTurnGa);
    }
}
