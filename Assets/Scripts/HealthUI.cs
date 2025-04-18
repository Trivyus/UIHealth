using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Slider _healthSlider;
    [SerializeField] private Slider _smoothHealthSlider;
    [SerializeField] private float _smoothSpeed = 5f;

    private Coroutine _smoothSliderCoroutine;

    private void Start()
    {
        InitializeHealthDisplay();
        InitializeHealthSlider();
        InitializeSmoothHealthSlider();
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

    private void InitializeSmoothHealthSlider()
    {
        if (_smoothHealthSlider != null)
        {
            _smoothHealthSlider.maxValue = _health.MaxValue;
            _smoothHealthSlider.value = _health.CurrentValue;
            _health.DamageTaken += SmoothHealthSliderUpdate;
            _health.HealthRecovered += SmoothHealthSliderUpdate;
        }
    }

    private void UpdateHealthDisplay()
    {
        _healthText.text = $"{_health.CurrentValue}/{_health.MaxValue}";
    }

    private void UpdateHealthSlider()
    {
        _healthSlider.value = _health.CurrentValue;
    }

    private void SmoothHealthSliderUpdate()
    {
        if (_smoothSliderCoroutine != null)
            StopCoroutine(_smoothSliderCoroutine);

        _smoothSliderCoroutine = StartCoroutine(SmoothSliderUpdate());
    }

    private IEnumerator SmoothSliderUpdate()
    {
        float startValue = _smoothHealthSlider.value;
        float targetValue = _health.CurrentValue;
        float elapsedTime = 0f;

        while (elapsedTime < 1f)
        {
            elapsedTime += Time.deltaTime * _smoothSpeed;
            _smoothHealthSlider.value = Mathf.Lerp(startValue, targetValue, elapsedTime);
            yield return null;
        }

        _smoothHealthSlider.value = targetValue;
    }

    private void OnDisable()
    {
        if (_healthText != null)
        {
            _health.DamageTaken -= UpdateHealthDisplay;
            _health.HealthRecovered -= UpdateHealthDisplay;
        }

        if (_healthSlider != null)
        {
            _health.DamageTaken -= UpdateHealthSlider;
            _health.HealthRecovered -= UpdateHealthSlider;
        }

        if (_smoothHealthSlider != null)
        {
            _health.DamageTaken -= SmoothHealthSliderUpdate;
            _health.HealthRecovered -= SmoothHealthSliderUpdate;
        }
    }
}
