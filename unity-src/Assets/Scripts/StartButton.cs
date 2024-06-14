using UnityEngine;

public class StartButton : MonoBehaviour
{
    public void StartGame()
    {
        GameMaster.Instance.OnGameStateChange(GameState.Playing);
    }
}
