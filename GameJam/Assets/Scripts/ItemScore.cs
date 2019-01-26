using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemScore : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.name == "Player1_ItemLocation")
        {
            if (collision.tag == "Player 1")
            {
                //if (collision.GetComponent<PlayerActions>().)
            }
        }
    }
}
