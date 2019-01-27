using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    private static List<GameObject> itemsNeeded;
    // Start is called before the first frame update
    void Start()
    {
        if (tag == "Player 1") itemsNeeded = GameObject.FindGameObjectWithTag("House1").GetComponent<HouseState>().itemsToLvl;
        else itemsNeeded = GameObject.FindGameObjectWithTag("House2").GetComponent<HouseState>().itemsToLvl;
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject item in itemsNeeded)
        {
            Debug.Log(tag + item);

        }


    }
}
