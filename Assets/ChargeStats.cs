using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeStats : MonoBehaviour
{
    float size;
    int layer;
    void Start()
    {
        layer = LayerMask.NameToLayer("Charge");
        size = transform.localScale.x;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == layer)
        {
            if(collision.gameObject.TryGetComponent<ChargeStats>(out var otherChargeStats))
            {
                size +=otherChargeStats.size;
                transform.localScale = new Vector3(size, size, 0);
                Destroy(collision.gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
