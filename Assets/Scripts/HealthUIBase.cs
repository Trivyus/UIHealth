using UnityEngine;

public abstract class HealthUIBase : MonoBehaviour
{
    [SerializeField] protected Health _health;

    protected virtual void Start()
    {
        if (_health != null)
        {
            Initialize();
            _health.DamageTaken += OnHealthChangedUpdate;
            _health.HealthRecovered += OnHealthChangedUpdate;
        }
    }

    protected virtual void OnDisable()
    {
        if (_health != null)
        {
            _health.DamageTaken -= OnHealthChangedUpdate;
            _health.HealthRecovered -= OnHealthChangedUpdate;
        }
    }

    protected abstract void Initialize();
    protected abstract void OnHealthChangedUpdate();
}
