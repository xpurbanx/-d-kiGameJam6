using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemScore : HouseState
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerActions actions = gameObject.GetComponent<PlayerActions>();
        float mapX = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size.x;
        float mapY = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size.y;

        if (gameObject.name == "Player1_ItemLocation")
        {
            if (collision.tag == "Player 1")
            {
                GameObject pickedObject = GameObject.FindGameObjectWithTag("Player 1").GetComponent<PlayerActions>().pickedItem;
                bool isRequired = false;
                int index = 0;

                foreach (GameObject item in gameObject.GetComponent<HouseState>().itemsToLvl)
                {
                    if (pickedObject != null)
                    {
                        if (item.name + "(Clone)" == pickedObject.name)
                        {
                            index = gameObject.GetComponent<HouseState>().itemsToLvl.IndexOf(item);
                            isRequired = true;
                            GameObject.Find("Item Manager").GetComponent<ItemRequired>().SpawnSlide1(mapX, mapY, 1);
                        }
                    }
                }

                if (isRequired)
                {
                    gameObject.GetComponent<HouseState>().itemsToLvl.RemoveAt(index);
                    GameObject.FindGameObjectWithTag("Player 1").GetComponent<PlayerActions>().pickedItem = null;
                    //actions.isPicked = false;
                    Destroy(pickedObject);
                    isRequired = false;
                }
            }
        }

        if (gameObject.name == "Player2_ItemLocation")
        {
            if (collision.tag == "Player 2")
            {
                GameObject pickedObject = GameObject.FindGameObjectWithTag("Player 2").GetComponent<PlayerActions>().pickedItem;
                bool isRequired = false;
                int index = 0;

                foreach (GameObject item in gameObject.GetComponent<HouseState>().itemsToLvl)
                {
                    if (pickedObject != null)
                    {
                        if (item.name + "(Clone)" == pickedObject.name)
                        {
                            index = gameObject.GetComponent<HouseState>().itemsToLvl.IndexOf(item);
                            isRequired = true;
                            GameObject.Find("Item Manager").GetComponent<ItemRequired>().SpawnSlide2(mapX, mapY, 1);
                        }
                    }
                }

                if (isRequired)
                {
                    gameObject.GetComponent<HouseState>().itemsToLvl.RemoveAt(index);
                    GameObject.FindGameObjectWithTag("Player 2").GetComponent<PlayerActions>().pickedItem = null;
                    //actions.isPicked = false;
                    Destroy(pickedObject);
                    isRequired = false;
                }
            }
        }
    }
}
