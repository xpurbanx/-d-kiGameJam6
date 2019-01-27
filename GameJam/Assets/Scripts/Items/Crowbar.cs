using UnityEngine;

public class Crowbar : MonoBehaviour
{
    private bool isPicked = false;
    private bool stun1 = false;
    private bool stun2 = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player 1")
        {
            stun1 = true;
        }

        if (collision.tag == "Player 2")
        {
            stun2 = true;
        }
    }

    private void Update()
    {
        isPicked = gameObject.GetComponent<Item>().isPicked;

        if (isPicked && stun1)
        {
            Debug.Log("stun1");
        }

        if (isPicked && stun2)
        {
            Debug.Log("stun2");
        }
    }
}
