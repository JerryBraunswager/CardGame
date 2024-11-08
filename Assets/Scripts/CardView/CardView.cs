using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
public class CardView : MonoBehaviour
{
    private readonly int MinSize = 100;
    private readonly int MaxSize = 215;

    [SerializeField] private Transform _largeCard;
    [SerializeField] private Transform _smallCard;

    private RectTransform _transform;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    public void SetLarge()
    {
        _largeCard.gameObject.SetActive(true);
        _transform.sizeDelta = new Vector2(MaxSize, _transform.sizeDelta.y);
    }

    public void SetSmall()
    {
        _largeCard.gameObject.SetActive(false);
        _transform.sizeDelta = new Vector2(MinSize, _transform.sizeDelta.y);
    }

    public void SetPartiallyTransparent()
    {
        if (_largeCard.TryGetComponent(out Image image))
        {
            Color newColor = image.color;
            newColor.a = 0.7f;
            image.color = newColor;
        }
    }

    public void SetDefaultAlfa()
    {
        if (_largeCard.TryGetComponent(out Image image))
        {
            Color newColor = image.color;
            newColor.a = 1f;
            image.color = newColor;
        }
    }
}
