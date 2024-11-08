using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceLogicSelected : PlaceLogic
{
    public override IEnumerable<Health> TryPlace(Health activeEnemy, Health[] allEnemies, Health hero)
    {
        yield return activeEnemy;
    }
}
