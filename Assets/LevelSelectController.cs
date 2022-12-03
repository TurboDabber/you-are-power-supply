using UnityEngine;

public class LevelSelectController : MonoBehaviour
{
    void Start()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        gameObject.SetActive(false);
        OnGameStateChanged(GameStateManager.Instance.CurrentGameState);
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        Debug.Log("AXWNWQEEWQEWQ");
        gameObject.SetActive(newGameState == GameState.LevelSelect);
    }
}
