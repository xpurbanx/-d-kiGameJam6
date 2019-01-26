using System.Collections.Generic;
using UnityEngine;

public class SpawningItems : MonoBehaviour
{
    public List<GameObject> itemType = new List<GameObject>();
    public int numberOfItems;

    private Vector2 lastPosition = new Vector3(0, 0, 0);
    private float mapX;
    private float mapY;
    bool looping1 = true;
    bool looping2 = true;

    void Start()
    {
        SpawnItems();
    }

    void spawnSide1(float x, float y)
    {
        Vector3 spawnPos = new Vector3(x, y);
        int randomItemType = Random.Range(0, 5);

        float radius = 1f;
        if (Physics2D.OverlapCircle(spawnPos, radius))
        {
            looping1 = true;

        }
        else
        {
            GameObject item = Instantiate(ItemRequired.Instance.itemsSide1[randomItemType]);
            item.transform.position = new Vector2(x, y);
            looping1 = false;
        }

    }
    void spawnSide2(float x, float y)
    {
        Vector3 spawnPos = new Vector3(x, y);
        int randomItemType = Random.Range(0, 5);

        float radius = 1f;
        if (Physics2D.OverlapCircle(spawnPos, radius))
        {
            looping2 = true;

        }
        else
        {
            GameObject item = Instantiate(ItemRequired.Instance.itemsSide2[randomItemType]);
            item.transform.position = new Vector2(x, y);
            looping2 = false;
        }

    }
    void SpawnItems()
    {
        mapX = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size.x;
        mapY = GameObject.FindGameObjectWithTag("Ground").GetComponent<Renderer>().bounds.size.y;
        int randomItemType;

        for (int i = 0; i < numberOfItems; i++)
        {
            randomItemType = Random.Range(0, 5);

            looping1 = true;
            looping2 = true;
            while (looping1==true || looping2==true)
            {
                float x1 = Random.Range(-mapX / 2, 0);
                float x2 = Random.Range(0, mapX / 2);
                float y = Random.Range(-mapY / 2, mapY / 2);



               if(looping1) spawnSide1(x1, y);
               if(looping2) spawnSide2(x2, y);
                // CZĘŚĆ MICHAŁA: DETEKCJA KOLIZJI PRZY SPAWNIE PRZEDMIOTU

                //Vector3 spawnPos = new Vector3(x, y);
                //float radius = 1f;
                ////if(Physics2D.Distance(spawnPos, ))
                //if (Physics2D.OverlapCircle(spawnPos, radius))
                //{
                //    // jeżeli kolizja blokuje spawn
                //    looping = true;
                //    //Debug.Log("Musiano powtórzyć losowanie");
                //}
                //else
                //{
                //    looping = false;
                //    //Debug.Log("Wyspawnuj jeden item | "+x+", "+y);
                //    GameObject item = Instantiate(itemType[randomItemType]);
                //    item.transform.position = new Vector2(x, y);
                //}
            }
        }
    }
}