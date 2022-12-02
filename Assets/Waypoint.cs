using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    // put the points from unity interface
    public Transform[] wayPointList;
    public int currentWayPoint = 0;
    Transform targetWayPoint;
    public float speed = 0.2f;
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
}

