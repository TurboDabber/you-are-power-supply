using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering.Universal;

[System.Serializable]
public class ChargeEvent : UnityEvent<int> { }
public class ChargeStats : MonoBehaviour
{
    [SerializeField]
    ChargeEvent _event;
    [SerializeField]
    Light2D chargeLight;
    int charge;
    int layerCharge;
    int layerAmplifier;
    int layerBulb;
    bool isDisabled = false;

    void Start()
    {
        layerCharge = LayerMask.NameToLayer("Charge");
        layerAmplifier = LayerMask.NameToLayer("Amplifier");
        layerBulb = LayerMask.NameToLayer("Bulb");
        charge = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDisabled)
        {
            return;
        }
        if (collision.gameObject.layer == layerCharge)
        {
            if(collision.gameObject.TryGetComponent<ChargeStats>(out var otherChargeStats) && !otherChargeStats.isDisabled)
            {
                otherChargeStats.isDisabled = true;
                //(-((1)/(x))+1.2)*0.8
                
                charge += otherChargeStats.charge;
                ChangeIntensity();
                _event.Invoke(charge);
                //transform.localScale = new Vector3(size, size, 0);
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.layer == layerAmplifier)
        {
 
            charge *= 2;
            ChangeIntensity();
            _event.Invoke(charge);
        }

        if (collision.gameObject.layer == layerBulb && collision.gameObject.TryGetComponent<LightABulb>(out var lightABulb))
        {
            chargeLight.intensity = 0;
            lightABulb.SwitchOnLight(charge);
            gameObject.SetActive(false);
        }
    }

    void ChangeIntensity()
    {
        if (charge > 0.85f)
            chargeLight.intensity = (-((1f) / ((float)charge)) + 1.2f) * 0.8f;
    }
}
