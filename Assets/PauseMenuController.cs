using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameStateManager.Instance.CurrentGameState);
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        gameObject.SetActive(newGameState == GameState.Paused);
    }
}
