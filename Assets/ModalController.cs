using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModalController : MonoBehaviour
{
    public string message;
    public TestScript testObject;

    // Start is called before the first frame update
    void Start()
    {
        testObject.message = message;
    }
}
