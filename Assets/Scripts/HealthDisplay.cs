using TMPro;
using UnityEngine;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _healthText;

    private void Start()
    {
        InitializeHealthDisplay();
    }

    private void InitializeHealthDisplay()
    {
        if (_healthText != null)
        {
            UpdateHealthDisplay();
            _health.DamageTaken += UpdateHealthDisplay;
            _health.HealthRecovered += UpdateHealthDisplay;
        }
    }

    private void UpdateHealthDisplay()
    {
        _healthText.text = $"{_health.CurrentValue}/{_health.MaxValue}";
    }

    private void OnDisable()
    {
        if (_healthText != null)
        {
            _health.DamageTaken -= UpdateHealthDisplay;
            _health.HealthRecovered -= UpdateHealthDisplay;
        }
    }
}