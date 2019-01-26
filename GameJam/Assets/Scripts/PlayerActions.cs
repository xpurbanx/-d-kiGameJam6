using System.Linq;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    public GameObject player;
    private GameObject pickedItem;
    private PlayerInput playerInput;
    private Vector3 dropItem = new Vector3(0f, 2f, 0f);
    private Vector3 offset = new Vector3(0f, 1.75f, 0f);
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
            pickedItem.transform.localScale = new Vector3(pickedItem.transform.localScale.x * 0.7f, pickedItem.transform.localScale.y * 0.7f, 0);
            isPicked = true;
            timePassed = 0f;
        }
    }
    
    private void ItemDrop()
    {
        if (isPicked == true && pickedItem != null)
        {
            pickedItem.transform.position = player.transform.position - dropItem;
            pickedItem.transform.localScale = new Vector3(pickedItem.transform.localScale.x * (1f/0.7f), pickedItem.transform.localScale.y * (1f / 0.7f), 0);
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
