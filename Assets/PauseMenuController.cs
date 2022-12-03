using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuController : MonoBehaviour
{
    public GameObject pauseMenuUI;

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

        if (GameStateManager.Instance.CurrentGameState == GameState.Paused)
        {
            pauseMenuUI.SetActive(true);
        } 
        else
        {
            pauseMenuUI.SetActive(false);
        }

    }
}
