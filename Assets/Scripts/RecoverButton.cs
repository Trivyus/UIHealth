public class RecoverButton : HealthButtonBase
{
    protected override void OnButtonClicked()
    {
        if (_health != null)
        {
            _health.Recover(_amount);
        }
    }
}
