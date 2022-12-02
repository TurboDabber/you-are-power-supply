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

        Button buttonContinue = root.Q<Button>("ButtonContinue");
        Button buttonOptions = root.Q<Button>("ButtonOptions");
        Button buttonCredits = root.Q<Button>("ButtonCredits");
        Button buttonQuit = root.Q<Button>("ButtonQuit");
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
        SceneManager.LoadScene("");
    }
}
