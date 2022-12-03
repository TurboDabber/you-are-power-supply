using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCharges : MonoBehaviour
{
    [SerializeField]
    GameObject ChargeObject;
    [SerializeField]
    string inputName;
    // Update is called once per frame
    public void SpawnCharge()
    {
        if (Input.GetButtonDown(inputName))
        {
            var newCharge = GameObject.Instantiate(ChargeObject, transform.position, Quaternion.identity);
            newCharge.transform.SetParent(transform, true);
            newCharge.SetActive(true);
        }
    }
}
