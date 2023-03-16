using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _changeValue;
    [SerializeField] private float _maxHealth;

    public event Action<float> HealthChanged;
    private float _health;

    private void Start()
    {
        _health = _maxHealth;
        HealthChanged?.Invoke(_health);
    }

    public void Heal()
    {
        if (_health < _maxHealth)
        {
            _health += _changeValue;
            HealthChanged?.Invoke(_health);
        }
    }

    public void Damage()
    {
        if (_health > 0)
        {
            _health -= _changeValue;
            HealthChanged?.Invoke(_health);
        }
    }
}
