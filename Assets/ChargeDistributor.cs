using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class IntEvent : UnityEvent<int> { }
public class ChargeDistributor : MonoBehaviour
{
    public UnityEvent[] releaseSpawners;
    public IntEvent displayChargeNumber;
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
    int availableCharges;
    [SerializeField]
    int maxCharges;
    [SerializeField]
    float chargeRefillTime;

    bool paused = false;

    private void Awake()
    {
        GameStateManager.Instance.OnGameStateChanged += OnGameStateChanged;
    }

    private void OnDestroy()
    {
        GameStateManager.Instance.OnGameStateChanged -= OnGameStateChanged;
    }

    private int _i;
    private void Start()
    {
        StartCoroutine(yieldChargeRefilling());
        displayChargeNumber.Invoke(availableCharges);
    }

    void Update()
    {
        if (!paused)
        {
            if (availableCharges > 0)
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
    }

    void InvokeCharge(int spawnerNumber)
    {
        releaseSpawners[spawnerNumber].Invoke();
        availableCharges--;
        displayChargeNumber.Invoke(availableCharges);
    }

    
    System.Collections.IEnumerator yieldChargeRefilling()
    {
        while (true)
        {
            if(availableCharges < maxCharges)
                availableCharges++;
            displayChargeNumber.Invoke(availableCharges);
            yield return new WaitForSeconds(chargeRefillTime);
        }
    }

    private void OnGameStateChanged(GameState newGameState)
    {
        paused = !(newGameState == GameState.Gameplay);
    }
}
