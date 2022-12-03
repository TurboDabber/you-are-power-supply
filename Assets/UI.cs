using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class UI : MonoBehaviour
{
    private VisualElement root;
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        RegisterButtonHandlers();
    }

    private void OnDestroy()
    {
        UnregisterButtonHandlers();
    }

    private void RegisterButtonHandlers()
    {
        RegisterNewGameHandler();
        RegisterContinueHandler();
        RegisterOptionsHandler();
        RegisterCreditsHandler();
        RegisterQuitHandler();
    }

    private void UnregisterButtonHandlers()
    {
        UnregisterNewGameHandler();
        UnregisterContinueHandler();
        UnregisterOptionsHandler();
        UnregisterCreditsHandler();
        UnregisterQuitHandler();
    }

    private void RegisterNewGameHandler()
    {
        Button buttonNewGame = root.Q<Button>("ButtonNewGame");
        if (buttonNewGame != null)
        {
            buttonNewGame.RegisterCallback<ClickEvent>(NewGameCallback);
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

    private void RegisterOptionsHandler()
    {
        Button buttonOptions = root.Q<Button>("ButtonOptions");
        if (buttonOptions != null)
        {
            buttonOptions.RegisterCallback<ClickEvent>(OptionsCallback);
        }
    }

    private void RegisterCreditsHandler()
    {
        Button buttonCredits = root.Q<Button>("ButtonCredit");
        if (buttonCredits != null)
        {
            buttonCredits.RegisterCallback<ClickEvent>(CreditsCallback);
        }
    }

    private void RegisterQuitHandler()
    {
        Button buttonQuit = root.Q<Button>("ButtonQuit");
        if (buttonQuit != null)
        {
            buttonQuit.RegisterCallback<ClickEvent>(QuitCallback);
        }
    }

    private void UnregisterNewGameHandler()
    {
        Button buttonNewGame = root.Q<Button>("ButtonNewGame");
        if (buttonNewGame != null)
        {
            buttonNewGame.UnregisterCallback<ClickEvent>(NewGameCallback);
        }
    }

    private void UnregisterContinueHandler()
    {
        Button buttonContinue = root.Q<Button>("ButtonContinue");
        if (buttonContinue != null)
        {
            buttonContinue.UnregisterCallback<ClickEvent>(NewGameCallback);
        }
    }

    private void UnregisterOptionsHandler()
    {
        Button buttonOptions = root.Q<Button>("ButtonOptions");
        if (buttonOptions != null)
        {
            buttonOptions.UnregisterCallback<ClickEvent>(NewGameCallback);
        }
    }

    private void UnregisterCreditsHandler()
    {
        Button buttonCredits = root.Q<Button>("ButtonCredits");
        if (buttonCredits != null)
        {
            buttonCredits.UnregisterCallback<ClickEvent>(NewGameCallback);
        }
    }

    private void UnregisterQuitHandler()
    {
        Button buttonQuit = root.Q<Button>("ButtonQuit");
        if (buttonQuit != null)
        {
            buttonQuit.UnregisterCallback<ClickEvent>(NewGameCallback);
        }
    }

    private void NewGameCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("PawelLutostanski");
    }

    private void ContinueCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("PawelLutostanski");
    }

    private void OptionsCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("PawelLutostanski");
    }

    private void CreditsCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("PawelLutostanski");
    }

    private void QuitCallback(ClickEvent evt)
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
