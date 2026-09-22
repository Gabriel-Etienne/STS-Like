using System;
using UnityEngine;
using TMPro;

public class CardView : MonoBehaviour
{
    [SerializeField] private TMP_Text title;
    [SerializeField] private TMP_Text description;
    [SerializeField] private TMP_Text mana;
    
    [SerializeField] private SpriteRenderer imageSR;
    [SerializeField] private GameObject wrapper;
    
    [SerializeField] private LayerMask dropAreaLayer;

    public Card cardRef;
    
    // for the drag system
    private Vector3 dragStartPosition;
    private Quaternion dragStartRotation;
    private float zValueWhenDragged = -1;
    
    private bool isSetupFinished = false;
    
    public void Setup(Card card)
    {
        Debug.Log($"Setup CardView - card = {card}");
        
        cardRef = card;
        
        title.text = card.Title;
        description.text = card.Description;
        mana.text = card.Mana.ToString();
        imageSR.sprite = card.Image;

        isSetupFinished = true;
    }

    private void OnMouseEnter()
    {
        if (!Interactions.Instance.PlayerCanHover() || !isSetupFinished) return;
        
        wrapper.SetActive(false);
        Vector3 pos = new(transform.position.x, -2, 0);
        
        CardViewHoverSystem.Instance.Show(cardRef, pos);
    }

    private void OnMouseExit()
    {
        if (!Interactions.Instance.PlayerCanHover() || !isSetupFinished) return;
        
        CardViewHoverSystem.Instance.Hide();
        wrapper.SetActive(true);
    }

    // click on a card
    private void OnMouseDown()
    {
        if (!Interactions.Instance.PlayerCanInteract() || !isSetupFinished) return;
        Interactions.Instance.PlayerIsDragging = true;
        wrapper.SetActive(true);
        CardViewHoverSystem.Instance.Hide();
        
        dragStartPosition = transform.position;
        dragStartRotation = transform.rotation;
        
        transform.rotation = Quaternion.Euler(0,0,0);
        transform.position = MouseUtil.GetMousePositionInWorldSpace(zValueWhenDragged);
    }

    // drag the card around
    private void OnMouseDrag()
    {
        if (!Interactions.Instance.PlayerCanInteract() || !isSetupFinished) return;
        transform.position = MouseUtil.GetMousePositionInWorldSpace(zValueWhenDragged);
    }

    // when you release the card
    private void OnMouseUp()
    {
        if (!Interactions.Instance.PlayerCanInteract() || !isSetupFinished) return;
        if (Physics.Raycast(transform.position, Vector3.forward, out RaycastHit hit, 10f, dropAreaLayer))
        { 
            // play the card
            PlayCardGA playCardGa = new PlayCardGA(cardRef);
            ActionSystem.Instance.Perform(playCardGa);
        }
        else
        { 
            transform.position = dragStartPosition;
            transform.rotation = dragStartRotation;
        }
        
        Interactions.Instance.PlayerIsDragging = false;
    }
}
