using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _changeAmount;
    [SerializeField] private float _changeSpeed;

    private float _targetValue;

    private void Start()
    {
        _targetValue = _healthBar.value;
    }

    public void DecreaseHealth()
    {
        if (_targetValue > 0)
        {
            _targetValue -= _changeAmount;
        }
    }

    public void IncreaseHealth()
    {
        if (_targetValue < 100)
        {
            _targetValue += _changeAmount;
        }
    }

    private void Update()
    {
        _healthBar.value = Mathf.MoveTowards(_healthBar.value, _targetValue, _changeSpeed * Time.deltaTime);
    }
}
