public class RecoverButton : HealthButtonBase
{
    protected override void OnButtonClicked()
    {
        Health.Recover(Amount);
    }
}
