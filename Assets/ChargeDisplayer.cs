using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ChargeDisplayer : MonoBehaviour
{
    Transform chargeTemplate;
    Transform toClean;
    [SerializeField]
    float width;
    //int chargeNumber;

    void Start()
    {
        chargeTemplate = transform.Find("ChargeTemplate");
        toClean = transform.Find("ToClean");
    }
    
    public void DisplayCharges(int charges)
    {
        Clean();
        //chargeNumber = charges;
        for(int i=0; i<charges; i++)
        {
            RectTransform chargeSlotRectTransform = Instantiate(chargeTemplate, toClean).GetComponent<RectTransform>();
            chargeSlotRectTransform.gameObject.SetActive(true);
            chargeSlotRectTransform.anchoredPosition += new Vector2(i * width, 0);
        }
        GameObject.Instantiate(chargeTemplate);
    }

    void Clean()
    {
        var children = new List<GameObject>();
        foreach (Transform child in toClean) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
    }
}
