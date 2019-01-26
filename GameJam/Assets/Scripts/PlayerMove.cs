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

    void Update()
    {
        horizontalValue = Input.GetAxisRaw("Horizontal");
        verticalValue = Input.GetAxisRaw("Vertical");
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

        if (horizontalValue == 1f)
            animator.SetBool("WalksRight", true);
        else
            animator.SetBool("WalksRight", false);
        ///////////////////////////////////////
        if (horizontalValue == -1f)
            animator.SetBool("WalksLeft", true);
        else
            animator.SetBool("WalksLeft", false);
    }

    void MoveVertically()
    {
        transform.Translate(0, verticalValue * 0.001f * (speed * 2500f) * Time.deltaTime, 0);
        animator.SetFloat("VerticalSpeed", Mathf.Abs(verticalValue));

        if (verticalValue == 1f)
            animator.SetBool("WalksUp", true);
        else
            animator.SetBool("WalksUp", false);
        ///////////////////////////////////////
        if (verticalValue == -1f)
            animator.SetBool("WalksDown", true);
        else
            animator.SetBool("WalksDown", false);
    }
}
