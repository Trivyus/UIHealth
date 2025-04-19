using UnityEngine;
using UnityEngine.UI;

public abstract class HealthButtonBase : MonoBehaviour
{
    [SerializeField] protected Button _button;
    [SerializeField] protected Health _health;
    [SerializeField] protected float _amount;

    protected virtual void OnEnable()
    {
        if (_button != null)
        {
            _button.onClick.AddListener(OnButtonClicked);
        }
    }

    protected virtual void OnDisable()
    {
        if (_button != null)
        {
            _button.onClick.RemoveListener(OnButtonClicked);
        }
    }

    protected abstract void OnButtonClicked();
}
