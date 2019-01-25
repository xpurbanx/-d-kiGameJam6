using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public static bool itemColliding;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);      
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            itemColliding = false;
        }
    }
}
