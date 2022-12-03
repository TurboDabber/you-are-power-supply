using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
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
    [SerializeField]
    int charge;
    int layerCharge;
    int layerAmplifier;
    int layerBulb;
    int layerResistor;
    bool isDisabled = false;
    CircleCollider2D col;
    void Awake()
    {
        layerCharge = LayerMask.NameToLayer("Charge");
        layerAmplifier = LayerMask.NameToLayer("Amplifier");
        layerBulb = LayerMask.NameToLayer("Bulb");
        layerResistor = LayerMask.NameToLayer("Resistor");
        col =GetComponent<CircleCollider2D>();
        StartCoroutine(numberSet());
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
        else if (collision.gameObject.layer == layerAmplifier && collision.gameObject.TryGetComponent<Amplifier>(out var amplifier))
        {
 
            charge *= amplifier.GetMultiplier();
            ChangeIntensity();
            _event.Invoke(charge);
        }
        else if (collision.gameObject.layer == layerResistor && collision.gameObject.TryGetComponent<Resistor>(out var resistor))
        {

            charge -= resistor.GetDifference();
            if (charge <= 0)
            {
                Terminate();
                charge = 0;
            }
            ChangeIntensity();
            _event.Invoke(charge);
        }
        else if (collision.gameObject.layer == layerBulb && collision.gameObject.TryGetComponent<LightABulb>(out var lightABulb))
        {
            chargeLight.intensity = 0;
            lightABulb.SwitchOnLight(charge);
            gameObject.SetActive(false);
        }
    }

    public void Terminate()
    {
        col.enabled = false;
        StartCoroutine(Termination());
    }

    System.Collections.IEnumerator Termination()
    {
        while(true)
        {
            if (chargeLight.intensity > 0)
                chargeLight.intensity -= 0.03f;
            transform.localScale -= new Vector3(.01f, .01f, 0f);
            if(transform.localScale.x < 0.02f )
            {
                Destroy(gameObject);
            }
            yield return new WaitForSeconds(0.01f);
            
        }

    }

    System.Collections.IEnumerator numberSet()
    {
        yield return new WaitForSeconds(0.05f);
        _event.Invoke(charge);
    }

    void ChangeIntensity()
    {
        if (charge > 0.85f)
            chargeLight.intensity = (-((1f) / ((float)charge)) + 1.2f) * 0.8f;
    }
}
