using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ManaUI : MonoBehaviour
{
    [SerializeField] private TMP_Text manaText;
    [SerializeField] private Image image;
    [SerializeField] private Transform visual;

    [Header("Animation")]
    [SerializeField] private float fillDuration = 0.3f;
    [SerializeField] private float punchScale = 0.15f;

    private Tween fillTween;
    private Tween scaleTween;

    public void UpdateManaText(int currentMana, int maxMana)
    {
        manaText.text = currentMana + "/" + maxMana;

        float targetFill = maxMana > 0
            ? Mathf.Clamp01((float)currentMana / maxMana)
            : 0f;

        // Animation immédiate du remplissage
        fillTween?.Kill();

        fillTween = image
            .DOFillAmount(targetFill, fillDuration)
            .SetEase(Ease.Linear);

        // Petite pulsation de l'interface
        scaleTween?.Kill();

        visual.localScale = Vector3.one;

        scaleTween = visual
            .DOPunchScale(
                Vector3.one * punchScale,
                0.25f,
                5,
                0.5f
            );
    }

    private void OnDestroy()
    {
        fillTween?.Kill();
        scaleTween?.Kill();
    }
}