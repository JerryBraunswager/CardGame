using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(CanvasGroup))]
[RequireComponent(typeof(CardView))]
public class CardMovement : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Transform _defaultParent;
    private Vector3 _offset;
    private Transform _parent;
    private CanvasGroup _canvasGroup;
    private TemporaryCard _temporaryCard;
    private CardView _cardView;

    private void Awake()
    {
        _defaultParent = transform.parent;
        _canvasGroup = GetComponent<CanvasGroup>();
        _cardView = GetComponent<CardView>();
    }

    private void Start()
    {
        _temporaryCard = transform.parent.GetComponent<DropPlace>().TemporaryCard;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        _cardView.SetLarge();
        _cardView.SetPartiallyTransparent();
        Vector3 mousePosition = eventData.position;
        _offset = transform.position - mousePosition;
        _parent = _defaultParent;
        _temporaryCard.SetParent(_parent);
        _temporaryCard.transform.SetSiblingIndex(transform.GetSiblingIndex());
        transform.SetParent(_parent.parent);
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 newPosition = eventData.position;
        newPosition.z = 0;
        transform.position = newPosition + _offset;
        CheckPosition();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        _cardView.SetDefaultAlfa();
        transform.SetParent(_parent);
        _canvasGroup.blocksRaycasts = true;
        transform.SetSiblingIndex(_temporaryCard.transform.GetSiblingIndex());
        _temporaryCard.SetDefaultParent();
        _temporaryCard.SetDefaultPosition();
    }

    public Transform Parent => _parent;

    public void SetParent(Transform parent) 
    {
        _parent = parent;
    }

    private void CheckPosition()
    {
        int newIndex = _temporaryCard.transform.parent.childCount;

        for(int i = 0; i < _temporaryCard.transform.parent.childCount; i++)
        {
            if(transform.position.x < _temporaryCard.transform.parent.GetChild(i).position.x)
            {
                newIndex = i;

                if (_temporaryCard.transform.GetSiblingIndex() < newIndex)
                {
                    newIndex--;
                }

                break;
            }
        }

        _temporaryCard.transform.SetSiblingIndex(newIndex);
    }
}
