using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlaceLogic : MonoBehaviour
{
    public abstract IEnumerable<Health> TryPlace(Health activeEnemy, Health[] allEnemies, Health hero);
}
