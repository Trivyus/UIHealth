using TMPro;
using UnityEngine;

public class HealthDisplay : HealthUIBase
{
    [SerializeField] private TMP_Text _healthText;

    protected override void Initialize()
    {
        UpdateHealthDisplay();
    }

    protected override void OnHealthChangedUpdate()
    {
        UpdateHealthDisplay();
    }

    private void UpdateHealthDisplay()
    {
        _healthText.text = $"{_health.CurrentValue}/{_health.MaxValue}";
    }
}