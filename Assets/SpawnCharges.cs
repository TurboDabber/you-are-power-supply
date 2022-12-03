using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class SpawnCharges : MonoBehaviour
{
    [SerializeField]
    GameObject ChargeObject;
    List<GameObject> Charges = new List<GameObject>();
    [SerializeField]
    Light2D spawnerLight;
    bool hasShoot = false;


    // Update is called once per frame
    public void SpawnCharge()
    {
        if(!hasShoot)
        {
            var newCharge = GameObject.Instantiate(ChargeObject, transform.position, Quaternion.identity);
            newCharge.transform.SetParent(transform, true);
            newCharge.SetActive(true);
            Charges.Add(newCharge);
            hasShoot=true;
            spawnerLight.intensity *= 0;
        }
    }

    public void TerminateCharges()
    {
        hasShoot = true;
        foreach(var charge in Charges)
        {
            if(charge!=null && charge.TryGetComponent<ChargeStats>(out ChargeStats chargeStats))
            {
                chargeStats.Terminate();
            }
        }
    }
}
