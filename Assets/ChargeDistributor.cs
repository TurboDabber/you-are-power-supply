using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class StringEvent : UnityEvent<string> { }
public class ChargeDistributor : MonoBehaviour
{
    public UnityEvent[] releaseSpawners;
    [SerializeField]
    string inputName1;
    [SerializeField]
    string inputName2;
    [SerializeField]
    string inputName3;
    [SerializeField]
    string inputName4;
    [SerializeField]
    string inputName5;

    [SerializeField]
    int startNumberOfCharges;
    // Update is called once per frame
    void Update()
    {
        if (startNumberOfCharges > 0)
        {
            if (!string.IsNullOrEmpty(inputName1) && releaseSpawners.Length >= 1 && Input.GetButtonDown(inputName1))
                InvokeCharge(0);
            if (!string.IsNullOrEmpty(inputName2) && releaseSpawners.Length >= 2 && Input.GetButtonDown(inputName2))
                InvokeCharge(1);
            if (!string.IsNullOrEmpty(inputName3) && releaseSpawners.Length >= 3 && Input.GetButtonDown(inputName3))
                InvokeCharge(2);
            if (!string.IsNullOrEmpty(inputName4) && releaseSpawners.Length >= 4 && Input.GetButtonDown(inputName4))
                InvokeCharge(3);
            if (!string.IsNullOrEmpty(inputName5) && releaseSpawners.Length >= 5 && Input.GetButtonDown(inputName5))
                InvokeCharge(4);
        }
    }

    void InvokeCharge(int spawnerNumber)
    {
        releaseSpawners[spawnerNumber].Invoke();
        startNumberOfCharges--;
    }
}
