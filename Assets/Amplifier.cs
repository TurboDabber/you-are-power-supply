using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amplifier : MonoBehaviour
{
    [SerializeField]
    private int multiplier;
    public int GetMultiplier() => multiplier;
}       
