using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;
using static Unity.VisualScripting.Metadata;

public class LightABulb : MonoBehaviour
{
    //[SerializeField]
    //GameObject modal;
    public UnityEvent terminateElectrons;
    [SerializeField]
    Light2D LightOn;
    [SerializeField]
    Light2D LightAmbient;
    [SerializeField]
    int winElectronsCondition;
    SpriteRenderer currentBulb;
    [SerializeField]
    Sprite winBulb;
    [SerializeField]
    Sprite failBulb;
    void Start()
    {
        currentBulb = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame

    public void SwitchOnLight(int charge)
    {
        terminateElectrons.Invoke();
        if (winElectronsCondition==charge)
        {
            StartCoroutine(winLight());
        }
        else if(winElectronsCondition<charge)
        {
            StartCoroutine(tooHighFail());
        }
        else
        {
            StartCoroutine(tooLowFail());
        }
    }

    System.Collections.IEnumerator winLight()
    {
        LightOn.gameObject.SetActive(true);
        while (LightOn.intensity<0.8f) 
        {
            LightOn.intensity += 0.02f;
            yield return new WaitForSeconds(0.1f);
        }
        currentBulb.sprite = winBulb;
        //Instantiate(modal, transform.position, Quaternion.identity);
    }

    System.Collections.IEnumerator tooLowFail()
    {
       
        while (LightAmbient.intensity > 0f)
        {
            LightAmbient.intensity -= 0.09f;
            yield return new WaitForSeconds(0.1f);
        }
        LightAmbient.intensity = 0.03f;
      
        //Instantiate(modal, transform.position, Quaternion.identity);
        //TO DO ADD fail EVENT!
    }

    System.Collections.IEnumerator tooHighFail()
    {
        LightOn.gameObject.SetActive(true);
        var children = new List<GameObject>();
        foreach (Transform child in LightOn.transform) children.Add(child.gameObject);
        children.ForEach(child => child.SetActive(false));
        while (LightOn.intensity < 0.90f)
        {
            LightOn.intensity += 0.02f;
            if (LightOn.intensity > 0.5f)
                LightOn.color = new Color(LightOn.color.r+0.015f, LightOn.color.g, LightOn.color.b);
            yield return new WaitForSeconds(0.01f);
        }
        LightOn.intensity = 0.4f;
        currentBulb.sprite = failBulb;

        children.ForEach(child => child.SetActive(true));
        //Instantiate(modal, transform.position, Quaternion.identity);
        //TO DO ADD fail EVENT!
    }
}
