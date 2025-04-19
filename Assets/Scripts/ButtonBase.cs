using UnityEngine;
using UnityEngine.UI;

public abstract class HealthButtonBase : MonoBehaviour
{
    [SerializeField] protected Button Button;
    [SerializeField] protected Health Health;
    [SerializeField] protected float Amount;

    protected virtual void OnEnable()
    {
        Button.onClick.AddListener(OnButtonClicked);
    }

    protected virtual void OnDisable()
    {
        Button.onClick.RemoveListener(OnButtonClicked);
    }

    protected abstract void OnButtonClicked();
}
