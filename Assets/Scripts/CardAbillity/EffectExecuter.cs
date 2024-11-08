using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectExecuter : MonoBehaviour
{
    [SerializeField] private Transform _enchantmentBar;

    public void GetCards()
    {
        Card[] cards = _enchantmentBar.GetComponentsInChildren<Card>(_enchantmentBar.transform);

        foreach (Card card in cards) { Debug.Log(card); }
    }
}
