using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

//TODO: ADD RESTART BUTTON ? ASK CREWMATES

public class PAUSE_UI : MonoBehaviour
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
        RegisterMainMenuHandler();
        RegisterLevelSelectHandler();
        RegisterContinueHandler();
        RegisterOptionsHandler();
        RegisterExitGameHandler();
    }

    private void UnregisterButtonHandlers()
    {
        UnregisterMainMenuHandler();
        UnregisterLevelSelectHandler();
        UnregisterContinueHandler();
        UnregisterOptionsHandler();
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

    private void RegisterLevelSelectHandler()
    {
        Button buttonLevelSelect = root.Q<Button>("ButtonLevelSelect");
        if (buttonLevelSelect != null)
        {
            buttonLevelSelect.RegisterCallback<ClickEvent>(ContinueCallback);
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

    private void UnregisterLevelSelectHandler()
    {
        Button buttonLevelSelect = root.Q<Button>("ButtonLevelSelect");
        if (buttonLevelSelect != null)
        {
            buttonLevelSelect.UnregisterCallback<ClickEvent>(LevelSelectCallback);
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

    private void UnregisterOptionsHandler()
    {
        Button buttonOptions = root.Q<Button>("ButtonOptions");
        if (buttonOptions != null)
        {
            buttonOptions.UnregisterCallback<ClickEvent>(OptionsCallback);
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
        SceneManager.LoadScene("PawelLutostanski");
    }

    private void LevelSelectCallback(ClickEvent evt)
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

    private void ExitGameCallback(ClickEvent evt)
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
