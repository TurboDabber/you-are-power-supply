using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetAmplifier : MonoBehaviour
{
    [SerializeField]
    private bool isOnSocket;
    GameObject collidingSocket;
    [SerializeField]
    Draggable draggable;
    int layerSocket;
    private void Start()
    {
        layerSocket = LayerMask.NameToLayer("Socket");
        isOnSocket = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == layerSocket)
        {
            isOnSocket = true;
            collidingSocket = collision.gameObject;
            draggable.SetUp(isOnSocket, collidingSocket);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {

        if (collision.gameObject.layer == layerSocket)
        {
            isOnSocket = false;
            collidingSocket = null;
            draggable.SetUp(isOnSocket, collidingSocket);
        }
    }
}
