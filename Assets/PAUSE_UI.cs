using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class PAUSE_UI : MonoBehaviour
{
    void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
        OnGameStateChanged(GameStateManager.Instance.CurrentGameState);
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
        UnregisterButtonHandlers();
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        gameObject.SetActive(newGameState == GameState.Paused);
    }

    private VisualElement root;
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        RegisterButtonHandlers();
    }

    private void RegisterButtonHandlers()
    {
        RegisterMainMenuHandler();
        RegisterRestartHandler();
        RegisterContinueHandler();
        RegisterLevelSelectHandler();
        RegisterExitGameHandler();
    }

    private void UnregisterButtonHandlers()
    {
        UnregisterMainMenuHandler();
        UnregisterRestartHandler();
        UnregisterContinueHandler();
        UnregisterLevelSelectHandler();
        UnregisterExitGameHandler();
    }

    private void RegisterMainMenuHandler()
    {
        Button buttonMainMenu = root.Q<Button>("ButtonMainMenu");
        if (buttonMainMenu != null)
        {
            buttonMainMenu.RegisterCallback<ClickEvent>(MainMenuCallback);
        }
    }

    private void RegisterRestartHandler()
    {
        Button buttonRestart = root.Q<Button>("ButtonRestart");
        if (buttonRestart != null)
        {
            buttonRestart.RegisterCallback<ClickEvent>(RestartCallback);
        }
    }

    private void RegisterContinueHandler()
    {
        Button buttonContinue = root.Q<Button>("ButtonContinue");
        if (buttonContinue != null)
        {
            buttonContinue.RegisterCallback<ClickEvent>(ContinueCallback);
        }
    }

    private void RegisterLevelSelectHandler()
    {
        Button buttonExitGame = root.Q<Button>("ButtonExitGame");
        if (buttonExitGame != null)
        {
            buttonExitGame.RegisterCallback<ClickEvent>(ExitGameCallback);
        }
    }

    private void RegisterExitGameHandler()
    {
        Button buttonExitGame = root.Q<Button>("ButtonExitGame");
        if (buttonExitGame != null)
        {
            buttonExitGame.RegisterCallback<ClickEvent>(ExitGameCallback);
        }
    }

    private void UnregisterMainMenuHandler()
    {
        Button buttonMainMenu = root.Q<Button>("ButtonMainMenu");
        if (buttonMainMenu != null)
        {
            buttonMainMenu.UnregisterCallback<ClickEvent>(MainMenuCallback);
        }
    }

    private void UnregisterRestartHandler()
    {
        Button buttonLevelSelect = root.Q<Button>("ButtonLevelSelect");
        if (buttonLevelSelect != null)
        {
            buttonLevelSelect.UnregisterCallback<ClickEvent>(RestartCallback);
        }
    }

    private void UnregisterContinueHandler()
    {
        Button buttonContinue = root.Q<Button>("ButtonContinue");
        if (buttonContinue != null)
        {
            buttonContinue.UnregisterCallback<ClickEvent>(ContinueCallback);
        }
    }

    private void UnregisterLevelSelectHandler()
    {
        Button buttonContinue = root.Q<Button>("ButtonLevelSelect");
        if (buttonContinue != null)
        {
            buttonContinue.UnregisterCallback<ClickEvent>(LevelSelectCallback);
        }
    }

    private void UnregisterExitGameHandler()
    {
        Button buttonExitGame = root.Q<Button>("ButtonExitGame");
        if (buttonExitGame != null)
        {
            buttonExitGame.UnregisterCallback<ClickEvent>(ExitGameCallback);
        }
    }

    private void MainMenuCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("MainMenu");
    }

    private void RestartCallback(ClickEvent evt)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ContinueCallback(ClickEvent evt)
    {
        gameObject.SetActive(false);
    }

    private void LevelSelectCallback(ClickEvent evt)
    {
        GameStateManager.Instance.SetState(GameState.LevelSelect);
    }

    private void ExitGameCallback(ClickEvent evt)
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
