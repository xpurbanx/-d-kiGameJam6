using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // PUBLIC VARIABLES
    public float speed = 5f;
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
        transform.Translate(horizontalValue*0.001f*(speed*2500f)*Time.deltaTime,0,0);
        transform.Translate(0,verticalValue * 0.001f * (speed * 2500f) * Time.deltaTime, 0);
    }
}
