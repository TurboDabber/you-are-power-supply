using System.Collections;
using System.Collections.Generic;
using TMPro;
using TMPro.Examples;
using UnityEngine;

public class ChangeVisibleCharge : MonoBehaviour
{ 
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    public void ChangeCharge(int i)
    {
        textMeshPro.text=i.ToString()+"e";
    }
}
