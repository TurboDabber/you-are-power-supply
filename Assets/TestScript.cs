using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    [SerializeField] private ConfirmationWindow confirmationWindow;
    public string message;

    // Start is called before the first frame update
    void Start()
    {
        OpenConfirmationWindow(message);
    }

    private void OpenConfirmationWindow(string message)
    {
        confirmationWindow.gameObject.SetActive(true);
        confirmationWindow.buttonNext.onClick.AddListener(NextClicked);
        confirmationWindow.buttonBack.onClick.AddListener(BackClicked);
        confirmationWindow.buttonRestart.onClick.AddListener(RestartClicked);
        confirmationWindow.messageText.text = message;
    }


    private void NextClicked()
    {
        confirmationWindow.gameObject.SetActive(false);
    }
    private void BackClicked()
    {
        confirmationWindow.gameObject.SetActive(false);
    }
    private void RestartClicked()
    {
        confirmationWindow.gameObject.SetActive(false);
    }
}
