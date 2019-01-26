using System.Linq;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameObject player;
    private GameObject pickedItem;
    private PlayerInput playerInput;
    private Vector3 dropItem = new Vector3(1f, 1f, 0f);
    private Vector3 offset = new Vector3(1.3f, 1f, 0f);
    private bool isPicked;
    private float timePassed = 0f;
    private float keyDelay = 0.2f;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }

    private void ItemPick()
    {
        if (InteractedItems.isColliding && isPicked == false)
        {
            pickedItem = InteractedItems.currentCollisions.FirstOrDefault();
            isPicked = true;
            timePassed = 0f;
        }
    }
    
    private void ItemDrop()
    {
        if (isPicked == true && pickedItem != null)
        {
            pickedItem.transform.position = player.transform.position - dropItem;
            pickedItem = null;
            isPicked = false;
            timePassed = 0f;
        }
    }

    private void Update()
    {
        timePassed += Time.deltaTime;

        if (isPicked == false && Input.GetKey(KeyCode.Space) && timePassed >= keyDelay)
        {
            ItemPick();
        }

        if (isPicked == true && Input.GetKey(KeyCode.Space)  && timePassed >= keyDelay)
        {
            ItemDrop();
            isPicked = false;
        }
    }

    private void LateUpdate()
    {
        if (isPicked && pickedItem != null)
        {
            pickedItem.transform.position = player.transform.position + offset;
        }
    }
}
