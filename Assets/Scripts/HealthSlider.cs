using UnityEngine;
using UnityEngine.UI;

public class HealthSlider : HealthUIBase
{
    [SerializeField] private Slider _healthSlider;

    protected override void Initialize()
    {
        _healthSlider.maxValue = _health.MaxValue;
        UpdateHealthSlider();
    }

    protected override void OnHealthChangedUpdate()
    {
        UpdateHealthSlider();
    }

    private void UpdateHealthSlider()
    {
        _healthSlider.value = _health.CurrentValue;
    }
}
