using UnityEngine;
using UnityEngine.UI;

public class RecoverButton : MonoBehaviour
{
    [SerializeField] private Button _recoverButton;
    [SerializeField] private Health _health;

    [SerializeField] private float _amountHeal;

    private void OnEnable()
    {
        _recoverButton.onClick.AddListener(Heal);
    }

    private void OnDisable()
    {
        _recoverButton.onClick.RemoveListener(Heal);
    }

    public void Heal()
    {
        _health.Recover(_amountHeal);
    }
}
