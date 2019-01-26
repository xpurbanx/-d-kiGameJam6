using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemScore : HouseState
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "Player1_ItemLocation")
        {
            if (collision.tag == "Player 1")
            {
                GameObject pickedObject = GameObject.FindGameObjectWithTag("Player 1").GetComponent<PlayerActions>().pickedItem;
                bool isRequired = false;
                int index = 0;

                foreach (GameObject item in gameObject.GetComponent<HouseState>().itemsToLvl)
                {
                    if (item.name + "(Clone)" == pickedObject.name)
                    {
                        index = gameObject.GetComponent<HouseState>().itemsToLvl.IndexOf(item);
                        isRequired = true;
                    }
                }

                if (isRequired)
                {
                    gameObject.GetComponent<HouseState>().itemsToLvl.RemoveAt(index);
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
                if (gameObject.GetComponent<HouseState>().itemsToLvl.Contains(pickedObject))
                {
                    gameObject.GetComponent<HouseState>().itemsToLvl.Remove(pickedObject);
                    Destroy(pickedObject);
                }
            }
        }
    }
}
