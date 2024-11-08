using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropPlace : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Transform _transform;
    [SerializeField] private TemporaryCard _temporaryCard;
    [SerializeField] private bool _isHand;
    [SerializeField] private int _maxCards;

    public void OnDrop(PointerEventData eventData)
    {
        if(eventData.pointerDrag.TryGetComponent(out CardMovement card) && _transform.childCount <= _maxCards)
        {
            card.SetParent(_transform);

            if(_isHand == false && eventData.pointerDrag.TryGetComponent(out CardView cardView))
            { 
                cardView.SetSmall();
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(eventData.pointerDrag == null) 
            return;

        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();

        if(card)
        {
            _temporaryCard.SetParent(_transform);
            _temporaryCard.SetSize(_isHand);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerDrag == null) 
            return;

        CardMovement card = eventData.pointerDrag.GetComponent<CardMovement>();

        if (card && _temporaryCard.transform.parent == transform)
        {
            _temporaryCard.SetParent(card.Parent);
        }
    }

    public TemporaryCard TemporaryCard => _temporaryCard;
    public bool IsHand => _isHand;
}
