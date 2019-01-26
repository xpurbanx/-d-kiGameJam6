using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingDivider : MonoBehaviour
{
    public GameObject player1;
    Vector3 offset;

    void Start()
    {
        offset = transform.position - player1.transform.position;
    }

    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the player's, but offset by the calculated offset distance.
        transform.position = player1.transform.position + offset;
    }
}
