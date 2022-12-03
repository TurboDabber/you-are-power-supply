using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ChargeEvent : UnityEvent<int> { }
public class ChargeStats : MonoBehaviour
{
    [SerializeField]
    ChargeEvent _event;
    int charge;
    int layerCharge;
    int layerAmplifier;
    bool isDisabled = false;

    void Start()
    {
        layerCharge = LayerMask.NameToLayer("Charge");
        layerAmplifier = LayerMask.NameToLayer("Amplifier");
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
                charge += otherChargeStats.charge;
                _event.Invoke(charge);
                //transform.localScale = new Vector3(size, size, 0);
                Destroy(collision.gameObject);
            }
        }

        if (collision.gameObject.layer == layerAmplifier)
        {
 
            charge *= 2;
            _event.Invoke(charge);
        }
    }
}
