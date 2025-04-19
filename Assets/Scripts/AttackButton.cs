public class AttackButton : HealthButtonBase
{
    protected override void OnButtonClicked()
    {
        Health.TakeDamage(Amount);
    }
}