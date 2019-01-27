using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [HideInInspector]
    public bool isPicked = false;
    [HideInInspector]
    public bool isDropped = false;

    private float timeStart = 0;
    private float timeDisappear = 0;
    private float timeHandling = 0;
    private float wasHandled = 0;

    private void Awake()
    {
        float fromTime = GameObject.Find("Item Manager").GetComponent<ItemManager>().fromTimeToDisappear;
        float toTime = GameObject.Find("Item Manager").GetComponent<ItemManager>().toTimeToDisappear;

        timeDisappear = Random.Range(fromTime, toTime);
    }

    private void Start()
    {
        timeStart = Time.time;
    }

    private void Update()
    {
        if (isPicked == true)
        {
            if (timeHandling == 0)
                timeHandling = Time.time;
            else
            {
                wasHandled = timeHandling;
                timeHandling = Time.time;
            }
        }

        if (isDropped == true)
        {
            if (wasHandled == 0)
                timeHandling = Time.time - timeHandling;
            else if (wasHandled != 0)
                timeHandling = Time.time - (timeHandling + wasHandled);
        }

        if (Time.time - timeStart - timeHandling >= timeDisappear && !isPicked)
        {
            float mapX = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size.x;
            float mapY = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size.y;

            foreach (GameObject item in GameObject.Find("Item Manager").GetComponent<ItemRequired>().itemsSide1)
            {
                if (item.name + "(Clone)" == gameObject.name)
                {
                    Destroy(gameObject);
                    GameObject.Find("Item Manager").GetComponent<ItemRequired>().SpawnSlide1(mapX, mapY, 1);
                    timeStart = Time.time;
                }
            }

            foreach (GameObject item in GameObject.Find("Item Manager").GetComponent<ItemRequired>().itemsSide2)
            {
                if (item.name + "(Clone)" == gameObject.name)
                {
                    Destroy(gameObject);
                    GameObject.Find("Item Manager").GetComponent<ItemRequired>().SpawnSlide2(mapX, mapY, 1);
                    timeStart = Time.time;
                }
            }
        }
    }
}
