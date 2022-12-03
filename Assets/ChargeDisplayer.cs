using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class ChargeDisplayer : MonoBehaviour
{
    [SerializeField]
    GameObject chargeTemplate;
    [SerializeField]
    GameObject toClean;
    [SerializeField]
    float width;

    //int chargeNumber;


    
    public void DisplayCharges(int charges)
    {
        Clean();
        //chargeNumber = charges;
        if(charges>0)
            for(int i=0; i<charges; i++)
            {
                RectTransform chargeSlotRectTransform = Instantiate(chargeTemplate, toClean.transform).GetComponent<RectTransform>();
                chargeSlotRectTransform.gameObject.SetActive(true);
                chargeSlotRectTransform.anchoredPosition += new Vector2(i * width, 0);
            }
    }

    void Clean()
    {
        var children = new List<GameObject>();
        foreach (Transform child in toClean.transform) children.Add(child.gameObject);
        children.ForEach(child => Destroy(child));
    }
}
