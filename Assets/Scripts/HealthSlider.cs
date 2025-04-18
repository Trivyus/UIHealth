using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Slider _healthSlider;

    private void Start()
    {
        InitializeHealthSlider();
    }

    private void InitializeHealthSlider()
    {
        if (_healthSlider != null)
        {
            _healthSlider.maxValue = _health.MaxValue;
            UpdateHealthSlider();
            _health.DamageTaken += UpdateHealthSlider;
            _health.HealthRecovered += UpdateHealthSlider;
        }
    }

    private void UpdateHealthSlider()
    {
        _healthSlider.value = _health.CurrentValue;
    }

    private void OnDisable()
    {
        if (_healthSlider != null)
        {
            _health.DamageTaken -= UpdateHealthSlider;
            _health.HealthRecovered -= UpdateHealthSlider;
        }
    }
}
