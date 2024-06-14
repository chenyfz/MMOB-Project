public class FinishPlatform : Platform
{
    public bool triggered = false;
    public override void OnPlayerLand()
    {
        if (!triggered)
        {
            GameMaster.Instance.Done();
            triggered = true;
        }
    }
}
