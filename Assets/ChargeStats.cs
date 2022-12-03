using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeStats : MonoBehaviour
{
    float charge;
    int layer;
    bool isDisabled = false;
    void Start()
    {
        layer = LayerMask.NameToLayer("Charge");
        charge = 1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isDisabled)
        {
            return;
        }
        if (collision.gameObject.layer == layer)
        {
            if(collision.gameObject.TryGetComponent<ChargeStats>(out var otherChargeStats) && !otherChargeStats.isDisabled)
            {
                otherChargeStats.isDisabled = true;
                charge +=otherChargeStats.charge;
                //transform.localScale = new Vector3(size, size, 0);
                Destroy(collision.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
