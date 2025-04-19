public class AttackButton : HealthButtonBase
{
    protected override void OnButtonClicked()
    {
        if (_health != null)
        {
            _health.TakeDamage(_amount);
        }
    }
}