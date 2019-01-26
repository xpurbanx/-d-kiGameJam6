using UnityEngine;

public class Item : MonoBehaviour
{
    public static GameObject collidingItem;
    public static GameObject pickedItem;

    public static bool isColliding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isColliding = true;
            collidingItem = gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isColliding = false;
            collidingItem = null;
        }
    }
}
