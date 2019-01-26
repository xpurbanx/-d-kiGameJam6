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
        //horizontalValue = Input.GetAxisRaw("Horizontal");
        //verticalValue = Input.GetAxisRaw("Vertical");
        horizontalValue = playerInput.Horizontal();
        verticalValue = playerInput.Vertical();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        float divider = 5f;
        if (collision.gameObject.tag == "Player 1" || collision.gameObject.tag == "Player 2")
        {
            speed = speed / divider;
        }
        else speed = divider;
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
