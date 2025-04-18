using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthEffectsButton : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private Health _health;
    [SerializeField] private float _amount;
    [SerializeField] private HealthEffectType _modificationType;

    private void OnEnable()
    {
        _button.onClick.AddListener(ModifyHealth);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ModifyHealth);
    }

    private void ModifyHealth()
    {
        switch (_modificationType)
        {
            case HealthEffectType.Damage:
                _health.TakeDamage(_amount);
                break;
            case HealthEffectType.Heal:
                _health.Recover(_amount);
                break;
        }
    }
}