using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityEffect : MonoBehaviour
{
    public abstract void Effect(Health target, int damage, Transform holder);
}
