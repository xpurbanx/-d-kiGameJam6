using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // PUBLIC VARIABLES
    public float speed = 5f;
    public Animator animator;
    // PRIVATE VARIABLES
    float horizontalValue = 0f;
    float verticalValue = 0f;

    private PlayerInput playerInput;

    private void Start()
    {
        playerInput = GetComponent<PlayerInput>();
    }
    void Update()
    {
        
        horizontalValue = playerInput.Horizontal();
        verticalValue = playerInput.Vertical();
        LayerCheck();
    }

    void LayerCheck()
    {
        float ypos1 = GameObject.FindGameObjectWithTag("Player 1").transform.position.y;
        float ypos2 = GameObject.FindGameObjectWithTag("Player 2").transform.position.y;
        SpriteRenderer r = GameObject.FindGameObjectWithTag("Player 1 Sprite").GetComponent<SpriteRenderer>();
        SpriteRenderer r2 = GameObject.FindGameObjectWithTag("Player 2 Sprite").GetComponent<SpriteRenderer>();

        if (ypos1>=ypos2)
        {
            r.sortingOrder = 0;
            r2.sortingOrder = 100;
        }
        if(ypos2 > ypos1)
        {
            r2.sortingOrder = 0;
            r.sortingOrder = 100;
        }
    }

    void FixedUpdate()
    {
        MoveHorizontally();
        MoveVertically();
    }

    void MoveHorizontally()
    {
        transform.Translate(horizontalValue * 0.001f * (speed * 2500f) * Time.deltaTime, 0, 0);
        animator.SetFloat("HorizontalSpeed", Mathf.Abs(horizontalValue));

        if (horizontalValue > 0f)
            animator.SetBool("WalksRight", true);
        else
            animator.SetBool("WalksRight", false);
        ///////////////////////////////////////
        if (horizontalValue < 0f)
            animator.SetBool("WalksLeft", true);
        else
            animator.SetBool("WalksLeft", false);
    }

    void MoveVertically()
    {
        transform.Translate(0, verticalValue * 0.001f * (speed * 2500f) * Time.deltaTime, 0);
        animator.SetFloat("VerticalSpeed", Mathf.Abs(verticalValue));

        if (verticalValue > 0f)
            animator.SetBool("WalksUp", true);
        else
            animator.SetBool("WalksUp", false);
        ///////////////////////////////////////
        if (verticalValue < 0f)
            animator.SetBool("WalksDown", true);
        else
            animator.SetBool("WalksDown", false);
    }
}
