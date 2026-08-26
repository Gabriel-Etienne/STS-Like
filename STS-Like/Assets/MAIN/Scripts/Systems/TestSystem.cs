using UnityEngine;

public class TestSystem : MonoBehaviour
{
    [SerializeField] private HandView handView;
    [SerializeField] private CardData cardData;
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Card card = new(cardData); // créer la class contenant les info de la card
            
            CardView cardView = CardViewCreator.Instance.CreateCardView(card ,transform.position, Quaternion.identity); // créer le visuel de la card en fonction des info dans card
            
            StartCoroutine(handView.AddCard(cardView)); // ajoute la carte à la main du joueur
        }
    }
}
