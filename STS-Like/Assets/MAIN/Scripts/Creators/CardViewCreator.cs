using DG.Tweening;
using UnityEngine;

public class CardViewCreator : Singleton<CardViewCreator>
{
    [SerializeField] private CardView cardViewPrefab;
    [SerializeField] private float cardSpawnDuration = 0.15f;

    public CardView CreateCardView(Card card, Vector3 position, Quaternion rotation)
    {
        CardView cardView = Instantiate(cardViewPrefab, position, rotation);
        cardView.transform.localScale = Vector3.zero;
        
        cardView.transform.DOScale(Vector3.one, cardSpawnDuration);

        cardView.Setup(card);
        
        return cardView;
    }
}
