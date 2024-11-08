using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] private int _maxValue;
    [SerializeField] private int _current;
    [SerializeField] private Transform _effectsHolder;

    private int _shield = 0;

    private void Start()
    {
        _current = _maxValue;
        HealthCheck();
    }

    public event UnityAction<int, int> HealthChanged;
    public event UnityAction<int> ShieldChanged;
    public event UnityAction Died;
    public Transform EffectsHolder => _effectsHolder;

    public void Heal(int health)
    {
        if (health > 0)
        {
            _current += health;
            HealthCheck();
        }
    }

    public void AddShield(int shield) 
    { 
        if (shield > 0) 
        { 
            _shield += shield;
        }
    }

    public void TakeDamage(int damage) 
    {
        if(damage > 0) 
        {
            int puredamage = 0;

            if(damage > _shield)
            {
                puredamage = damage - _shield;
            }
            else 
            { 
                _shield -= damage;
            }

            _current -= puredamage;
            HealthCheck();

            if(_current == 0)
            {
                Died.Invoke();
            }
        }
    }

    private void HealthCheck()
    {
        _current = Mathf.Clamp(_current, 0, _maxValue);
        HealthChanged.Invoke(_current, _maxValue);
        //ShieldChanged.Invoke(_shield);
    }
}
