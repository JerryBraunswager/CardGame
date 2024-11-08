using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] private PlaceLogic _placeLogic;
    [SerializeField] private List<AbilityEffect> _effects;

    public void ApplyEffect(IEnumerable<Health> targets, int damage)
    {
        foreach(AbilityEffect effect in _effects)
        {
            foreach(Health target in targets)
            {
                effect.Effect(target, damage, target.EffectsHolder);
            }
        }
    }

    public IEnumerable<Health> SelectTargets(Health activeEnemy, Health[] allEnemies, Health hero)
    {
        return _placeLogic.TryPlace(activeEnemy, allEnemies, hero);
    }
}
