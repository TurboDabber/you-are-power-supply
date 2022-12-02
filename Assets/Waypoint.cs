using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Waypoint : MonoBehaviour
{
    // put the points from unity interface
    [SerializeField]
    Transform[] wayPointList;
    public int currentWayPoint = 0;
    Transform targetWayPoint;
    float speed = 0f;
    [SerializeField]
    float speedAfterRelease = 5f;
    [SerializeField]
    string inputName;

    // Use this for initialization
    void Start()
    {

    }

    // Updates called once per frame
    void Update()
    {
        // check if we have somewere to walk
        if (currentWayPoint < this.wayPointList.Length)
        {
            if (targetWayPoint == null)
                targetWayPoint = wayPointList[currentWayPoint];
            walk();
        }

        if(Input.GetButtonDown(inputName))
        {
            speed = speedAfterRelease;
        }
    }

    void walk()
    {
        // rotate towards the target
        //transform.forward = Vector3.RotateTowards(transform.forward, targetWayPoint.position - transform.position, speed * Time.deltaTime, 0.0f);

        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWayPoint.position, speed * Time.deltaTime);

        if (transform.position == targetWayPoint.position)
        {
            if (currentWayPoint < wayPointList.Length - 1)
            {
                currentWayPoint++;
                targetWayPoint = wayPointList[currentWayPoint];
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (wayPointList.Length >= 2)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            for(int i = -1; i<wayPointList.Length-1; i++)
            {
                if(i==-1)
                    Gizmos.DrawLine(transform.position, wayPointList[i + 1].position);
                else
                    Gizmos.DrawLine(wayPointList[i].position, wayPointList[i+1].position);
            }
        }
        else if (wayPointList.Length == 1)
        {
            Gizmos.DrawLine(transform.position, wayPointList[0].position);
        }
    }
}

