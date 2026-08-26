using DG.Tweening;
using UnityEngine;

public class CardViewCreator : Singleton<CardViewCreator>
{
    [SerializeField] private CardView cardViewPrefab;
    [SerializeField] private float cardSpawnDuration = 0.15f;

    public CardView CreateCardView(Vector3 position, Quaternion rotation)
    {
        CardView cardView = Instantiate(cardViewPrefab, position, rotation);
        cardView.transform.localScale = Vector3.zero;
        
        cardView.transform.DOScale(Vector3.one, cardSpawnDuration);
        return cardView;
    }
}
