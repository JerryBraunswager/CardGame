using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class TemporaryCard : MonoBehaviour
{
    private readonly int MinSize = 100;
    private readonly int MaxSize = 215;

    private Transform _defaultParent;
    private Vector3 _defaultPosition;
    private RectTransform _transform;

    private void Awake()
    {
        _transform = GetComponent<RectTransform>();
    }

    private void Start()
    {
        _defaultParent = transform.parent;
        _defaultPosition = transform.position;
    }

    public void SetParent(Transform parent)
    {
        transform.SetParent(parent);
    }

    public void SetDefaultParent()
    {
        transform.SetParent(_defaultParent);
    }

    public void SetDefaultPosition() 
    { 
        transform.position = _defaultPosition;
    }

    public void SetSize(bool isHand)
    {
        if (isHand)
        {
            _transform.sizeDelta = new Vector2(MaxSize, _transform.sizeDelta.y);

        }
        else
        {
            _transform.sizeDelta = new Vector2(MinSize, _transform.sizeDelta.y);
        }
    }
}
