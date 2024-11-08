using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityEffectDamage : AbilityEffect
{
    public override void Effect(Health target, int damage, Transform holder)
    {
        if (target != null && damage > 0)
        {
            target.TakeDamage(damage);
        }
    }
}
