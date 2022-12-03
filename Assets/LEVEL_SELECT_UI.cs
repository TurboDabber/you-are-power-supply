using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class LEVEL_SELECT_UI : MonoBehaviour
{
    private VisualElement root;
    private void OnEnable()
    {
        root = GetComponent<UIDocument>().rootVisualElement;
        SetupButtonHandlers();
    }

    private void SetupButtonHandlers()
    {
        SetupFirstHandler();
        SetupSecondHandler();
        SetupThirdHandler();
        SetupFourthHandler();
        SetupFifthHandler();
        SetupSixthHandler();
        SetupBackHandler();
    }

    private void SetupFirstHandler()
    {
        Button buttonFirst = root.Q<Button>("First");
        if (buttonFirst != null)
        {
            buttonFirst.RegisterCallback<ClickEvent>(FirstCallback);
        }
    }

    private void FirstCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("1LEVEL");
    }

    private void SetupSecondHandler()
    {
        Button buttonSecond = root.Q<Button>("Second");
        if (buttonSecond != null)
        {
            buttonSecond.RegisterCallback<ClickEvent>(SecondCallback);
        }
    }

    private void SecondCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("2LEVEL");
    }

    private void SetupThirdHandler()
    {
        Button buttonThird = root.Q<Button>("Third");
        if (buttonThird != null)
        {
            buttonThird.RegisterCallback<ClickEvent>(ThirdCallback);
        }
    }

    private void ThirdCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("3LEVEL");
    }

    private void SetupFourthHandler()
    {
        Button buttonFourth = root.Q<Button>("Fourth");
        if (buttonFourth != null)
        {
            buttonFourth.RegisterCallback<ClickEvent>(FourthCallback);
        }
    }

    private void FourthCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("4LEVEL");
    }

    private void SetupFifthHandler()
    {
        Button buttonFifth = root.Q<Button>("Fifth");
        if (buttonFifth != null)
        {
            buttonFifth.RegisterCallback<ClickEvent>(FifthCallback);
        }
    }

    private void FifthCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("5LEVEL");
    }

    private void SetupSixthHandler()
    {
        Button buttonFifth = root.Q<Button>("Sixth");
        if (buttonFifth != null)
        {
            buttonFifth.RegisterCallback<ClickEvent>(SixthCallback);
        }
    }

    private void SixthCallback(ClickEvent evt)
    {
        SceneManager.LoadScene("6LEVEL");
    }

    private void SetupBackHandler()
    {
        Button buttonBack = root.Q<Button>("Back");
        if (buttonBack != null)
        {
            buttonBack.RegisterCallback<ClickEvent>(BackCallback);
        }
    }

    private void BackCallback(ClickEvent evt)
    {
        gameObject.SetActive(false);
    }
}
