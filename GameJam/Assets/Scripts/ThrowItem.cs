using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    //PUBLIC
    public Transform[] waypointList;
    public int currentWaypoint;
    public float speed = 5f;

    //PRIVATE
    Transform targetWaypoint;


    //ZAMIEŃ TRANSFORMY NA TRZYMANY OBIEKT I PODŁĄCZ GO.


    void Start()
    {

    }

    void Update()
    {
        if (currentWaypoint < this.waypointList.Length)
        {
            if (targetWaypoint == null)
                targetWaypoint = waypointList[currentWaypoint];
            move();
        }
    }

    void move()
    {
        // rotating towards the target we want object to move
        transform.forward = Vector3.RotateTowards(transform.forward, targetWaypoint.position - transform.position, speed * Time.deltaTime, 0.0f);

        // move towards the target
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        if (transform.position == targetWaypoint.position)
        {
            currentWaypoint++;
            targetWaypoint = waypointList[currentWaypoint];
        }
    }
}
