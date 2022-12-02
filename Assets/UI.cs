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
        SetupContinueHandler();
        SetupOptionsHandler();
        SetupCreditsHandler();
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
        SceneManager.LoadScene("PawelLutostanski");
    }

    private void SetupContinueHandler()
    {
        Button buttonContinue = root.Q<Button>("ButtonContinue");
        if (buttonContinue != null)
        {
            buttonContinue.RegisterCallback<ClickEvent>(ContinueCallback);
        }
    }

    private void ContinueCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("PawelLutostanski");
    }

    private void SetupOptionsHandler()
    {
        Button buttonOptions = root.Q<Button>("ButtonOptions");
        if (buttonOptions != null)
        {
            buttonOptions.RegisterCallback<ClickEvent>(OptionsCallback);
        }
    }

    private void OptionsCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("PawelLutostanski");
    }

    private void SetupCreditsHandler()
    {
        Button buttonCredits = root.Q<Button>("ButtonCredit");
        if (buttonCredits != null)
        {
            buttonCredits.RegisterCallback<ClickEvent>(CreditsCallback);
        }
    }

    private void CreditsCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("PawelLutostanski");
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
