using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _maxHealth;

    public event Action<float> HealthChanged;
    private float _health;

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }

    public void Heal(float healingAmount)
    {
        if (_health < _maxHealth)
        {
            _health += healingAmount;
            HealthChanged?.Invoke(_health);
        }
    }

    public void Damage(float damageAmount)
    {
        if (_health > 0)
        {
            _health -= damageAmount;
            HealthChanged?.Invoke(_health);
        }
    }
}
