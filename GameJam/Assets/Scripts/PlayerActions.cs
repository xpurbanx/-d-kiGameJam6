using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private Vector3 offset = new Vector3(0f, 1.5f, -1f);
    private Vector3 dropItem = new Vector3(0f, 1.5f, 0f);
    private float timePassed = 0f;
    private readonly float keyDelay = 0.2f;

    private void ItemPick()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Item.isColliding && ItemsManagement.isPicked == false)
            {
                Item.pickedItem = Item.collidingItem;
                ItemsManagement.isPicked = true;
                timePassed = 0f;
            }
        }
    }
    
    private void ItemDrop()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (ItemsManagement.isPicked == true)
            {
                Item.pickedItem.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position - dropItem;

                Item.pickedItem = null;
                ItemsManagement.isPicked = false;
                timePassed = 0f;
            }
        }
    }

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (ItemsManagement.isPicked == false && timePassed >= keyDelay)
        {
            ItemPick();
        }

        else if (ItemsManagement.isPicked == true && timePassed >= keyDelay)
        {
            ItemDrop();
        }
    }

    private void LateUpdate()
    {
        if (ItemsManagement.isPicked)
        {
            Item.pickedItem.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + offset;
        }
    }
}
