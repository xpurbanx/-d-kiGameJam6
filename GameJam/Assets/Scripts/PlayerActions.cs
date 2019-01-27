using System.Linq;
using System.Collections;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
    private float old_speed;
    public float howFar = 4.8f;
    public GameObject pickedItem;
    private PlayerInput playerInput;
    private PlayerMove playerMove;
    private InteractedItems interacted;
    private Vector3 dropItem = new Vector3(0f, 2f, 0f);
    private Vector3 offset = new Vector3(0f, 2f, 0f);
    Vector2 from;
    Vector2 to;
    public bool isPicked;

    private float timePassed = 0f;
    private float keyDelay = 1f;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        interacted = GetComponent<InteractedItems>();
        playerMove = GetComponent<PlayerMove>();
        old_speed = playerMove.speed;
    }

    private void ItemPick()
    {
        if (interacted.isColliding && isPicked == false)
        {
            pickedItem = interacted.currentCollisions.FirstOrDefault();
            pickedItem.transform.localScale = new Vector3(pickedItem.transform.localScale.x * 0.7f, pickedItem.transform.localScale.y * 0.7f, 0);
            pickedItem.GetComponent<ItemSprite>().spriteRenderer.sprite = pickedItem.GetComponent<ItemSprite>().noShadow;
            isPicked = true;
            if (pickedItem.tag == "Item")
            {
                pickedItem.GetComponent<Item>().pickedTime = Time.time;
                pickedItem.GetComponent<Item>().isPicked = true;
                pickedItem.GetComponent<Item>().isDropped = false;
            }
            timePassed = 0f;
        }
    }
    private void ItemDrop()
    {
        if (isPicked == true && pickedItem != null)
        {
            pickedItem.transform.position = gameObject.transform.position - dropItem;
            pickedItem.transform.localScale = new Vector3(pickedItem.transform.localScale.x * (1f / 0.7f), pickedItem.transform.localScale.y * (1f / 0.7f), 0);
            pickedItem.GetComponent<ItemSprite>().spriteRenderer.sprite = pickedItem.GetComponent<ItemSprite>().shadow;
            if (pickedItem.tag == "Item")
            {
                pickedItem.GetComponent<Item>().droppedTime = Time.time;
                pickedItem.GetComponent<Item>().isPicked = false;
                pickedItem.GetComponent<Item>().isDropped = true;
            }
            pickedItem = null;
            isPicked = false;
            timePassed = 0f;
        }


    }
    private void ItemPlace()
    {
        if (isPicked == true && pickedItem != null && pickedItem.tag == "Placable Item")
        {

            Vector3 orientation = playerMove.forward;
            GameObject placable = Instantiate(pickedItem.GetComponent<Placable>().placable);
            placable.transform.position = gameObject.transform.position + (Vector3.Scale(new Vector3(2f, 2f, 0), orientation));
            if (orientation == Vector3.up || orientation == Vector3.down)
                placable.transform.eulerAngles = Vector3.up * 180;
            Destroy(pickedItem);
            pickedItem = null;
            isPicked = false;
            timePassed = 0f;
        }
    }
    private void ItemThrow()
    {
        Vector3 orientation = playerMove.forward;
        Vector2 origin = Vector2.zero;
        RaycastHit2D hit;

        if (playerMove.forward == Vector3.down)
        {
            Debug.Log("down");
            origin = new Vector2(transform.position.x, transform.position.y - 2f);
            to = new Vector2(transform.position.x, transform.position.y - howFar);
        }
        if (playerMove.forward == Vector3.up)
        {
            origin = new Vector2(transform.position.x, transform.position.y + 2f);
            to = new Vector2(transform.position.x, transform.position.y + howFar);
        }
        if (playerMove.forward == Vector3.left)
        {
            origin = new Vector2(transform.position.x - 2f, transform.position.y);
            to = new Vector2(transform.position.x - howFar, transform.position.y);
        }
        if (playerMove.forward == Vector3.right)
        {
            origin = new Vector2(transform.position.x + 2f, transform.position.y);
            to = new Vector2(transform.position.x + howFar, transform.position.y);
        }

        hit = Physics2D.Raycast(transform.position, playerMove.forward, 3f);
        if (hit.collider == null)
        {
            Debug.Log("Nie wykryto kolizji");
            pickedItem.transform.position = to;
            pickedItem.transform.localScale = pickedItem.transform.localScale * (1f / 0.7f);
            pickedItem.GetComponent<ItemSprite>().spriteRenderer.sprite = pickedItem.GetComponent<ItemSprite>().shadow;
            isPicked = false;
        }

        else if (hit.collider.tag == "Item")
        {
            Debug.Log("wykryto kolizje z itemem");
            pickedItem.transform.position = to;
            pickedItem.transform.localScale = pickedItem.transform.localScale * (1f / 0.7f);
            pickedItem.GetComponent<ItemSprite>().spriteRenderer.sprite = pickedItem.GetComponent<ItemSprite>().shadow;
            isPicked = false;
        }

        else if (hit.collider.tag == "Usable Item")
        {
            Debug.Log("wykryto kolizje z usable itemem");
            pickedItem.transform.position = to;
            pickedItem.transform.localScale = pickedItem.transform.localScale * (1f / 0.7f);
            pickedItem.GetComponent<ItemSprite>().spriteRenderer.sprite = pickedItem.GetComponent<ItemSprite>().shadow;
            isPicked = false;
        }

        else if (hit.collider.tag == "Placable Item")
        {
            Debug.Log("wykryto kolizje z usable itemem");
            pickedItem.transform.position = to;
            pickedItem.transform.localScale = pickedItem.transform.localScale * (1f / 0.7f);
            pickedItem.GetComponent<ItemSprite>().spriteRenderer.sprite = pickedItem.GetComponent<ItemSprite>().shadow;
            isPicked = false;
        }

    }

    void Weight()
    {
        if (isPicked && pickedItem != null)
        {
            switch (pickedItem.name)
            {
                case ("Armchair Variant(Clone)"):
                    playerMove.speed = old_speed *0.6f;
                    return;
                case ("Bathtub Variant(Clone)"):
                    playerMove.speed = old_speed * 0.5f;
                    return;
                case ("Bicycle Variant(Clone)"):
                    playerMove.speed = old_speed * 0.7f;
                    return;
                case ("Fridge Variant(Clone)"):
                    playerMove.speed = old_speed * 0.5f;
                    return;
                case ("Kettle Variant(Clone)"):
                    playerMove.speed = old_speed;
                    return;
                case ("Lamp Variant(Clone)"):
                    playerMove.speed = old_speed * 0.7f;
                    return;
                case ("Lawn Mover Variant(Clone)"):
                    playerMove.speed = old_speed * 0.6f;
                    return;
                case ("Microwave Variant(Clone)"):
                    playerMove.speed = old_speed * 0.9f;
                    return;
                case ("Notebook Variant(Clone)"):
                    playerMove.speed = old_speed * 0.9f;
                    return;
                case ("Stuffed Deer(Clone)"):
                    playerMove.speed = old_speed * 0.6f;
                    return;
                case ("Table Variant(Clone)"):
                    playerMove.speed = old_speed * 0.6f;
                    return;
                case ("TV Variant(Clone)"):
                    playerMove.speed = old_speed * 0.7f;
                    return;
                default:
                    playerMove.speed = old_speed;
                    return;
            }
        }
        else
            playerMove.speed = old_speed;



    }

    private void Update()
    {
        if(pickedItem!=null)
            Debug.Log(pickedItem.name);
        timePassed += Time.deltaTime;

        if (isPicked == false && playerInput.AButton() && timePassed >= keyDelay)
        {
            ItemPick();
        }

        if (isPicked == true && playerInput.AButton() && timePassed >= keyDelay)
        {
            ItemDrop();
            isPicked = false;
        }
        if (isPicked == true && playerInput.BButton() && timePassed >= keyDelay)
        {
            ItemThrow();
        }

        if (isPicked == true && playerInput.XButton() && timePassed >= keyDelay)
        {
            ItemPlace();
        }

        Weight();
    }

    void LateUpdate()
    {
        if (isPicked && pickedItem != null)
        {
            pickedItem.transform.position = gameObject.transform.position + offset;
        }
    }

}
