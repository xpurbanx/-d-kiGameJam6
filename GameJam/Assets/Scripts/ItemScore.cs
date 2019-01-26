using System.Collections;
using System.Collections.Generic;
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
                if (gameObject.GetComponent<HouseState>().itemsToLvl.Contains(pickedObject))
                {
                    gameObject.GetComponent<HouseState>().itemsToLvl.Remove(pickedObject);
                    Destroy(pickedObject);
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
