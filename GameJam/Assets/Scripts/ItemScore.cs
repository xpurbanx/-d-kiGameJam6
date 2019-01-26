using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScore : MonoBehaviour
{
    public int score;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "Player1_ItemLocation")
        {
            if (collision.tag == "Player 1")
            {
                GameObject pickedObject = GameObject.FindGameObjectWithTag("Player 1").GetComponent<PlayerActions>().pickedItem;
                if (pickedObject != null)
                {
                    //if ()
                }
            }
        }
    }
}
