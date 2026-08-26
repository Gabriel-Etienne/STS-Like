using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

public class CardSystem : Singleton<CardSystem>
{
    [SerializeField] private HandView handView;
    [SerializeField] private Transform drawPilePoint;
    [SerializeField] private Transform discardPilePoint;
    
    private readonly List<Card> drawPile = new List<Card>();
    private readonly List<Card> discardPile = new List<Card>();
    private readonly List<Card> hand = new List<Card>();
    
    public int drawPileNb => drawPile.Count;
    public int discardPileNb => discardPile.Count;
    public int handNb => hand.Count;
    
    [SerializeField] private float discardCardDuration = 0.15f;
    
    [SerializeField] private int nbCardToDraw = 5;

    private void OnEnable()
    {
        ActionSystem.AttachPerformer<DrawCardGA>(DrawCardPerformer);
        ActionSystem.AttachPerformer<DiscardAllCardsGA>(DiscardAllCardsPerformer);
        
        ActionSystem.SubscribeReaction<EnemyTurnGA>(EnemyTurnPreReaction, ReactionTiming.PRE);
        ActionSystem.SubscribeReaction<EnemyTurnGA>(EnemyTurnPostReaction, ReactionTiming.POST);
    }

    private void OnDisable()
    {
        ActionSystem.DetachPerformer<DrawCardGA>();
        ActionSystem.DetachPerformer<DiscardAllCardsGA>();
        
        
        ActionSystem.UnsubscribeReaction<EnemyTurnGA>(EnemyTurnPreReaction, ReactionTiming.PRE);
        ActionSystem.UnsubscribeReaction<EnemyTurnGA>(EnemyTurnPostReaction, ReactionTiming.POST);
    }

    public void Setup(List<CardData> deckData)
    {
        foreach (var cardData in deckData)
        {
            Card card = new(cardData);
            drawPile.Add(card);
        }
    }
    
    
    #region Reactions

    private void EnemyTurnPreReaction(EnemyTurnGA enemyTurnGa)
    {
        DiscardAllCardsGA discardAllCardsGa = new();
        ActionSystem.Instance.AddReaction(discardAllCardsGa);

    }
    
    private void EnemyTurnPostReaction(EnemyTurnGA enemyTurnGa)
    {
        DrawCardGA drawCardGa = new(nbCardToDraw);
        ActionSystem.Instance.AddReaction(drawCardGa);
    }
    
    #endregion
    
    #region Performers
    
        private IEnumerator DrawCardPerformer(DrawCardGA drawCardGa)
        {
            int actualAmount = Mathf.Min(drawCardGa.Amount, drawPile.Count);
            int notDrawnAmount = drawCardGa.Amount - actualAmount;

            for (int i = 0; i < actualAmount; i++)
            {
                yield return DrawCard();
            }

            if (notDrawnAmount > 0)
            {
                RefillDeck();
                for (int i = 0; i < notDrawnAmount; i++)
                {
                    yield return DrawCard();
                }
            }
        }
        
        private IEnumerator DiscardAllCardsPerformer(DiscardAllCardsGA discardAllCardsGa)
        {
            foreach (Card card in hand)
            {
                discardPile.Add(card);
                CardView cardView = handView.RemoveCard(card);
                yield return DiscardCard(cardView);
            }
            hand.Clear();
        }

    #endregion
    
    #region Helpers

        private IEnumerator DrawCard()
        {
            Card card = drawPile.Draw();
            hand.Add(card);
            CardView cardView = CardViewCreator.Instance.CreateCardView(card, drawPilePoint.position, drawPilePoint.rotation);
            
            yield return handView.AddCard(cardView);
        }

        private void RefillDeck()
        {
            drawPile.AddRange(discardPile);
            discardPile.Clear();
        }


        private IEnumerator DiscardCard(CardView cardView)
        {
            cardView.transform.DOScale(Vector3.zero, discardCardDuration);
            Tween tween = cardView.transform.DOMove(discardPilePoint.position, discardCardDuration);
            yield return tween.WaitForCompletion();
            Destroy(cardView.gameObject);
        }
    
    #endregion
}
