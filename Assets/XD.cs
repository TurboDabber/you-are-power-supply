using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XD : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        prefab.GetComponent<TestScript>().message = "123";
        Instantiate(prefab, new Vector3(0,0,0), Quaternion.identity);
    }
}
