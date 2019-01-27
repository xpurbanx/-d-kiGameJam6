/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowItem : MonoBehaviour
{
    //PUBLIC
    public float howFar = 4.8f;
    public float speed = 10000.0f;
    public float step;

    //PRIVATE
    GameObject p1;
    GameObject p2;
    GameObject thrownItem;
    PlayerInput playerInput;
    PlayerActions actions;
    Vector2 from;
    Vector2 to;

    void Start()
    {
        step = speed * Time.deltaTime;
        playerInput = GetComponent<PlayerInput>();
        p1 = GameObject.FindGameObjectWithTag("Player 1 Sprite");
        p2 = GameObject.FindGameObjectWithTag("Player 2 Sprite");
    }

    void FixedUpdate()
    {
        actions = gameObject.GetComponent<PlayerActions>();
        thrownItem = actions.pickedItem;
        Vector2 origin = Vector2.zero;
        SpriteRenderer s1 = p1.GetComponent<SpriteRenderer>();
        SpriteRenderer s2 = p2.GetComponent<SpriteRenderer>();
        from = new Vector2(transform.position.x, transform.position.y + 0.5f);
        to = Vector2.zero;

        if(Vector3.forward == Vector3.down)
        {
            origin = new Vector2(transform.position.x, transform.position.y - 2f);
            Debug.Log("down" + origin);
            to = new Vector2(transform.position.x, transform.position.y - howFar);
        }


        
        if (thrownItem != null && playerInput.BButton() && actions.isPicked == true)
        {
            RaycastHit2D hit;

            
            

            hit = Physics2D.Raycast(transform.position, origin, 3f);

            Debug.DrawRay(transform.position, origin, Color.red);
            if (hit.collider == null)
                move();
            else if (hit.collider.tag == "Item")
                move();

        }
    }

    void move()
    {
        Debug.Log(Time.deltaTime + " | " + step + " | " + speed);



        actions.isPicked = false;
        thrownItem.transform.position = Vector2.MoveTowards(from, to, 5f);//step);
        thrownItem.transform.localScale = thrownItem.transform.localScale * (1f / 0.7f);


    }
}




/*
 *          string name = s1.sprite.name;
            string name2 = s2.sprite.name;

            if (name.Contains("down") || name.Contains("DOWN"))
            {
                origin = new Vector2(transform.position.x, transform.position.y - 2f);
                Debug.Log("down" + origin);
                to = new Vector2(transform.position.x, transform.position.y - howFar);
            }
            if (name.Contains("up") || name.Contains("UP"))
            {
                Debug.Log("up");
                to = new Vector2(transform.position.x, transform.position.y + howFar);
                origin = new Vector2(transform.position.x, transform.position.y + 2f);
            }
            if (name.Contains("left") || name.Contains("LEFT"))
            {
                Debug.Log("left");
                to = new Vector2(transform.position.x - howFar, transform.position.y);
                origin = new Vector2(transform.position.x - 2f, transform.position.y);
            }
            if (name.Contains("right") || name.Contains("RIGHT"))
            {
                Debug.Log("right");
                to = new Vector2(transform.position.x + howFar, transform.position.y);
                origin = new Vector2(transform.position.x + 2f, transform.position.y);
            }
            

            if (name2.Contains("down") || name2.Contains("DOWN"))
            {
                origin = new Vector2(transform.position.x, transform.position.y - 2f);
                Debug.Log("down" + origin);
                to = new Vector2(transform.position.x, transform.position.y - howFar);
            }
            if (name2.Contains("up") || name2.Contains("UP"))
            {
                Debug.Log("up");
                to = new Vector2(transform.position.x, transform.position.y + howFar);
                origin = new Vector2(transform.position.x, transform.position.y + 2f);
            }
            if (name2.Contains("left") || name2.Contains("LEFT"))
            {
                Debug.Log("left");
                to = new Vector2(transform.position.x - howFar, transform.position.y);
                origin = new Vector2(transform.position.x - 2f, transform.position.y);
            }
            if (name2.Contains("right") || name2.Contains("RIGHT"))
            {
                Debug.Log("right");
                to = new Vector2(transform.position.x + howFar, transform.position.y);
                origin = new Vector2(transform.position.x + 2f, transform.position.y);
            }
using System.Linq;
using UnityEngine;

public class PlayerActions : MonoBehaviour
{
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
    private float keyDelay = 0.2f;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        interacted = GetComponent<InteractedItems>();
        playerMove = GetComponent<PlayerMove>();
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
        if (isPicked == true && pickedItem != null && pickedItem.tag == "Usable Item")
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
            isPicked = false;
        }
        else if (hit.collider.tag == "Item")
        {
            Debug.Log("wykryto kolizje z itemem");
            pickedItem.transform.position = to;
            pickedItem.transform.localScale = pickedItem.transform.localScale * (1f / 0.7f);
            isPicked = false;
        }
        // else if(hit.collider!=null)
        // Debug.Log("wykryto kolizje");
        //pickedItem.transform.position = to;
        //pickedItem.transform.localScale = pickedItem.transform.localScale * (1f / 0.7f);

    }

    private void Update()
    {
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
            if (isPicked == true && playerInput.XButton() && timePassed >= keyDelay)
            {
                ItemPlace();
                isPicked = false;
            }

        }
    }

    void LateUpdate()
    {
        if (isPicked && pickedItem != null)
        {
            pickedItem.transform.position = gameObject.transform.position + offset;
        }
    }

}*/
