using System.Collections.Generic;
using UnityEngine;

public class SpawningItems : MonoBehaviour
{
    public List<GameObject> itemType = new List<GameObject>();
    public int numberOfItems;

    private Vector2 lastPosition = new Vector3(0, 0, 0);
    private float mapX;
    private float mapY;

    void Start()
    {
        SpawnItems();
    }

    void SpawnItems()
    {
        mapX = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size.x;
        mapY = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size.y;
        int randomItemType;

        for (int i = 0; i < numberOfItems; i++)
        {
            randomItemType = Random.Range(0, 11);

            bool looping = true;
            while(looping==true)
            {
                float x = Random.Range(-mapX / 2, 0);
                float y = Random.Range(-mapY / 2, mapY / 2);

                // CZĘŚĆ MICHAŁA: DETEKCJA KOLIZJI PRZY SPAWNIE PRZEDMIOTU

                Vector3 spawnPos = new Vector3(x, y);
                float radius = 1f;
                //if(Physics2D.Distance(spawnPos, ))
                if (Physics2D.OverlapCircle(spawnPos, radius))
                {
                    // jeżeli kolizja blokuje spawn
                    looping = true;
                    //Debug.Log("Musiano powtórzyć losowanie");
                }
                else
                {
                    looping = false;
                    //Debug.Log("Wyspawnuj jeden item | "+x+", "+y);
                    GameObject item = Instantiate(itemType[randomItemType]);
                    item.transform.position = new Vector2(x, y);
                }
            }
        }
    }
}