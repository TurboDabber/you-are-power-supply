using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{

    private VisualElement root;
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        SetupButtonHandlers();
    }

    private void SetupButtonHandlers()
    {
        SetupNewGameHandler();
        SetupLevelSelectHandler();
        SetupQuitHandler();
    }

    private void SetupNewGameHandler()
    {
        Button buttonNewGame = root.Q<Button>("ButtonNewGame");
        if (buttonNewGame != null)
        {
            buttonNewGame.RegisterCallback<ClickEvent>(NewGameCallback);
        }
    }

    private void NewGameCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("1LEVEL");
    }

    private void SetupLevelSelectHandler()
    {
        Button buttonContinue = root.Q<Button>("ButtonLevelSelect");
        if (buttonContinue != null)
        {
            buttonContinue.RegisterCallback<ClickEvent>(LevelSelectCallback);
        }
    }

    private void LevelSelectCallback(ClickEvent evt)
    {
        GameStateManager.Instance.SetState(GameState.LevelSelect);
    }

    private void SetupQuitHandler()
    {
        Button buttonQuit = root.Q<Button>("ButtonQuit");
        if (buttonQuit != null)
        {
            buttonQuit.RegisterCallback<ClickEvent>(QuitCallback);
        }
    }

    private void QuitCallback(ClickEvent evt)
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
