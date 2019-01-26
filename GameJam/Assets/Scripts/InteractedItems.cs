using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class InteractedItems : MonoBehaviour
{
    public static List<GameObject> currentCollisions = new List<GameObject>();
    public static bool isColliding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            isColliding = true;
            currentCollisions.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Item")
        {
            currentCollisions.Remove(collision.gameObject);

            if (currentCollisions.FirstOrDefault() == null)
            {
                isColliding = false;
            }
        }
    }
}
