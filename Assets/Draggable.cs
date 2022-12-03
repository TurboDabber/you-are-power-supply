using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.Universal;

public class Draggable : MonoBehaviour
{
    [SerializeField]
    private bool isOnSocket;
    GameObject collidingSocket;
    private bool isDragged; 
    private bool isDraggedEnabled;
    int layerSocket;
    Vector3 initPosition;
    Light2D light2D;
    private void Start()
    {
        light2D = GetComponent<Light2D>();
        light2D.color = Color.white;
        layerSocket = LayerMask.NameToLayer("Socket");
        isOnSocket = false;
        isDragged= false;
        isDraggedEnabled = true;
        initPosition = transform.position;
    }
    public void OnMouseDown()
    {
        if(isDraggedEnabled)
            isDragged = true;
    }

    public void OnMouseUp()
    {
            isDragged = false;
    }

    private void Update()
    {
       if(isDragged)
        {
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            transform.Translate(mousePosition);
        }
       else if(isOnSocket && collidingSocket != null)
       {
            transform.position = (collidingSocket.transform.position);
            transform.position += new Vector3(0f, 0.6f, 0f);
       }
       else
       {
            transform.position = (initPosition);
       }
    }
    public void DisableDragging()
    {
        isDraggedEnabled=false;
    }
    public void SetUp(bool isSocket, GameObject socket)
    {
        isOnSocket = isSocket;
        collidingSocket = socket;
        if(isOnSocket)
        {
            light2D.color = Color.blue;
        }
        else
        {
            light2D.color = Color.white;
        }
    }
}