using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModalWindowPanel : MonoBehaviour
{
    [Header("Content")]
    [SerializeField]
    private Transform _contentArea;
    [SerializeField]
    private TextMeshProUGUI _heroText;
    [SerializeField]
    private Transform _horizontalLayoutArea;

    [Header("Footer")]
    [SerializeField]
    private Transform _footerArea;
    [SerializeField]
    private Button _nextButton;
    [SerializeField]
    private Button _backButton;
    [SerializeField]
    private Button _restartButton;

    public void show(string content, UnityAction nextAction, UnityAction backAction = null, UnityAction restartAction = null)
    {
        _heroText.text = content;

        bool hasNext = (nextAction != null);
        _nextButton.gameObject.SetActive(hasNext);

        bool hasBack = (backAction != null);
        _nextButton.gameObject.SetActive(hasBack);

        bool hasRestart = (restartAction != null);
        _nextButton.gameObject.SetActive(hasRestart);

        _nextButton.onClick.AddListener(nextAction);
        _backButton.onClick.AddListener(backAction);
        _restartButton.onClick.AddListener(restartAction);
    }

    public void Close()
    {
        _horizontalLayoutArea.gameObject.SetActive(false);
        _backButton.gameObject.SetActive(false);
        _nextButton.gameObject.SetActive(false);
        _footerArea.gameObject.SetActive(false);
        _restartButton.gameObject.SetActive(false);
        _contentArea.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
