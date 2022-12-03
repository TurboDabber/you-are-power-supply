using UnityEngine;

public class WindowTrigger : MonoBehaviour
{
    public string message;
    public bool triggerOnEnable;

    public void OnEnable()
    {
        if(!triggerOnEnable) { return; }

        UIController.instance.modalWindow.gameObject.SetActive(true);
        UIController.instance.modalWindow.show(message, Next, Back, Restart);
    }

    public void Next()
    {
        UIController.instance.modalWindow.gameObject.SetActive(false);
    }

    public void Back()
    {
        UIController.instance.modalWindow.gameObject.SetActive(false);
    }

    public void Restart()
    {
        UIController.instance.modalWindow.gameObject.SetActive(false);
    }
}
