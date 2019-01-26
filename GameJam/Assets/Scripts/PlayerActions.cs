using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    void ItemPickUp()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Item.itemColliding)
            {
                Debug.Log("Item podniesiony");
            }
        }
    }

    private void Update()
    {
        ItemPickUp();
    }
}
