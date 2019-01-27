using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawnable;
    [SerializeField]
    private float spawnTime;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = Time.time + spawnTime;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < Time.time)
        {
            if (Physics2D.OverlapCircle(transform.position, 0.5f))
            {
                timer = Time.time + spawnTime;
            }
            else
            {
                GameObject spawned = Instantiate(spawnable);
                spawned.transform.position = transform.position;
                timer = Time.time + spawnTime;


            }
        }
       

        
    }
}
