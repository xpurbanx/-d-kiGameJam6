using System.Collections;
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

    /*RaycastHit2D raycast()
    {

    }*/

    void FixedUpdate()
    {
        actions = gameObject.GetComponent<PlayerActions>();
        thrownItem = actions.pickedItem;
        Vector2 origin = Vector2.zero;
        SpriteRenderer s1 = p1.GetComponent<SpriteRenderer>();
        SpriteRenderer s2 = p2.GetComponent<SpriteRenderer>();
        from = new Vector2(transform.position.x, transform.position.y + 0.5f);
        to = Vector2.zero;



        if (thrownItem != null && playerInput.BButton() && actions.isPicked == true)
        {
            RaycastHit2D hit;

            string name = s1.sprite.name;
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
