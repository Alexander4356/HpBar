using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;
    
    private Coroutine _coroutine;
    private float _speed = 0.1f;

    private void OnEnable()
    {
        _player.HealthChanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float health)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
        }

        _coroutine = StartCoroutine(Changing(health));
    }

    private IEnumerator Changing(float health)
    {
        while (_slider.value != health)
        {
            _slider.value = Mathf.MoveTowards(_slider.value, health, _speed);

            yield return null;
        }
    }
}
