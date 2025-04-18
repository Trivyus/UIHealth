using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AttackButton : MonoBehaviour
{
    [SerializeField] private Button _AttackButton;
    [SerializeField] private Health _health;

    [SerializeField] private float _amountDamage;

    private void OnEnable()
    {
        _AttackButton.onClick.AddListener(DealDamage);
    }

    private void OnDisable()
    {
        _AttackButton.onClick.RemoveListener(DealDamage);
    }

    public void DealDamage()
    {
        _health.TakeDamage(_amountDamage);
    }
}
