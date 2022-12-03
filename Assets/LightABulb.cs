using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static Unity.VisualScripting.Metadata;

public class LightABulb : MonoBehaviour
{
    [SerializeField]
    Light2D LightOn;
    [SerializeField]
    Light2D LightAmbient;
    [SerializeField]
    int winElectronsCondition;
    Sprite currentBulb;
    [SerializeField]
    Sprite winBulb;
    [SerializeField]
    Sprite failBulb;
    void Start()
    {
        currentBulb = GetComponent<Sprite>();
    }

    // Update is called once per frame

    public void SwitchOnLight(int charge)
    {
        if(winElectronsCondition==charge)
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
        currentBulb = winBulb;
        //TO DO ADD WINNING EVENT!
    }

    System.Collections.IEnumerator tooLowFail()
    {
        LightOn.gameObject.SetActive(true);
        while (LightOn.intensity < 0.1f)
        {
            LightOn.intensity += 0.005f;
            yield return new WaitForSeconds(0.8f);
        }
        LightOn.enabled = false;
        while (LightAmbient.intensity > 0f)
        {
            LightAmbient.intensity -= 0.03f;
            yield return new WaitForSeconds(0.1f);
        }

        var children = new List<GameObject>();
        foreach (Transform child in LightOn.transform) children.Add(child.gameObject);
        children.ForEach(child => child.SetActive(false));
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
            yield return new WaitForSeconds(0.01f);
        }
        LightOn.intensity = 0.06f;


        currentBulb = failBulb;


        //TO DO ADD fail EVENT!
    }
}
